using SlotsEngine.Domain;
using System.Collections.Generic;
using System.Xml.Linq;

namespace SlotsEngine.Xml
{
	public class SymbolSetFactoryFromXml : ISymbolSetFactory
	{
		public ISymbolSet CreateSymbols(XElement element)
		{
			var name = element.Attribute("name").Value;
			var symbolItems = new List<ISymbol>();

			var symbolFactory = new SymbolFactoryFromXml();
			var symbolElements = element.Elements("Symbol");

			foreach (var symbolElement in symbolElements)
			{
				var symbol = symbolFactory.CreateSymbol(symbolElement);
				symbolItems.Add(symbol);
			}

			var symbols = new SymbolSet(name, symbolItems);
			return symbols;
		}
	}
}
