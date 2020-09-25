namespace Workeur.External.DataAccess
{
	public interface ISqlQueryExecutor
	{
		void Execute(string query, object param = null);
	}
}