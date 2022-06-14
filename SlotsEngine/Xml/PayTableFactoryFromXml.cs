using SlotsEngine.Domain;
using System.Collections.Generic;
using System.Xml.Linq;

namespace SlotsEngine.Xml
{
	public class PayTableFactoryFromXml : IPayTableFactory
	{
		public IPayTable CreatePayTable(XElement element)
		{
			var name = element.Attribute("name").Value;

			var payFactory = new PayFactoryFromXml();
			var payElements = element.Elements("Pay");
			var pays = new List<IPay>();

			foreach(var payElement in payElements)
			{
				var pay = payFactory.CreatePay(payElement);
				pays.Add(pay);
			}

			var payTable = new PayTable(name, pays);
			return payTable;
		}
	}
}
