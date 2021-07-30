using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MidAssignment.Models;
using MidAssignment.Models.DTO;

namespace MidAssignment.Repositories.Implementation
{
    public class BorrowingRepository : IBorrowingRepository
    {
        protected readonly LibraryContext _libraryContext;

        public BorrowingRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public async Task<BorrowingRequest> Create(BorrowingRequest request, List<int> bookIDs)
        {
            try
            {
                using var transaction = _libraryContext.Database.BeginTransaction();

                await _libraryContext.BorrowingRequests.AddAsync(request);

                foreach (var bookID in bookIDs)
                {
                    await _libraryContext.BorrowingRequestDetails.AddAsync(
                        new BorrowingRequestDetail
                        {
                            BookId = bookID,
                            RequestId = request.Id
                        }
                    );
                }

                await _libraryContext.SaveChangesAsync();

                transaction.Commit();

                return request;
            }
            catch (Exception ex)
            {
                throw new Exception($"Borrowing request could not be saved: {ex.Message}");
            }
        }

        public bool Delete(BorrowingRequest borrowingRequest)
        {
            if (borrowingRequest == null)
            {
                throw new ArgumentNullException("Borrowing request must not be null");
            }

            using var transaction = _libraryContext.Database.BeginTransaction();

            try
            {
                _libraryContext.BorrowingRequests.Remove(borrowingRequest);

                _libraryContext.SaveChanges();

                transaction.Commit();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't delete borrowing request: {ex.Message}");
            }
        }

        public IEnumerable<BorrowingRequest> GetAll()
        {
            try
            {
                return _libraryContext.BorrowingRequests.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public BorrowingRequest GetOne(int id)
        {
            try
            {
                return _libraryContext.BorrowingRequests.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public async Task<BorrowingRequest> Update(BorrowingRequestDTO borrowingRequest)
        {
            var requestEdit = this.GetOne(borrowingRequest.Id);

            if (borrowingRequest == null)
            {
                throw new ArgumentNullException("Borrowing request must not be null");
            }

            if (requestEdit == null)
            {
                throw new ArgumentNullException("Borrowing request is not exist");
            }

            using var transaction = _libraryContext.Database.BeginTransaction();

            try
            {
                requestEdit.Status = borrowingRequest.Status;

                await _libraryContext.SaveChangesAsync();

                transaction.Commit();

                return requestEdit;
            }
            catch (Exception ex)
            {
                throw new Exception($"Borrowing request could not be updated: {ex.Message}");
            }
        }

        public int CountRequestUser(int userId)
        {
            var now = DateTime.Now;

            return _libraryContext.BorrowingRequests.Where(r => r.UserId == userId && r.CreatedAt.Month == now.Month 
                                                            && r.CreatedAt.Year == now.Year && 'a'.Equals(r.Status)).ToList().Count;
        }
    }
}