using ReliableUnitOfWork.SqlAzure.Interfaces;

namespace ReliableUnitOfWork.SqlAzure.Internals
{
    public abstract class UnitOfWorkFactoryBase<TDbContext> : UniqueIdHolder, IUnitOfWorkFactory<TDbContext>
        where TDbContext : class, IDbContext, new()
    {
        public abstract IUnitOfWork<TDbContext> StartNew(params IUnitOfWorkPlayer<TDbContext>[] players);
    }
}