using System.Linq;

using AngleSharp.Dom;

namespace Workeur.External.Parsers.Providers
{
	public class PostDescriptionProvider : IWebElementProvider<string>
	{
		public string Provide(IElement domElement)
		{
			var supposedDescriptionElements = domElement
			                                  .QuerySelectorAll(".clamp__visible-tokens._ellipsis")
			                                  .ToList();

			var description = !supposedDescriptionElements.Any()
				                  ? null
				                  : supposedDescriptionElements.First().Text().Replace("\n", " ");

			return description;
		}
	}
}