using SlotsEngine.Domain;
using System.Collections.Generic;

namespace SlotsConsole
{
	internal static class ConsolePlayerFactory
	{
		public static IPlayer CreatePlayer()
		{
			var playerName = Properties.Settings1.Default.PlayerName;
			var initialBalance = Properties.Settings1.Default.PlayerInitialBalance;
			var player = Player.CreatePlayer(playerName, initialBalance);
			return player;
		}

		public static IList<IPlayer> CreatePlayers()
		{
			var playerNameSet = Properties.Settings1.Default.MultiPlayers;
			var playerNames = playerNameSet.Split(new char[] { '\u002C' });
			var initialBalance = Properties.Settings1.Default.PlayerInitialBalance;
			var players = new List<IPlayer>();
			foreach (var playerName in playerNames)
			{
				var player = Player.CreatePlayer(playerName, initialBalance);
				players.Add(player);
			}
			return players;
		}
	}
}
