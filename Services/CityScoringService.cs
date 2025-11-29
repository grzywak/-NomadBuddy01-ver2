using NomadBuddy00.Models;

namespace NomadBuddy00.Services
{
    public class CityScoringService
    {
        public double CalculateTravelerMatchScore(List<TravelerTypeScore> travelerScores, City city)
        {
            if (travelerScores == null || travelerScores.Count == 0 || city == null)
                return 0;

            // Pobieranie score dla konkretnych typów travelerów
            var natureScore = GetScore(travelerScores, "Nature Lover");
            var adventureScore = GetScore(travelerScores, "Adventure Seeker");
            var partyScore = GetScore(travelerScores, "Party Animal");
            var culturalScore = GetScore(travelerScores, "Cultural Enthusiast");
            var urbanScore = GetScore(travelerScores, "Urban Explorer");

            double score = 0;

            // Proste reguły scoringowe – możesz je rozbudować lub zamienić na parametry
            score += natureScore * (city.HealthcareQuality >= 3 ? 0.6 : 0.2);
            score += adventureScore * (city.NumberOfCoworkingSpaces >= 5 ? 0.5 : 0.3);
            score += partyScore * (city.CostOfLiving < 1500 ? 0.7 : 0.2);
            score += culturalScore * 0.4;
            score += urbanScore * (city.AverageInternetSpeedMbps >= 40 ? 0.6 : 0.2);

            return score;
        }

        private int GetScore(List<TravelerTypeScore> scores, string travelerTypeName)
        {
            return scores
                .FirstOrDefault(s => s.TravelerType != null && s.TravelerType.Name == travelerTypeName)
                ?.Score ?? 0;
        }
    }
}
