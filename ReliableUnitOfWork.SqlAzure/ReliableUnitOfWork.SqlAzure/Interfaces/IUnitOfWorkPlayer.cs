namespace ReliableUnitOfWork.SqlAzure.Interfaces
{
    public interface IUnitOfWorkPlayer<in TDbContext> : IUniqueIdHolder
        where TDbContext : IDbContext
    {
        void Join(IUnitOfWork<TDbContext> unitOfWork);
    }
}
