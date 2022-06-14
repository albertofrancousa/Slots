using System.Collections.Generic;
using System.Linq;

namespace SlotsEngine.Domain
{
	public class SymbolSet : ISymbolSet
	{
		public string Name { get; }

		public IReadOnlyDictionary<string, ISymbol> Items { get; }

		public SymbolSet(string name, IEnumerable<ISymbol> items)
		{
			Name = name;
			Items = items.ToDictionary(i => i.Name, i => i);
		}
	}
}
