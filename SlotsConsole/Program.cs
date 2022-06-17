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
		private const int GamesToPlay = 1000;
		private const int PlayerInitialBalance = 1000;
		private const string PlayerName = "Alberto";
		private static readonly int MockBetAmount = 1; // the bet amount should be fixed from configuration

		static void Main(string[] args)
		{
			var playContext = GetPlayContext();
			var allPlayersDefaultBetAmount = playContext.SlotMachine.BetInfo.Amount;
			var player = Player.CreatePlayer(PlayerName, PlayerInitialBalance, allPlayersDefaultBetAmount);
			WritePlayerInfo(player);

			var gamesPlayed = 0;
			for (var i = 0; i < GamesToPlay; i++)
			{
				// with multithreading we could play different players

				// Capture the current bet amount from the player.
				if(MockBetAmount == 0)
				{
					player.ResetCurrentBetAmount();
				} else
				{
					player.UpdateCurrentBetAmount(MockBetAmount);
				}

				if (!playContext.CanSetPlayerContext(player))
				{
					WriteInsufficientFundsMessage(playContext.Player);
					break;
				}

				var playOutcome = SlotEngine.Play(playContext);
				playContext.UpdatePayout(playOutcome.WinAmount);

				if (playOutcome.WinAmount > 0)
				{
					WritePlayOutcome(playContext, playOutcome);
				}
				gamesPlayed++;
			}

			Console.WriteLine($"Player {player.Name} signed out after playing {gamesPlayed} games with an account balance of ${player.Account.Balance}.");

			const bool DoNotEchoKey = true;
			Console.ReadKey(DoNotEchoKey);
		}

		private static void WriteInsufficientFundsMessage(IPlayer player)
		{
			var name = player.Name;
			var balance = player.Account.Balance;
			var amount = player.CurrentBetAmount;
			Console.WriteLine($"Player {name} funds of ${balance} are insufficient for a bet of ${amount}.");
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

		private static void WritePlayerInfo(IPlayer player)
		{
			var playerName = player.Name;
			var accountBalance = player.Account.Balance;
			Console.WriteLine($"{playerName} is playing with an initial account balance of ${accountBalance}.");
		}

		private static void WritePlayOutcome(IPlayContext playContext, IPlayOutcome playOutcome)
		{
			var playerName = playContext.Player.Name;
			var gameNumber = playContext.PlayStats.GamesPlayed;
			var betAmount = playContext.Player.CurrentBetAmount;
			var winAmount = playOutcome.WinAmount;
			var accountBalance = playContext.Player.Account.Balance;

			Console.WriteLine($"{playerName} played game #{gameNumber} with a bet of ${betAmount} and a win of ${winAmount}. The account balance is now ${accountBalance}.");
		}
	}
}
