using System.Collections.Generic;

namespace SlotsEngine.Machine
{
	public class SymbolSetFactory : ISymbolSetFactory
	{
		public ISymbolSet CreateSymbolSet(string name, string[] symbolNames)
		{
			var items = SymbolFactory.CreateSymbols(symbolNames);
			var symbols = new SymbolSet(name, items);
			return symbols;
		}
	}
}
