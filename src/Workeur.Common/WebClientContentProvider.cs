using System.Net;

namespace Workeur.Common
{
	public class WebClientContentProvider : IContentProvider
	{
		public string GetContent(string url)
		{
			var webClient = new WebClient
			{
				Headers =
				{
					[HttpRequestHeader.UserAgent] =
						"Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2"
				}
			};

			return webClient.DownloadString(url);
		}
	}
}