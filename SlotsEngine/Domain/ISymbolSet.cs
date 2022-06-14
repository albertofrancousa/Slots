using System.Collections.Generic;

namespace SlotsEngine.Domain
{
	public interface ISymbolSet
	{
		string Name { get; }

		IReadOnlyDictionary<string, ISymbol> Items { get; }
	}
}
