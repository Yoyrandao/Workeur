using System.Collections.Generic;
using System.Threading.Tasks;

using NUnit.Framework;

using Workeur.Common;
using Workeur.External.Models;
using Workeur.External.Parsers;
using Workeur.External.Parsers.Providers;

namespace Workeur.External.UnitTests.Parsers
{
	[TestFixture]
	public class ZenContentParserTests
	{
		[SetUp]
		public void Setup()
		{
			_target = new ZenContentParser(
				new WebRequestContentProvider(),
				new PostAuthorProvider(),
				new PostDescriptionProvider(),
				new PostTitleProvider(),
				new PostLinkProvider(),
				new PostCommentsProvider());
		}

		[Test]
 		public async Task GetTest()
        {
	        var posts = new List<Post>();

	        await foreach (var post in _target.ParseAsync())
	        {
		        posts.Add(post);
	        }

	        Assert.IsTrue(posts.Count != 0);
		}

		private ZenContentParser _target;
	}
}