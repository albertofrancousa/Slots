using System.Collections.Generic;

namespace SlotsEngine.Domain
{
	public interface IReel
	{
		string Name { get; }
	
		IEnumerable<ISymbol> Symbols { get; }
	}
}
