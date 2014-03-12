namespace ReliableUnitOfWork.SqlAzure.Interfaces
{
    public interface IUnitOfWorkFactory<TDbContext> : IUniqueIdHolder
        where TDbContext : IDbContext
    {
        IUnitOfWork<TDbContext> StartNew(params IUnitOfWorkPlayer<TDbContext>[] players);
    }
}