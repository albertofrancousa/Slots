using SlotsEngine.Evaluation;
using SlotsEngine.Machine;
using SlotsEngine.Xml;
using System.Xml.Linq;

namespace SlotsEngine.Domain
{
	public static class PlayContextFactory
	{
		public static IPlayContext CreatePlayContext(string gameDefinitionPath)
		{
			var slotMachine = LoadGameDefinition(gameDefinitionPath);
			var generator = new Generator();
			var playContext = new PlayContext(slotMachine, generator);
			return playContext;
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
