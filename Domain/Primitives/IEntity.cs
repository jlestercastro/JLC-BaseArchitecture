namespace Domain.Primitives
{
    public interface IEntity
    {
        List<IDomainEvent> DomainEvents { get; }
        void ClearDomainEvents();
    }
}
