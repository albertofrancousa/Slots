using SlotsEngine.Evaluation;
using SlotsEngine.Machine;
using SlotsEngine.Xml;
using System;
using System.Xml.Linq;

namespace SlotsEngine.Domain
{
	public static class PlayContextFactory
	{
		private static readonly Random _random = new Random();

		public static IPlayContext CreatePlayContext(IPlayer player, string gameDefinitionPath)
		{
			var slotMachine = LoadGameDefinition(gameDefinitionPath);
			var generator = new Generator(_random);
			var playContext = new PlayerContext(player, slotMachine, generator);
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
