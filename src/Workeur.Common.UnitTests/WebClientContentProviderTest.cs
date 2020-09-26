using NUnit.Framework;

namespace Workeur.Common.UnitTests
{
	[TestFixture]
	public class WebClientContentProviderTest
	{
		[SetUp]
		public void Setup()
		{
			_target = new WebClientContentProvider();
		}

		[Test]
		public void GetTest()
		{
			var result = _target.GetContent("https://www.google.com");
			
			Assert.That(result, Is.Not.Null);
		}

		private WebClientContentProvider _target;
	}
}