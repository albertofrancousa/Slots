using System.Collections.Generic;
using System.Linq;

namespace SlotsEngine.Domain
{
	public class Reel : IReel
	{
		public string Name { get; }

		public IList<ISymbol> Symbols { get; }

		public int Length => Symbols.Count();

		public Reel(string name, IList<ISymbol> symbols)
		{
			Name = name;
			Symbols = symbols;
		}
	}
}
