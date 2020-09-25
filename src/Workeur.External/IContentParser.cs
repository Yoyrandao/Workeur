using System.Collections.Generic;
using System.Threading.Tasks;

namespace Workeur.External
{
	public interface IContentParser<T>
	{
		Task<IEnumerable<T>> ParseAsync();
	}
}