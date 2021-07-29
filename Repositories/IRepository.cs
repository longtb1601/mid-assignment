using System.Collections.Generic;
using System.Threading.Tasks;
using MidAssignment.Models;
using MidAssignment.Models.DTO;

namespace MidAssignment.Repositories
{
    public interface IBookRepository
    {
        Book GetOne(int id);
        IEnumerable<Book> GetAll();
        Task<Book> Create(BookDTO book);
        Task<Book> Update(BookDTO book);
        bool Delete(Book book);
    }

    public interface ICategoryRepository
    {
        Category GetOne(int id);
        IEnumerable<Category> GetAll();
        Task<Category> Create(CategoryDTO category);
        Task<Category> Update(CategoryDTO category);
        bool Delete(Category category);
    }

    public interface IBorrowingRepository
    {
        BorrowingRequest GetOne(int id);
        IEnumerable<BorrowingRequest> GetAll();
        Task<BorrowingRequest> Create(BorrowingRequestDTO borrowingRequest, List<int> bookIDs);
        Task<BorrowingRequest> Update(BorrowingRequestDTO borrowingRequest);
        bool Delete(BorrowingRequest borrowingRequest);
    }

    public interface IUserRepository
    {
        User GetUser(UserDTO user);
    }
}