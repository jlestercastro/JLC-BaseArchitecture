namespace Domain.Primitives
{
    public interface IBaseAudit : ICreated, IUpdated, IRemoved
    {

    }

    public interface ICreated
    {
        public bool IsActive { get; set; }
        public Guid? CreatedById { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
    public interface IUpdated
    {
        public Guid? UpdatedById { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
    public interface IRemoved
    {
        public Guid? RemovedById { get; set; }
        public DateTime? RemovedDate { get; set; }
    }
}
