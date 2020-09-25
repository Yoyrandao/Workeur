using AngleSharp.Dom;

namespace Workeur.External.Parsers.Providers
{
	public interface IWebElementProvider<out T>
	{
		T Provide(IElement domElement);
	}
}