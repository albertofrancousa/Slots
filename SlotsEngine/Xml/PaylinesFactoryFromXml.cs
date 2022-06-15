using SlotsEngine.Machine;
using System.Linq;
using System.Xml.Linq;

namespace SlotsEngine.Xml
{
	public class PaylinesFactoryFromXml : IPaylinesFactory
	{
		public IPaylines CreatePaylines(XDocument document)
		{
			var elements = document.Root.Elements("Paylines");
			var element = elements.FirstOrDefault();

			var name = element.Attribute("name").Value;
			var paylines = new Paylines(name);

			var paylineFactory = new PaylineFactoryFromXml();
			var paylineElements = element.Elements("Payline");

			foreach (var paylineElement in paylineElements)
			{
				var payline = paylineFactory.CreatePayline(paylineElement);
				paylines.AddPayline(payline);
			}

			return paylines;
		}
	}
}
