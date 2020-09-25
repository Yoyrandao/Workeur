using System.Linq;
using System.Threading.Tasks;

using NUnit.Framework;

using Workeur.Common;
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
				new WebClientContentProvider(),
				new PostAuthorProvider(),
				new PostDescriptionProvider(),
				new PostTitleProvider(),
				new PostLinkProvider(),
				new PostCommentsProvider());
		}

		[Test]
 		public async Task GetTest()
        {
	        var posts = (await _target.ParseAsync()).ToList();
			
			Assert.That(posts, Is.Not.Empty);
		}

		private ZenContentParser _target;
	}
}