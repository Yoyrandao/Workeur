using System.Net;

namespace Workeur.Common
{
	public class WebClientContentProvider : IContentProvider
	{
		public string GetContent(string url)
		{
			var webClient = new WebClient();

			return webClient.DownloadString(url);
		}
	}
}