using System;
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
		public ProcessingWorker(IPostRepository repository, IContentParser<Post> contentParser)
		{
			_repository    = repository;
			_contentParser = contentParser;
		}

		[FunctionName("ProcessingWorker")]
		public async Task RunAsync([TimerTrigger("0/10 * * * * *")] TimerInfo myTimer, ILogger log)
		{
			log.LogInformation($"Preparing for posts parsing.");

			var postsCount = 0;

			await foreach (var post in _contentParser.ParseAsync())
			{
				_repository.Add(post);
				postsCount++;
			}
			
			log.LogInformation($"{postsCount} added to repository.");
		}

		private readonly IPostRepository      _repository;
		private readonly IContentParser<Post> _contentParser;
	}
}