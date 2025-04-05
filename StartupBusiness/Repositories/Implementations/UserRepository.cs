using Microsoft.EntityFrameworkCore;
using StartupBusiness.Core.Exceptions;
using StartupBusiness.Data;
using StartupBusiness.Models;
using StartupBusiness.Repositories.Interfaces;

namespace StartupBusiness.Repositories.Implementations
{
    public class UserRepository: IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddUser(User user)
        {
            var existingUser = await _context.Users.AnyAsync(u => u.Email == user.Email);
            if (existingUser)
                throw new DbExistingUserExeception($"The user with email {user.Email} is already registered");


        }
    }
}
