using MediatR;

namespace Domain.Abstractions
{
    public interface IDomainEvent :INotification
    {
        DateTime OccurredOn { get; }
    }
}