using ReliableUnitOfWork.SqlAzure.Interfaces;
using Serilog;

namespace ReliableUnitOfWork.SqlAzure
{
    public class UnitOfWorkFactory<TDbContext> : UnitOfWorkFactoryBase<TDbContext>
        where TDbContext : DbContextBase, new()
    {
        public override IUnitOfWork<TDbContext> StartNew(params IUnitOfWorkPlayer<TDbContext>[] players)
        {
            Log.Debug("Starting new UoW by UoW Factory: [{0}]", UniqueId);

            IUnitOfWork<TDbContext> unitOfWork = new UnitOfWork<TDbContext>();

            foreach (var player in players)
            {
                Log.Debug("Joining {2}: [{3}] to UoW: [{1}] by UoW Factory: [{0}]", UniqueId, unitOfWork.UniqueId, player.ToString(), player.UniqueId);

                player.Join(unitOfWork);

                Log.Debug("Joined {2}: [{3}] to UoW: [{1}] by UoW Factory: [{0}]", UniqueId, unitOfWork.UniqueId, player.ToString(), player.UniqueId);
            }

            Log.Debug("Started new UoW: [{1}] by UoW Factory: [{0}]", UniqueId, unitOfWork.UniqueId);
            return unitOfWork;
        }
    }
}