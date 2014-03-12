namespace ReliableUnitOfWork.SqlAzure.Interfaces
{
    public interface IRepository<TDbContext> : IUnitOfWorkPlayer<TDbContext>
        where TDbContext : IDbContext
    {
    }
}