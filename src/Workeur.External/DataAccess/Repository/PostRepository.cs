using Workeur.External.Models;

namespace Workeur.External.DataAccess.Repository
{
	public class PostRepository : IPostRepository
	{
		public PostRepository(ISqlQueryExecutor executor) => _executor = executor;

		public void Add(Post post)
		{
			_executor.Execute(
				@"CALL public.add_post(@Title, @Author, @Description, @Link, @Comments)",
				new
				{
					post.Title,
					post.Author,
					post.Description,
					post.Link,
					post.Comments
				});
		}

		private readonly ISqlQueryExecutor _executor;
	}
}