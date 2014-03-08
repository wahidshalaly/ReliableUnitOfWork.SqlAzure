using System.Data.Entity;
using ReliableUnitOfWork.SqlAzure.Config;
using ReliableUnitOfWork.SqlAzure.Interfaces;

namespace ReliableUnitOfWork.SqlAzure
{
    [DbConfigurationType(typeof(SqlAzureDbConfiguration))]
    public abstract class UnitDbContext : DbContext, IDbContext
    {
    }
}