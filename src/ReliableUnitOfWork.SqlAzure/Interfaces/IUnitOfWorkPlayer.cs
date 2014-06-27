namespace ReliableUnitOfWork.SqlAzure.Interfaces
{
    public interface IUnitOfWorkPlayer<TDbContext> : IUniqueIdHolder
        where TDbContext : IDbContext
    {
        IUnitOfWork<TDbContext> UnitOfWork { get;  }

        TDbContext Db { get; }

        void Join(IUnitOfWork<TDbContext> unitOfWork);
    }
}
