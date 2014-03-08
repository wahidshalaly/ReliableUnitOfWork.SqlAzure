using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;

namespace ReliableUnitOfWork.SqlAzure.Config
{
    [DebuggerStepThrough]
    public class SqlAzureDbConfiguration : DbConfiguration
    {
        public SqlAzureDbConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
            SetDefaultConnectionFactory(new SqlConnectionFactory());
        }
    }
}
