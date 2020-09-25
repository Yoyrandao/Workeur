using System;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

using Workeur.Common;

namespace Workeur.Service.Functions
{
	public class ProcessingWorker
	{
		public ProcessingWorker(IContentProvider provider)
		{
			_provider = provider;
		}
		
		[FunctionName("ProcessingWorker")]
		public async Task RunAsync([TimerTrigger("0/5 * * * * *")] TimerInfo myTimer, ILogger log)
		{
			log.LogInformation(_provider.ToString());
			log.LogInformation($"C# Timer trigger function executed at: {DateTime.UtcNow}");
		}

		private IContentProvider _provider;
	}
}