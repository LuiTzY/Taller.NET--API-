using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Domain.Entities;
using Taller.infraestructure.Context;
using Taller.infraestructure.interfaces;

namespace Taller.infraestructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly TallerVehiculosContext _context;

        public UsersRepository(TallerVehiculosContext context)
        {
            _context = context;
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}