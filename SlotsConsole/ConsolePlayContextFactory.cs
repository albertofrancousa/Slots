using SlotsEngine.Domain;
using System.Collections.Generic;

namespace SlotsConsole
{
	internal static class ConsolePlayContextFactory
	{
		public static IPlayContext CreatePlayContext(IPlayer player)
		{
			var gameDefinitionPath = Properties.Settings1.Default.GameDefinitionPath;
			var playContext = PlayContextFactory.CreatePlayContext(player, gameDefinitionPath);
			return playContext;
		}

		public static IList<IPlayContext> CreatePlayContexts(IList<IPlayer> players)
		{
			var playContexts = new List<IPlayContext>();
			var gameDefinitionPath = Properties.Settings1.Default.GameDefinitionPath;
			foreach(var player in players)
			{
				var playContext = PlayContextFactory.CreatePlayContext(player, gameDefinitionPath);
				playContexts.Add(playContext);
			}
			return playContexts;
		}
	}
}
