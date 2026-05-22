using Domain.BaseEntity;
using Domain.UnitOfWork;
using System.Linq.Expressions;
namespace Domain.BaseRepository
{
    public interface IBaseRepository<T,K>where T : IBaseEntity<K> where K:IEquatable<K>
    {
        Task<T> FindAsync(K key);

        IQueryable<T> Get(Expression<Func<T, bool>>?Predicate);
        T Add(T entity);
        T Update(T entity);
        IUnitOfWork UnitOfWork { get; }
        void Delete(T entities);
        void AddRange(List<T> entities);
        void DeleteRange(List<T> entities);
        void UpdateRange(List<T> entities);

    }
}
