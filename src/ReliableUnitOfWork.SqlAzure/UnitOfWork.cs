using System;
using ReliableUnitOfWork.SqlAzure.Internals;
using Serilog;

namespace ReliableUnitOfWork.SqlAzure
{
    public class UnitOfWork<TDbContext> : UnitOfWorkBase<TDbContext>
        where TDbContext : UnitDbContext, new()
    {
        public UnitOfWork()
        {
            Log.Debug("Constructing UoW: [{0}] for DbContext Type: '{1}'", UniqueId, typeof(TDbContext));
            
            DbContext = new TDbContext();

            Log.Debug("Constructed UoW: [{0}] for DbContext Type: '{1}'", UniqueId, typeof(TDbContext));
        }

        public override void Dispose()
        {
            Log.Debug("Disposing UoW: [{0}] for DbContext Type: '{1}'", UniqueId, typeof(TDbContext));

            if (DbContext != null)
            {
                DbContext.Dispose();
                DbContext = null;
            }

            GC.SuppressFinalize(this);
            Log.Debug("Disposed UoW: [{0}] for DbContext Type: '{1}'", UniqueId, typeof(TDbContext));
        }
    }
}
