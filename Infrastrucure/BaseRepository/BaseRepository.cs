using Domain.BaseEntity;
using Domain.BaseRepository;
using Domain.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucure.BaseRepository
{
    public class BaseRepository<T, K> : IBaseRepository<T, K>
       where T : BaseEntity<K>
       where K : IEquatable<K>
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbset;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<T> AddAsync(T entity)
        { 
            await _dbset.AddAsync(entity);
            return entity;
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
            => await _dbset.AddRangeAsync(entities);

        public Task DeleteAsync(T entity)
        {
            _dbset.Remove(entity);
            return Task.CompletedTask;
        }

        public Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            _dbset.RemoveRange(entities);
            return Task.CompletedTask;
        }

        public async Task<T?> FindAsync(K key)
            => await _dbset.FindAsync(key);

        public IQueryable<T> Get(Expression<Func<T, bool>>? predicate = null)
        {
            IQueryable<T> query = _dbset.AsNoTracking();
            if (predicate != null) query = query.Where(predicate);
            return query;
        }



        public Task UpdateAsync(T entity)
        {
            _dbset.Update(entity);
            return Task.CompletedTask;
        }

        public Task UpdateRangeAsync(IEnumerable<T> entities)
        {
            _dbset.UpdateRange(entities);
            return Task.CompletedTask;
        }
    }

}
