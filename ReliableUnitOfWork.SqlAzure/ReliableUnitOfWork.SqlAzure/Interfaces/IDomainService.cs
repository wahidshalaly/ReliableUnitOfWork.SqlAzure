namespace ReliableUnitOfWork.SqlAzure.Interfaces
{
    public interface IDomainService<out TDbContext>
        where TDbContext : IDbContext
    {
        IUnitOfWork<TDbContext> StartNewUnit();
    }
}