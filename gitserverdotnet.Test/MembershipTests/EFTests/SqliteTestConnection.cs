using System;
using System.Data.Common;
using gitserverdotnet.Data;

namespace gitserverdotnet.Test.MembershipTests.EFTests
{
    public interface IDatabaseTestConnection : IDisposable
    {
        gitserverdotnetContext GetContext();
    }

    class SqliteTestConnection : IDatabaseTestConnection
    {
        readonly DbConnection _connection;

        public SqliteTestConnection()
        {
            _connection = DbProviderFactories.GetFactory("System.Data.SQLite").CreateConnection();
            _connection.ConnectionString = "Data Source =:memory:;BinaryGUID=False";
            _connection.Open();
        }

        public gitserverdotnetContext GetContext()
        {
            return gitserverdotnetContext.FromDatabase(_connection);
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}

