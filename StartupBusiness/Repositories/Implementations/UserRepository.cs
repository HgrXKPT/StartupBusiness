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
            _context = context ?? throw new ArgumentNullException(nameof(context));
            ;
        }

        public async Task AddUser(User user)
        {
            var existingUser = await _context.Users.AnyAsync(u => u.Email == user.Email);

            if (existingUser)
                throw new DbExistingUserExeception($"The user with email {user.Email} is already registered");

            if (new[] {user.Name, user.Email, user.Password}.Any(string.IsNullOrWhiteSpace))

                throw new ArgumentException("We don't accept empty or null fields");

            _context.Add(user);
            await _context.SaveChangesAsync();


        }

        public async Task UpdateUser(int userId, User user)
        {
            var toUpdateUser = await _context.Users.FindAsync(userId);
            if (toUpdateUser == null)
                throw new KeyNotFoundException("User not found");

            if (!string.IsNullOrWhiteSpace(user.Name))
                toUpdateUser.Name = user.Name;

            if (!string.IsNullOrWhiteSpace(user.Email))
                toUpdateUser.Email = user.Email;

            if (!string.IsNullOrWhiteSpace(user.Password))
                toUpdateUser.Password = user.Password;

            await _context.SaveChangesAsync();

        }


    }
}
