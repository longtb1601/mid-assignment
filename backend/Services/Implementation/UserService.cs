using MidAssignment.Models;
using MidAssignment.Models.DTO;
using MidAssignment.Repositories;
using MidAssignment.Repositories.Implementation;

namespace MidAssignment.Services.Implementation
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUser(UserDTO user)
        {
            var auth = new User
            {
                Email = user.Email,
                Password = user.Password,
            };

            return _userRepository.GetUser(auth);
        }
    }
}