using System.Linq;

using AngleSharp.Dom;
using AngleSharp.Html.Dom;

namespace Workeur.External.Parsers.Providers
{
	public class PostLinkProvider : IWebElementProvider<string>
	{
		public string Provide(IElement domElement)
		{
			var hrefs = domElement
			           .GetElementsByClassName("card-image-view-by-metrics__clickable")
			           .OfType<IHtmlAnchorElement>().ToArray();

			return hrefs.Length == 0 ? null : hrefs.First().Href;
		}
	}
}