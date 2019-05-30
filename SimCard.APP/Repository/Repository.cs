using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using SimCard.APP.Database;
using SimCard.APP.Models;

namespace SimCard.APP.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly SimCardDBContext _context;

        private readonly DbSet<T> _dbSet;

        private readonly IUnitOfWork _unitOfWork;

        public Repository(SimCardDBContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _dbSet = _context.Set<T>();
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Create(T entity)
        {
            await _dbSet.AddAsync(entity);
            return await _unitOfWork.SaveChangeAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public async Task<bool> Remove(T entity)
        {
            _dbSet.Remove(entity);
            return await _unitOfWork.SaveChangeAsync();
        }

        public async Task<bool> Remove(int id)
        {
            T entity = await GetById(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
            return await _unitOfWork.SaveChangeAsync();
        }

        public async Task<bool> Update(T entity)
        {
            _dbSet.Update(entity);
            return await _unitOfWork.SaveChangeAsync();
        }
    }
}
