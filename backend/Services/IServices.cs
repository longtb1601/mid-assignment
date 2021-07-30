using System.Collections.Generic;
using System.Threading.Tasks;
using MidAssignment.Models;
using MidAssignment.Models.DTO;

namespace MidAssignment.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAll();
        Book GetOne(int id);
        Task<Book> Create(BookDTO book);
        Task<Book> Update(BookDTO book);
        bool Delete(Book book);
    }

    public interface ICategoryService
    {
        IEnumerable<Category> GetAll();
        Category GetOne(int id);
        Task<Category> Create(CategoryDTO category);
        Task<Category> Update(CategoryDTO category);
        bool Delete(Category category);
    }
    public interface IBorrowingRequestService
    {
        IEnumerable<BorrowingRequest> GetAll();
        BorrowingRequest GetOne(int id);
        Task<BorrowingRequest> Create(BorrowingRequestDTO request, List<int> bookIDs);
        Task<BorrowingRequest> Update(BorrowingRequestDTO request);
        bool Delete(BorrowingRequest request);
        int CountRequestUser(int userId);
    }

    public interface IUserService
    {
        User GetUser(UserDTO user);
    }
}