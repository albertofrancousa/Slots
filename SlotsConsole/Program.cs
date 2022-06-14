using SlotsEngine.Domain;
using SlotsEngine.Evaluation;
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
			var slotMachine = LoadGameDefinition(GameDefinitionPath);
			var generator = new Generator();

			var slotPlayer = new SlotPlayer();
			generator.Clear();
			var betAmount = 1;
			var _ = slotPlayer.Play(slotMachine, generator, betAmount);
		}

		private static SlotMachine LoadGameDefinition(string path)
		{
			var slotMachineFactory = new SlotMachineFactoryFromXml();
			var document = XDocument.Load(path);
			var slotMachine = slotMachineFactory.CreateSlotMachineFromXml(document);
			return slotMachine;
		}
	}
}
