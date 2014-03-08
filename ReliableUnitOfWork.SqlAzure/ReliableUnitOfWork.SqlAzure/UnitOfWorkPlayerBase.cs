using System;

namespace ReliableUnitOfWork.SqlAzure.Interfaces
{
    public abstract class UnitOfWorkPlayerBase<TDbContext> : UniqueIdHolder, IUnitOfWorkPlayer<TDbContext>
        where TDbContext : class, IDbContext, new()
    {
        protected IUnitOfWork<TDbContext> UnitOfWork { get; private set; }

        public event EventHandler PlayerJoinedUnit;

        protected UnitOfWorkPlayerBase()
        {
            PlayerJoinedUnit += HandlePlayerJoinedUnit;
        }

        protected abstract void HandlePlayerJoinedUnit(object sender, EventArgs e);

        public void Join(IUnitOfWork<TDbContext> unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException("unitOfWork");

            UnitOfWork = unitOfWork;
            OnPlayerJoinedUnit();
        }

        private void OnPlayerJoinedUnit()
        {
            if (PlayerJoinedUnit != null)
                PlayerJoinedUnit(this, EventArgs.Empty);
        }
    }
}