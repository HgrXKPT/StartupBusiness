using StartupBusiness.DTOs.UserDto;
using StartupBusiness.Models;

namespace StartupBusiness.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task AddUser(User user);
        Task UpdateUser(int userId, User user);
        Task RemoveUser(int userId);
    }
}
