using SlotsEngine.Domain;

namespace SlotsConsole
{
	internal static class ConsolePlayContextFactory
	{
		public static IPlayContext CreateInstance()
		{
			var gameDefinitionPath = Properties.Settings1.Default.GameDefinitionPath;
			var playContext = PlayContextFactory.CreatePlayContext(gameDefinitionPath);
			return playContext;
		}
	}
}
