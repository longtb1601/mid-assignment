using System.Collections.Generic;
using System.Threading.Tasks;
using MidAssignment.Models;
using MidAssignment.Models.DTO;
using MidAssignment.Repositories.Implementation;

namespace MidAssignment.Services.Implementation
{
    public class BorrowingRequestService : IBorrowingRequestService
    {
        private BorrowingRepository _borrowingRepository;
        
        public BorrowingRequestService(BorrowingRepository borrowingRepository)
        {
            _borrowingRepository = borrowingRepository;
        }

        public async Task<BorrowingRequest> Create(BorrowingRequestDTO request, List<int> bookIDs)
        {
            return await  _borrowingRepository.Create(request, bookIDs);
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
    }
}