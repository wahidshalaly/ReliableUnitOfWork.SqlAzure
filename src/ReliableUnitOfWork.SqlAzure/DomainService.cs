using ReliableUnitOfWork.SqlAzure.Interfaces;
using Serilog;

namespace ReliableUnitOfWork.SqlAzure
{
    public class DomainService<TDbContext> : DomainServiceBase<TDbContext>
        where TDbContext : UnitDbContext, new()
    {
        private readonly IUnitOfWorkFactory<TDbContext> _unitOfWorkFactory;
        private readonly IUnitOfWorkPlayer<TDbContext>[] _players;

        protected DomainService(IUnitOfWorkFactory<TDbContext> unitOfWorkFactory, params IUnitOfWorkPlayer<TDbContext>[] players)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _players = players;
        }

        public override IUnitOfWork<TDbContext> StartNewUnit()
        {
            Log.Debug("Trigger starting new UoW from DomainService: [{0}]", UniqueId);
            return _unitOfWorkFactory.StartNew(_players);
        }
    }
}