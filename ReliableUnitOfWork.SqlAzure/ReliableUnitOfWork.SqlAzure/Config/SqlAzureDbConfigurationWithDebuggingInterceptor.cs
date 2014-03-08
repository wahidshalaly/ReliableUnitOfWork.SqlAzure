using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using System.Diagnostics;
using ReliableUnitOfWork.SqlAzure.Debug;

namespace ReliableUnitOfWork.SqlAzure.Config
{
    [DebuggerStepThrough]
    public class SqlAzureDebuggingConfiguration : DbConfiguration
    {
        public SqlAzureDebuggingConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
            SetDefaultConnectionFactory(new SqlConnectionFactory());
            AddInterceptor(new DebuggingCommandInterceptor());
        }
    }
}