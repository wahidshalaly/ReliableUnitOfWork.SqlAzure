using ReliableUnitOfWork.SqlAzure.Internals;

namespace ReliableUnitOfWork.SqlAzure
{
    public abstract class UnitOfWorkPlayer<TDbContext> : UnitOfWorkPlayerBase<TDbContext>
        where TDbContext : UnitDbContext, new()
    {
    }
}
