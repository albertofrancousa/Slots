using SlotsEngine.Machine;
using System.Xml.Linq;

namespace SlotsEngine.Xml
{
	public class PayFactoryFromXml : IPayFactory
	{
		public IPay CreatePay(XElement element)
		{
			var symbolsValue= element.Attribute("ExactMatch").Value;
			var symbolNames = symbolsValue.Split(new[] { '\u002C' });
			var symbols = SymbolFactory.CreateSymbols(symbolNames);

			var amountValue = element.Attribute("Amount").Value;
			var amount = int.Parse(amountValue);

			var pay = new Pay(symbols, amount);
			return pay;
		}
	}
}
