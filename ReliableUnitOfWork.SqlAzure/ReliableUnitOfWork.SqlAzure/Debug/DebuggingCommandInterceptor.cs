using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using Serilog;

namespace ReliableUnitOfWork.SqlAzure.Debug
{
    public class DebuggingCommandInterceptor : IDbCommandInterceptor
    {
        //CAUTION: If true, it'll throw exception for every command passes through the interceptor.
        public static bool ThrowFakeExceptions;
        public static bool InterceptAllCommands;

        public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            if (InterceptAllCommands)
                Log.Debug("[Interceptor] NonQueryExecuting: ConnectionString: {0}, Command: {1}", command.Connection.ConnectionString, command.CommandText);
        }

        public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            if (InterceptAllCommands)
                Log.Debug("[Interceptor] NonQueryExecuted: ConnectionString: {0}, Command: {1}", command.Connection.ConnectionString, command.CommandText);
        }

        public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            if (InterceptAllCommands)
                Log.Debug("[Interceptor] ReaderExecuting: ConnectionString: {0}, Command: {1}", command.Connection.ConnectionString, command.CommandText);

            if (!ThrowFakeExceptions) return;
            if (!(command.CommandText.Contains("serverproperty") || command.CommandText.Contains("_MigrationHistory")))
            {
                Log.Debug("throwing fake exception from interceptor");
                throw SqlExceptionFaker.Error40501;
            }
        }

        public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            if (InterceptAllCommands)
                Log.Debug("[Interceptor] ReaderExecuted: ConnectionString: {0}, Command: {1}", command.Connection.ConnectionString, command.CommandText);
        }

        public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            if (InterceptAllCommands)
                Log.Debug("[Interceptor] ScalarExecuting: ConnectionString: {0}, Command: {1}", command.Connection.ConnectionString, command.CommandText);
        }

        public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            if (InterceptAllCommands)
                Log.Debug("[Interceptor] ScalarExecuted: ConnectionString: {0}, Command: {1}", command.Connection.ConnectionString, command.CommandText);
        }
    }
}
