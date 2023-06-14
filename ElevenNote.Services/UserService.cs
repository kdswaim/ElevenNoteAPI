using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElevenNote.Services.User;
using ElevenNote.Models.User;
using ElevenNote.Data.Entities;
using ElevenNote.Data;
using Microsoft.EntityFrameworkCore;

namespace ElevenNote.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> RegisterUserAsync(UserRegister model)
        {
            if (await GetUserByEmailAsync(model.Email) != null || await GetUserByUserNameAsync(model.Username) != null)
            return false;
            var entity = new UserEntity
            {
                Email = model.Email,
                Username = model.Username,
                Password = model.Password,
                DateCreated = DateTime.Now
            };
            await _context.Users.AddAsync(entity);
            var numberOfChanges = await _context.SaveChangesAsync();

            return numberOfChanges == 1;
        }
        private async Task<UserEntity> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Email.ToLower() == email.ToLower());
        }
        private async Task<UserEntity> GetUserByUserNameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(user => username.ToLower() ==username.ToLower());
        }
    }
}


