using MidAssignment.Models;
using MidAssignment.Models.DTO;
using MidAssignment.Repositories.Implementation;

namespace MidAssignment.Services.Implementation
{
    public class UserService : IUserService
    {
        private UserRepository _userRepository;
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUser(UserDTO user)
        {
            return _userRepository.GetUser(user);
        }
    }
}