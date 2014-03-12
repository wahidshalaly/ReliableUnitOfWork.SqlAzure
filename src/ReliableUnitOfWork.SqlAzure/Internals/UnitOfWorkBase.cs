using ReliableUnitOfWork.SqlAzure.Interfaces;

namespace ReliableUnitOfWork.SqlAzure.Internals
{
    public abstract class UnitOfWorkBase<TDbContext> : UniqueIdHolder, IUnitOfWork<TDbContext>
        where TDbContext : class, IDbContext, new()
    {
        public TDbContext DbContext { get; protected set; }

        public abstract void Dispose();
    }
}