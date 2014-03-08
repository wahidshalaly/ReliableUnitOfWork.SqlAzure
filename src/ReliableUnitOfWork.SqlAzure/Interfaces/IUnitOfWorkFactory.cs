namespace ReliableUnitOfWork.SqlAzure.Interfaces
{
    public interface IUnitOfWorkFactory<out TDbContext> : IUniqueIdHolder
        where TDbContext : IDbContext
    {
        IUnitOfWork<TDbContext> StartNew(params IUnitOfWorkPlayer<TDbContext>[] players);
    }
}