using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using SimCard.APP.Models;

namespace SimCard.APP.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SimCardDBContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public UserRepository(SimCardDBContext simCardDBContext, IUnitOfWork unitOfWork)
        {
            _context = simCardDBContext;
            _unitOfWork = unitOfWork;
        }

        public IQueryable<User> Query(Expression<Func<User, bool>> predicate)
        {
            return _context.Users.Where(predicate);
        }

        public async Task<User> GetUser(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> Create(User user)
        {
            await _context.Users.AddAsync(user);
            return await _unitOfWork.SaveChangeAsync();
        }
    }
}
