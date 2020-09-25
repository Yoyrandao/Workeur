using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

using Workeur.External;
using Workeur.External.DataAccess.Repository;
using Workeur.External.Models;

namespace Workeur.Service.Functions
{
	public class ProcessingWorker
	{
		public ProcessingWorker(
			IPostRepository      repository,
			IContentParser<Post> contentParser)
		{
			_repository    = repository;
			_contentParser = contentParser;
		}

		[FunctionName("ProcessingWorker")]
		public async Task RunAsync([TimerTrigger("0/30 * * * * *")] TimerInfo myTimer, ILogger log)
		{
			log.LogInformation($"Function triggered at {DateTime.Now}.");
			log.LogInformation($"Preparing for posts parsing.");
			
			var posts = _contentParser.ParseAsync().Result.ToArray();
			
			log.LogInformation($"Parsed {posts.Length} posts.");
			
			foreach (var post in posts)
			{
				_repository.Add(post);
			}
			
			log.LogInformation($"{posts.Length} added to repository.");
			log.LogInformation($"Execution ended.");
		}

		private readonly IPostRepository      _repository;
		private readonly IContentParser<Post> _contentParser;
	}
}