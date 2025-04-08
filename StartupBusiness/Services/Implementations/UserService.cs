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

         var hashedPassword = BCrypt.Net.BCrypt.HashPassword(createUserDto.Password);

         var user = new User(createUserDto.Name, createUserDto.Email, hashedPassword);

         await _userRepository.AddUser(user);
            
           
        }

        public async Task UpdateUser(int userId, UpdateUserDto userDto)
        {
            if (userId <=0)
                throw new ArgumentException("A valid user ID must be provided.");

            ArgumentNullException.ThrowIfNull(userDto);

            var user = new User(userDto.Name, userDto.Email, userDto.Password);

            await _userRepository.UpdateUser(userId, user);
            

        }

        public async Task RemoveUser(int userId) {

            if (userId < 0)
                throw new ArgumentException("A valid user ID must be provided.");

            await _userRepository.RemoveUser(userId);
        }

    }
}
