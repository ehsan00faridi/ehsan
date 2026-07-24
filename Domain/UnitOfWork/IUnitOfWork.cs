namespace Domain.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        Task <int> SaveEntitiesAsync(CancellationToken cancellationToken = default);
    }
}
