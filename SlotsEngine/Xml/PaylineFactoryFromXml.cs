using SlotsEngine.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace SlotsEngine.Xml
{
	public class PaylineFactoryFromXml : IPaylineFactory
	{
		public IPayline CreatePayline(XElement element)
		{
			var name = element.Attribute("name").Value;

			var verticalOffsets = element.Attribute("VerticalOffsets").Value;
			var offsetStrings = verticalOffsets.Split(new[] { '\u002C' }, StringSplitOptions.RemoveEmptyEntries);
			var offsetValues = offsetStrings.Select(v => int.Parse(v)).ToList();

			var payline = new Payline(name, offsetValues);
			return payline;
		}
	}
}
