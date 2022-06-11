using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SlotsEngine
{
	public class Symbol
	{
		private static readonly Dictionary<string, Symbol> _symbols = new Dictionary<string, Symbol>();

		public string Name { get; }

		private Symbol(string name)
		{
			Name = name;
		}

		public static Symbol CreateSymbol(string name)
		{
			Symbol symbol;

			if (_symbols.ContainsKey(name))
			{
				symbol = _symbols[name];
			}
			else
			{
				symbol = new Symbol(name);
				_symbols.Add(symbol.Name, symbol);
			}

			return symbol;
		}

		public static Symbol CreateSymbol(XElement element)
		{
			Symbol symbol;
			var name = element.Attribute("name").Value;
			symbol = CreateSymbol(name);
			return symbol;
		}

		public static IReadOnlyDictionary<string, Symbol> GetAllSymbols()
		{
			return _symbols;
		}

		public static Symbol GetSymbolByName(string name)
		{
			return _symbols[name];
		}
	}
}
