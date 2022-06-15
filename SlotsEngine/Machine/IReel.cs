using System.Collections.Generic;
using System.Linq;

namespace SlotsEngine.Machine
{
	public interface IReel
	{
		string Name { get; }
	
		IList<ISymbol> Symbols { get; }

		int Length { get; }
	}
}
