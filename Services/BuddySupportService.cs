using NomadBuddy00.Enums;
using NomadBuddy00.Models;
using NomadBuddy00.Repositories;

namespace NomadBuddy00.Services
{
    public class BuddySupportService : IBuddySupportService
    {
        private readonly IBuddySupportRepository _supporRepository;
        private readonly IBuddySupportRequestRepository _requestRepository;
        private readonly IBuddySupportSessionRepository _sessionRepository;
        private readonly IBuddySupportRatingRepository _ratingRepository;

        public BuddySupportService(IBuddySupportRepository supporRepository, IBuddySupportRequestRepository requestRepository, IBuddySupportSessionRepository sessionRepository, IBuddySupportRatingRepository ratingRepository)
        {
            _supporRepository = supporRepository;
            _requestRepository = requestRepository;
            _sessionRepository = sessionRepository;
            _ratingRepository = ratingRepository;
        }


        public async Task<bool> CreateAsync(BuddySupport model)
        {
            if (string.IsNullOrWhiteSpace(model.Title) ||
                string.IsNullOrWhiteSpace(model.Description))
                {
                return false;
                }

            if (model.Price <0)
                return false;

            model.CreatedAt = DateTime.Now; 
            await _supporRepository.AddAsync(model);
                   return true;
        }

        public async Task<IEnumerable<BuddySupport>> GetAllActiveAsync()
        {
            var allSupports = await _supporRepository.GetAllAsync();
            var activeSupports = allSupports.Where(s => s.IsActive);
            return activeSupports;
        }

        public async Task<BuddySupport?> GetDetailsAsync(int supportId)
        {
               return await _supporRepository.GetByIdAsync(supportId);
        }

        //obsluga request
        public async Task<bool> SendRequestAsync(int supportId, string nomadId)
        {
            //czy support istnieje
            var support = await _supporRepository.GetByIdAsync(supportId);
            if (support == null || !support.IsActive)
            {  
                return false; 
            }

            //czy nomad ma juz wyslany request na ten sam support
            var pending = await _requestRepository.HasPendingRequestAsync(supportId, nomadId);
            if (pending) 
            {
                return false;
            }

            var newRequest = new BuddySupportRequest
            {
                BuddySupportId = supportId,
                NomadId = nomadId,
                RequestStatus = BuddySupportRequestStatus.Pending,
                RequestTime = DateTime.UtcNow

            };

            await _requestRepository.AddAsync(newRequest);
            return true;
        }

        public async Task<bool> AcceptRequestAsync(int requestId, string buddyId)
        {
            var request = await _requestRepository.GetByIdAsync(requestId);
            if (request == null)
            {
                return false;
            }

            //czy request bylo juz zaakceptowane lub odrzucone
            if (request.RequestStatus != BuddySupportRequestStatus.Pending)
            {
                return false;
            }

            request.RequestStatus = BuddySupportRequestStatus.Accepted;
            request.AcceptedOnDate = DateTime.UtcNow;

            var newSession = new BuddySupportSession
            {  
                BuddySupportRequestId = requestId,
                NomadId = request.NomadId,
                BuddyId = buddyId,
                SessionStatus = SessionStatus.Scheduled,
                CreatedOnDate = DateTime.UtcNow,
            };

            await _sessionRepository.AddAsync(newSession);
            return true;

        }

        public Task<bool> RejectRequestAsync(int requestId, string buddyId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> HasPendingRequestAsync(int supportId, string nomadId)
        {
             return await _requestRepository.HasPendingRequestAsync(supportId, nomadId);
        }

        public Task<IEnumerable<BuddySupportRequest>> GetRequestsForBuddyIdAsync(string buddyId)
        {
            throw new NotImplementedException();
        }
    }
}
