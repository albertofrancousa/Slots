using SlotsEngine.Machine;
using SlotsEngine.Evaluation;
using SlotsEngine.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SlotsEngine.Domain;

namespace SlotsConsole
{
	internal class Program
	{
		private const string GameDefinitionPath = @".\Data\GameDefinition.xml";

		static void Main(string[] args)
		{
			var slotEngine = new SlotEngine();
			var playContext = GetPlayContext();
			var player = GetPlayer();

			IPlayOutcome playOutcome = null;
			for (var i = 0; i < 1; i++)
			{
				var betAmount = 1;
				playContext.SetPlayerContext(player, betAmount);
				playOutcome = slotEngine.Play(playContext);
				WritePlayOutcome(playContext, playOutcome);
			}
			var _ = playOutcome;

			const bool DoNotEchoKey = true;
			Console.ReadKey(DoNotEchoKey);
		}

		private static PlayContext GetPlayContext()
		{
			var slotMachine = LoadGameDefinition(GameDefinitionPath);
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

		private static IPlayer GetPlayer()
		{
			var playerName = "Alberto";
			var initialBalance = 1000;
			var player = Player.CreatePlayer(playerName, initialBalance);
			return player;
		}

		private static void WritePlayOutcome(IPlayContext playContext, IPlayOutcome playOutcome)
		{
			var playerName = playContext.Player.Name;
			var gameNumber = playContext.GameNumber;
			var betAmount = playContext.BetAmount;
			var winAmount = playOutcome.WinAmount;

			Console.WriteLine($"{playerName} played game #{gameNumber} with a bet of {betAmount} and a win of {winAmount}.");
		}
	}
}
