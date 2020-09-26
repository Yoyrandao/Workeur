using System.Collections.Generic;

namespace Workeur.External
{
	public interface IContentParser<T>
	{
		IAsyncEnumerable<T> ParseAsync();
	}
}