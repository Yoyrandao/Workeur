using System.Linq;

using AngleSharp.Dom;

namespace Workeur.External.Parsers.Providers
{
	public class PostCommentsProvider : IWebElementProvider<int>
	{
		public int Provide(IElement domElement)
		{
			var supposedCommentElements = domElement
			                              .GetElementsByClassName("zen-ui-comments-icon__bubble")
			                              .ToList();
			
			var comments = !supposedCommentElements.Any() ? 0 : int.Parse(supposedCommentElements.Single().Text());

			return comments;
		}
	}
}