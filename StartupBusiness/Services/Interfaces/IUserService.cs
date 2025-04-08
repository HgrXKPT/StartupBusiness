using StartupBusiness.DTOs.UserDto;
using StartupBusiness.Models;

namespace StartupBusiness.Services.Interfaces
{
    public interface IUserService
    {
        Task CreateUser(CreateUserDto createUserDto);
        Task UpdateUser(int UserId, UpdateUserDto userDto);
        Task RemoveUser(int userId);
    }
}
