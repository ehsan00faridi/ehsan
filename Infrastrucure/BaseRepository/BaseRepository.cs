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
    public class BaseRepository<T, K> : IBaseRepository<T, K> where T : BaseEntity<K>
        where K : IEquatable<K>
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbset;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbset=_context.Set<T>();
        }

        public IUnitOfWork UnitOfWork { get { 
                return _context;
            } 
        }

        public T Add(T entity)
        {
         return _dbset.Add(entity).Entity;
        }

        public void AddRange(List<T> entities)
        {
            _dbset.AddRange(entities);
        }

        public void Delete(T entities)
        {
            _dbset.Remove(entities);
        }

        public void DeleteRange(List<T> entities)
        {
           _dbset.RemoveRange(entities);
        }

        public Task<T> FindAsync(K key)
        {
            var data= _dbset.Where(a=>a.Id.Equals(key));
            return  data.FirstOrDefaultAsync();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>>? Predicate)
        {
            var data = _dbset.AsQueryable();
            if (Predicate != null) {
                data = data.Where(Predicate);
            
            }
            return data;
            
            
        }

        public T Update(T entity)
        {
            return _dbset.Update(entity).Entity;
        }

        public void UpdateRange(List<T> entities)
        {
            _dbset.UpdateRange(entities);
        }
    }
}
