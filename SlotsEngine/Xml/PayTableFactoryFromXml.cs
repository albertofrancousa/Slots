using SlotsEngine.Machine;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace SlotsEngine.Xml
{
	public class PayTableFactoryFromXml : IPayTableFactory
	{
		public IPayTable CreatePayTable(XDocument document)
		{
			var elements = document.Root.Elements("PayTable");
			var element = elements.FirstOrDefault();

			var payFactory = new PayFactoryFromXml();
			var payElements = element.Elements("Pay");
			var pays = new List<IPay>();

			foreach (var payElement in payElements)
			{
				var pay = payFactory.CreatePay(payElement);
				pays.Add(pay);
			}

			var name = element.Attribute("name").Value;
			var payTable = new PayTable(name, pays);
			return payTable;
		}
	}
}
