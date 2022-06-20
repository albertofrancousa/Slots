using SlotsEngine.Evaluation;
using System;
using System.Linq;
using SlotsEngine.Domain;

namespace SlotsConsole
{
	internal static class ConsoleWriter
	{
		public static void WritePlayerInfo(int gamesToPlay, IPlayer player)
		{
			var playerName = player.Name;
			var accountBalance = player.Account.Balance;
			Console.WriteLine($"{playerName} will now play {gamesToPlay} games with an initial account balance of ${accountBalance}.");
		}

		public static void WriteInsufficientFundsMessage(IPlayContext playContext)
		{
			var name = playContext.Player.Name;
			var balance = playContext.Player.Account.Balance;
			var betAmount = playContext.SlotMachine.BetInfo.Amount;
			Console.WriteLine($"\r\nPlayer {name} funds of ${balance} are insufficient for a bet of ${betAmount}.");
		}

		public static void WriteExceptionMessage(Exception exception)
		{
			Console.WriteLine("\r\nThe following exception was thrown during play evaluation:");
			Console.WriteLine(exception.ToString());
		}

		public static void WritePlayOutcome(IPlayContext playContext, IPlayGameOutcome playGameOutcome)
		{
			WritePlayerBet(playContext);
			WriteViewArea(playGameOutcome);
			WriteWinningPaylines(playGameOutcome);
		}

		private static void WritePlayerBet(IPlayContext playContext)
		{
			var playerName = playContext.Player.Name;
			var betAmount = playContext.SlotMachine.BetInfo.Amount;
			var gameNumber = playContext.PlayStats.GamesPlayed;
			Console.WriteLine($"\r\n{playerName} bets ${betAmount} on game #{gameNumber}:");
		}

		private static void WriteViewArea(IPlayGameOutcome playOutcome)
		{
			var viewRows = playOutcome.ViewArea.ViewRows;
			for (var rowNumber = 0; rowNumber < viewRows.Count; rowNumber++)
			{
				var symbols = viewRows[rowNumber].Symbols;
				var symbolNames = symbols.Select(x => x.Name).ToArray();
				var text = string.Join("\t", symbols);
				Console.WriteLine(text);
			}
		}

		private static void WriteWinningPaylines(IPlayGameOutcome playGameOutcome)
		{
			foreach (var payout in playGameOutcome.Payouts)
			{
				var paylineName = payout.Payline.Name;
				var winAmount = payout.Pay.Amount;
				var winSymbols = string.Join(", ", payout.Pay.ExactMatch);
				Console.WriteLine($"Payline {paylineName} payed ${winAmount} for exact match of [{winSymbols}].");
			}
		}

		public static void WriteWinOutcome(IPlayContext playContext, IPlayGameOutcome playOutcome)
		{
			var playerName = playContext.Player.Name;
			var winAmount = playOutcome.WinAmount;
			var accountBalance = playContext.Player.Account.Balance;
			if (winAmount > 0)
			{
				Console.WriteLine($"{playerName} won ${winAmount} bringing his account balance to ${accountBalance}");
			}
			else
			{
				Console.WriteLine($"{playerName}'s account balance is now ${accountBalance}");
			}
		}

		public static void WriteFinalMessage(IPlayContext playContext)
		{
			var playerName = playContext.Player.Name;
			var gamesPlayed = playContext.PlayStats.GamesPlayed;
			var accountBalance = playContext.Player.Account.Balance;
			Console.WriteLine($"\r\nPlayer {playerName} signed out after playing {gamesPlayed} games with an account balance of ${accountBalance}.");
		}

		public static void PressAnyKeyToEnd()
		{
			const bool DoNotEchoKey = true;
			Console.Write("\r\nThe game concluded. Press any key to terminate the console...");
			Console.ReadKey(DoNotEchoKey);
		}
	}
}
