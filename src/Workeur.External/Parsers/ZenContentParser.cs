using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AngleSharp;

using Workeur.Common;
using Workeur.External.Models;
using Workeur.External.Parsers.Providers;

namespace Workeur.External.Parsers
{
	public class ZenContentParser : IContentParser<Post>
	{
		public ZenContentParser(
			IContentProvider            contentProvider,
			IWebElementProvider<string> authorProvider,
			IWebElementProvider<string> descriptionProvider,
			IWebElementProvider<string> titleProvider,
			IWebElementProvider<string> linkProvider,
			IWebElementProvider<string> commentsProvider)
		{
			_contentProvider     = contentProvider;
			_authorProvider      = authorProvider;
			_descriptionProvider = descriptionProvider;
			_titleProvider       = titleProvider;
			_linkProvider        = linkProvider;
			_commentsProvider    = commentsProvider;

			_context = BrowsingContext.New(Configuration.Default);
		}

		public async IAsyncEnumerable<Post> ParseAsync()
		{
			var content  = _contentProvider.GetContent(ZEN_URL);
			var document = await _context.OpenAsync(request => request.Content(content));

			var parsedPosts = document.QuerySelectorAll(".card-wrapper").ToList();

			foreach (var element in parsedPosts)
			{
				var author      = _authorProvider.Provide(element);
				var title       = _titleProvider.Provide(element);
				var description = _descriptionProvider.Provide(element);
				var link        = _linkProvider.Provide(element);
				var comments    = _commentsProvider.Provide(element);

				yield return new Post
				{
					Title       = title,
					Description = description,
					Author      = author,
					Link        = link,
					Comments    = int.Parse(comments ?? "0")
				};
			}
		}

		private readonly IWebElementProvider<string> _authorProvider;
		private readonly IWebElementProvider<string> _descriptionProvider;
		private readonly IWebElementProvider<string> _titleProvider;
		private readonly IWebElementProvider<string> _linkProvider;
		private readonly IWebElementProvider<string> _commentsProvider;

		private readonly IContentProvider _contentProvider;
		private readonly IBrowsingContext _context;

		private const string ZEN_URL = "https://zen.yandex.ru/";
	}
}