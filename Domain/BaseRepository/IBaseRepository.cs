using Domain.BaseEntity;
using Domain.UnitOfWork;
using System.Linq.Expressions;
namespace Domain.BaseRepository
{
    public interface IBaseRepository<T,K>where T : IBaseEntity<K> where K:IEquatable<K>
    {

            IQueryable<T> Get(Expression<Func<T, bool>>? predicate = null);
            Task<T?> FindAsync(K Key);
            Task<T> AddAsync(T entity); 
            Task UpdateAsync(T entity);
            Task DeleteAsync(T entity);
            Task AddRangeAsync(IEnumerable<T> entities);
            Task DeleteRangeAsync(IEnumerable<T> entities);
            Task UpdateRangeAsync(IEnumerable<T> entities);
            IUnitOfWork UnitOfWork { get; }
        

    }
}
