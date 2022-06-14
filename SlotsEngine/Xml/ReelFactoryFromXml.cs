using SlotsEngine.Domain;
using System.Linq;
using System.Xml.Linq;

namespace SlotsEngine.Xml
{
	public class ReelFactoryFromXml : IReelFactory
	{
		public IReel CreateReel(XElement element)
		{
			var name = element.Attribute("name").Value;

			var symbolsValue = element.Attribute("Symbols").Value;
			var symbolNames = symbolsValue.Split(new[] { '\u002C' });
			var symbols = SymbolFactory.CreateSymbols(symbolNames);

			var reel = new Reel(name, symbols);
			return reel;
		}
	}
}
