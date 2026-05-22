using Domain.Abstractions;
using MediatR;
namespace Domain.Event
{
    public record UserRegisteredDomainEvent(int UserId, string Email) : IDomainEvent
    {
        public DateTime OccurredOn => DateTime.UtcNow;
    }
}
