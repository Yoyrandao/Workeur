using System.Linq;

using AngleSharp.Dom;

namespace Workeur.External.Parsers.Providers
{
	public class PostTitleProvider : IWebElementProvider<string>
	{
		public string Provide(IElement domElement)
		{
			var supposedTitleElements = domElement
			                            .GetElementsByClassName("card-text-clamp__text-content")
			                            .Where(x => x.ClassList.Length == 1)
			                            .ToList();
			
			var title = !supposedTitleElements.Any()
				            ? null 
				            : supposedTitleElements.First().Text().Replace("\n", " ");

			return title;
		}
	}
}