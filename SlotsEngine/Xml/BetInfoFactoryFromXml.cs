using SlotsEngine.Machine;
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
		public IBetInfo CreateBetInfo(XDocument document)
		{
			var elements = document.Root.Elements("BetInfo");
			var element = elements.FirstOrDefault(); 

			var amountValue = element.Attribute("Amount").Value;
			var amount = int.Parse(amountValue);

			var betInfo = new BetInfo(amount);
			return betInfo;
		}
	}
}
