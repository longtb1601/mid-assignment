using System.Linq;
using MidAssignment.Models;
using MidAssignment.Models.DTO;

namespace MidAssignment.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        protected readonly LibraryContext _libraryContext;

        public UserRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public User GetUser(UserDTO user)
        {
            return _libraryContext.Users.Where(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefault(); 
        }
    }
}