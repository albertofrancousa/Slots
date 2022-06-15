using System.Collections.Generic;

namespace SlotsEngine.Machine
{
	public interface ISymbolSet
	{
		string Name { get; }

		IReadOnlyDictionary<string, ISymbol> Items { get; }
	}
}
