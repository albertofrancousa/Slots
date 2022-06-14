using SlotsEngine.Domain;
using SlotsEngine.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SlotsConsole
{
	internal class Program
	{
		private const string GameDefinitionPath = @".\Data\GameDefinition.xml";

		static void Main(string[] args)
		{
			var slotMachineFactory = new SlotMachineFactoryFromXml();
			var document = XDocument.Load(GameDefinitionPath);
			var _ = slotMachineFactory.CreateSlotMachineFromXml(document);
		}
	}

}
