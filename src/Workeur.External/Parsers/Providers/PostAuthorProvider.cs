using System.Linq;

using AngleSharp.Dom;

namespace Workeur.External.Parsers.Providers
{
	public class PostAuthorProvider : IWebElementProvider<string>
	{
		public string Provide(IElement domElement)
		{
			var author = domElement
			             .GetElementsByClassName("card-channel-name")
			             .Single().Text();

			return author;
		}
	}
}