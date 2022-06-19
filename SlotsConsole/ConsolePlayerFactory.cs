using SlotsEngine.Domain;

namespace SlotsConsole
{
	internal static class ConsolePlayerFactory
	{
		public static IPlayer CreatePlayerInstance(IPlayContext playContext)
		{
			var playerName = Properties.Settings1.Default.PlayerName;
			var initialBalance = Properties.Settings1.Default.PlayerInitialBalance;
			var defaultBetAmount = playContext.SlotMachine.BetInfo.Amount;
			var player = Player.CreatePlayer(playerName, initialBalance, defaultBetAmount);
			return player;
		}
	}
}
