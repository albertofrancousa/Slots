using SlotsEngine.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SlotsEngine.Xml
{
	public class BetInfoFactoryFromXml : IBetInfoFactory
	{
		public IBetInfo CreateBetInfo(XElement element)
		{
			var amountValue = element.Attribute("Amount").Value;
			var amount = int.Parse(amountValue);

			var betInfo = new BetInfo(amount);
			return betInfo;
		}
	}
}
