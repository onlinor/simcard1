using Microsoft.EntityFrameworkCore;

using SimCard.APP.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SimCard.APP.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SimCardDBContext _context;

        public UserRepository(SimCardDBContext simCardDBContext)
        {
            _context = simCardDBContext;
        }

        public IQueryable<User> Query(Expression<Func<User, bool>> predicate)
        {
            return _context.Users.Where(predicate);
        }

        public async Task<User> Authenticate(LoginViewModel loginViewModel)
        {
            var user = await _context.Users.Where(u => u.Username == loginViewModel.Username && u.Password == loginViewModel.Password).FirstOrDefaultAsync();
            if (user != null)
            {
                return user;
            }
            return null;
        }

        public async Task<User> GetUser(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
