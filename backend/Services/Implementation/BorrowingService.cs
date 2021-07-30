using System.Collections.Generic;
using System.Threading.Tasks;
using MidAssignment.Models;
using MidAssignment.Models.DTO;
using MidAssignment.Repositories;
using MidAssignment.Repositories.Implementation;

namespace MidAssignment.Services.Implementation
{
    public class BorrowingRequestService : IBorrowingRequestService
    {
        private IBorrowingRepository _borrowingRepository;

        public BorrowingRequestService(IBorrowingRepository borrowingRepository)
        {
            _borrowingRepository = borrowingRepository;
        }

        public async Task<BorrowingRequest> Create(BorrowingRequestDTO request, List<int> bookIDs)
        {
            var newRequest = new BorrowingRequest
            {
                UserId = request.UserId,
                LibrarianId = request.LibrarianId,
                Status = request.Status,
                CreatedAt = request.CreatedAt,
                EndAt = request.EndAt,
                UpdatedAt = request.UpdatedAt,
            };

            return await _borrowingRepository.Create(newRequest, bookIDs);
        }

        public bool Delete(BorrowingRequest request)
        {
            return _borrowingRepository.Delete(request);
        }

        public IEnumerable<BorrowingRequest> GetAll()
        {
            return _borrowingRepository.GetAll();
        }

        public BorrowingRequest GetOne(int id)
        {
            return _borrowingRepository.GetOne(id);
        }

        public async Task<BorrowingRequest> Update(BorrowingRequestDTO request)
        {
            return await _borrowingRepository.Update(request);
        }

        public int CountRequestUser(int userId)
        {
            return _borrowingRepository.CountRequestUser(userId);
        }
    }
}