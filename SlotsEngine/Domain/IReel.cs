using System.Collections.Generic;
using System.Linq;

namespace SlotsEngine.Domain
{
	public interface IReel
	{
		string Name { get; }
	
		IList<ISymbol> Symbols { get; }

		int Length { get; }
	}
}
