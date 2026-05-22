
using MediatR;
using System.Text.Json.Serialization;

namespace Domain.BaseEntity
{
    public class BaseEntity<K>:IBaseEntity<K> where K : IEquatable<K>
    {
        public K Id { get; set; }

        public DateTime Created { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime Modified { get; set; }
        public int? ModifiedBy { get; set; }
        public bool Enable { get; set; }=true;
        private List<INotification> _domainEvents;
        public void AddDomainEvent(INotification eventItem) { 
        _domainEvents??=new List<INotification>();
        _domainEvents.Add(eventItem);
        }

        public void RemovedomainEvent(INotification eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }

        public void CleardomainEvents()
        {
            _domainEvents?.Clear();
        }
        [JsonIgnore]
        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents?.AsReadOnly();


    }
}
