namespace ReliableUnitOfWork.SqlAzure.Interfaces
{
    public interface IRepository<in TDbContext> : IUnitOfWorkPlayer<TDbContext>
        where TDbContext : IDbContext
    {
    }
}