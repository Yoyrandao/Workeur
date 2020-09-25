using System.Linq;

using AngleSharp.Dom;

namespace Workeur.External.Parsers.Providers
{
	public class PostDescriptionProvider : IWebElementProvider<string>
	{
		public string Provide(IElement domElement)
		{
			var supposedDescriptionElements = domElement
			                                  .GetElementsByClassName("card-text-clamp__text-content")
			                                  .Where(x => x.ClassList.Length == 2)
			                                  .ToList();

			var description = !supposedDescriptionElements.Any()
				                  ? null
				                  : supposedDescriptionElements.First().Text().Replace("\n", " ");

			return description;
		}
	}
}