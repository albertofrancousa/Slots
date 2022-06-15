using SlotsEngine.Machine;
using System.Xml.Linq;

namespace SlotsEngine.Xml
{
	public class SymbolFactoryFromXml : SymbolFactory
	{
		public ISymbol CreateSymbol(XElement element)
		{
			var name = element.Attribute("name").Value;
			var symbol = CreateSymbol(name);
			return symbol;
		}
	}
}
