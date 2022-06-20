using SlotsEngine.Domain;

namespace SlotsConsole
{
	internal static class ConsolePlayContextFactory
	{
		public static IPlayContext CreateInstance(IPlayer player)
		{
			var gameDefinitionPath = Properties.Settings1.Default.GameDefinitionPath;
			var playContext = PlayContextFactory.CreatePlayContext(player, gameDefinitionPath);
			return playContext;
		}
	}
}
