
namespace Domain.Primitives
{
    public abstract class BaseEntity<TKey> : IEntity
    {
        public TKey Id { get; set; }

        private readonly List<IDomainEvent> _domainEvents = [];

        public List<IDomainEvent> DomainEvents => [.. _domainEvents];

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        public void Raise(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
    }
}
