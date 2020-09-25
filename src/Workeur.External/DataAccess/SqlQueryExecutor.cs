using System;

using Dapper;

using Npgsql;

namespace Workeur.External.DataAccess
{
	public class SqlQueryExecutor : ISqlQueryExecutor
	{
		public SqlQueryExecutor(string connectionString) => _connectionString = connectionString;
		
		public void Execute(string query, object param = null)
		{
			Process(connection => connection.Query(query, param));
		}

		private T Process<T>(Func<NpgsqlConnection, T> func)
		{
			using var connection = new NpgsqlConnection(_connectionString);

			connection.Open();

			return func(connection);
		}

		private readonly string _connectionString;
	}
}