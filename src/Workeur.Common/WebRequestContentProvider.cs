using System.IO;
using System.Net;

namespace Workeur.Common
{
	public class WebRequestContentProvider : IContentProvider
	{
		public string GetContent(string url)
		{
			var request  = WebRequest.Create(url);
			var response = request.GetResponse();

			var dataStream = response.GetResponseStream();

			using var streamReader = new StreamReader(dataStream!);

			return streamReader.ReadToEnd();
		}
	}
}