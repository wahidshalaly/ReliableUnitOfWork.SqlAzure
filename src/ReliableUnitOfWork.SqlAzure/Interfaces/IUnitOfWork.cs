using System;

namespace ReliableUnitOfWork.SqlAzure.Interfaces
{
    public interface IUnitOfWork<out TDbContext> : IUniqueIdHolder, IDisposable
        where TDbContext : IDbContext
    {
        TDbContext DbContext { get; }
    }
}