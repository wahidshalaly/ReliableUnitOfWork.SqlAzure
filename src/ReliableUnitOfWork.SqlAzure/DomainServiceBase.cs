using ReliableUnitOfWork.SqlAzure.Interfaces;

namespace ReliableUnitOfWork.SqlAzure
{
    public abstract class DomainServiceBase<TDbContext> : UniqueIdHolder, IDomainService<TDbContext>
        where TDbContext : class, IDbContext, new()
    {
        public abstract IUnitOfWork<TDbContext> StartNewUnit();
    }
}