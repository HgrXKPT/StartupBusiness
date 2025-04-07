using StartupBusiness.DTOs.UserDto;
using StartupBusiness.Models;
using StartupBusiness.Services.Interfaces;
using StartupBusiness.Repositories.Implementations;
using StartupBusiness.Repositories.Interfaces;

namespace StartupBusiness.Services.Implementations
{

    
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task CreateUser(CreateUserDto createUserDto)
        {

         ArgumentNullException.ThrowIfNull(createUserDto);

         var user = new User(createUserDto.Name, createUserDto.Email, createUserDto.Password);

         await _userRepository.AddUser(user);
            
           
        }

    }
}
