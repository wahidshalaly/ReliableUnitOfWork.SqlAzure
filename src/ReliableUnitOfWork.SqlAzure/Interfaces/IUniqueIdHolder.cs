namespace ReliableUnitOfWork.SqlAzure.Interfaces
{
    public interface IUniqueIdHolder
    {
        long UniqueId { get; }
    }
}