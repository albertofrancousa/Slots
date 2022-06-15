using System.Collections.Generic;

namespace SlotsEngine.Machine
{
	public class SymbolFactory : ISymbolFactory
	{
		private static readonly object _createLock = new object();

		private static readonly Dictionary<string, ISymbol> _symbols = new Dictionary<string, ISymbol>();

		public static IList<ISymbol> CreateSymbols(IEnumerable<string> symbolNames)
		{
			var symbols = new List<ISymbol>();

			foreach (var symbolName in symbolNames)
			{
				var symbol = CreateSymbol(symbolName);
				symbols.Add(symbol);
			}

			return symbols;
		}

		public static ISymbol CreateSymbol(string name)
		{
			ISymbol symbol;

			lock (_createLock)
			{
				if (_symbols.ContainsKey(name))
				{
					symbol = _symbols[name];
				}
				else
				{
					symbol = new Symbol(name);
					_symbols.Add(symbol.Name, symbol);
				}
			}

			return symbol;
		}

		public static IReadOnlyDictionary<string, ISymbol> GetAllSymbols()
		{
			return _symbols;
		}

		public static ISymbol GetSymbolByName(string name)
		{
			return _symbols[name];
		}
	}
}
