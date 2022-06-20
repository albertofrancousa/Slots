using SlotsEngine.Domain;

namespace SlotsConsole
{
	internal static class ConsolePlayerFactory
	{
		public static IPlayer CreatePlayerInstance()
		{
			var playerName = Properties.Settings1.Default.PlayerName;
			var initialBalance = Properties.Settings1.Default.PlayerInitialBalance;
			var player = Player.CreatePlayer(playerName, initialBalance);
			return player;
		}
	}
}
