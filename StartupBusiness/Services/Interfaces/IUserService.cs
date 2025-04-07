using StartupBusiness.DTOs.UserDto;
using StartupBusiness.Models;

namespace StartupBusiness.Services.Interfaces
{
    public interface IUserService
    {
        Task CreateUser(CreateUserDto createUserDto); 
    }
}
