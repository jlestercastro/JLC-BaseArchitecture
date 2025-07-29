namespace Application.Abstraction
{
    public interface IEntityContext
    {
        string EntityId { get; }
        string? UserEmail { get; }
        bool IsAuthenticated { get; }
        string IpAddress();
    }
}
