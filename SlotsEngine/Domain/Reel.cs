using System.Collections.Generic;

namespace SlotsEngine.Domain
{
	public class Reel : IReel
	{
		public string Name { get; }

		public IEnumerable<ISymbol> Symbols { get; }

		public Reel(string name, IEnumerable<ISymbol> symbols)
		{
			Name = name;
			Symbols = symbols;
		}
	}
}
