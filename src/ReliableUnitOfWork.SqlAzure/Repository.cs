using System;
using ReliableUnitOfWork.SqlAzure.Interfaces;

namespace ReliableUnitOfWork.SqlAzure
{
    public class Repository<TDbContext> : UnitOfWorkPlayer<TDbContext>, IRepository<TDbContext>
        where TDbContext : UnitDbContext, new()
    {
        protected override void HandlePlayerJoinedUnit(object sender, EventArgs e)
        {
        }
    }
}