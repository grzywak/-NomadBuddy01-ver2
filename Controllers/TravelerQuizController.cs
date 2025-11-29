using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NomadBuddy00.Models;
using NomadBuddy00.Repositories;
using NomadBuddy00.ViewModels;

namespace NomadBuddy00.Controllers
{
    [Authorize(Roles ="Nomad")]
    public class TravelerQuizController : Controller
    {
        private readonly ITravelerQuizRepository _quizRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public TravelerQuizController(ITravelerQuizRepository quizRepository, UserManager<ApplicationUser> userManager)
        {
            _quizRepository = quizRepository;
            _userManager = userManager;
        }

        // GET: /TravelerQuiz/Quiz
        public async Task<IActionResult> Quiz()
        {
            var questions = await _quizRepository.GetAllQuestionsAsync();

            var viewModel = new TravelerQuizViewModel
            {
                Questions = questions.Select(q => new TravelerQuizQuestionViewModel
                {
                    QuestionId = q.Id,
                    QuestionText = q.QuestionText
                }).ToList()
            };

            return View(viewModel);
        }

        // POST: /TravelerQuiz/Quiz
        [HttpPost]
        public async Task<IActionResult> Quiz(TravelerQuizViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            var nomadId = user.Id;

            // Map user answers to TravelerAnswer
            var answers = model.Questions.Select(q => new TravelerAnswer
            {
                TravelerQuestionId = q.QuestionId,
                NomadId = nomadId,
                Value = q.Answer
            }).ToList();

            // Save to DB and calculate scores
            await _quizRepository.SaveAnswersAsync(nomadId, answers);
            await _quizRepository.CalculateScoresAsync(nomadId);

            return RedirectToAction("Results");
        }

        // GET: /TravelerQuiz/Results
        public async Task<IActionResult> Results()
        {
            var user = await _userManager.GetUserAsync(User);
            var scores = await _quizRepository.GetScoresAsync(user.Id);

            var viewModel = new TravelerQuizResultViewModel
            {
                Scores = scores.Select(s => new TravelerTypeScoreViewModel
                {
                    TravelerTypeName = s.TravelerType.Name,
                    Description = s.TravelerType.Description,
                    Score = s.Score
                }).ToList()
            };

            return View(viewModel);
        }
    }
}
