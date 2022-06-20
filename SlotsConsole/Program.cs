using SlotsEngine.Machine;
using SlotsEngine.Evaluation;
using SlotsEngine.Xml;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SlotsEngine.Domain;
using System.Threading;
using System.Linq;

namespace SlotsConsole
{
	internal class Program
	{
		static void Main()
		{
			//SinglePlayer();
			MultiPlayer();
		}

		static void SinglePlayer()
		{
			var gamesToPlay = Properties.Settings1.Default.GamesToPlay;
			var player = ConsolePlayerFactory.CreatePlayer();
			var playContext = ConsolePlayContextFactory.CreatePlayContext(player);
			ConsoleWriter.WritePlayerInfo(gamesToPlay, playContext.Player);
			GamePlayer(playContext, gamesToPlay);
			ConsoleWriter.WriteFinalMessage(playContext);
			ConsoleWriter.PressAnyKeyToEnd();
		}

		static void MultiPlayer()
		{
			var players = ConsolePlayerFactory.CreatePlayers();
			var playContexts = ConsolePlayContextFactory.CreatePlayContexts(players);
			var gamesToPlay = Properties.Settings1.Default.GamesToPlay;
			ConsoleWriter.WritePlayersInfo(gamesToPlay, players);

			var threads = new List<Thread>();
			foreach (var playContext in playContexts)
			{
				var thread = new Thread(() => GamePlayer(playContext, gamesToPlay))
				{
					IsBackground = true
				};
				threads.Add(thread);
				thread.Start();
			}
			while (threads.Any(t => t.IsAlive)) { }

			ConsoleWriter.WriteFinalMessages(playContexts);
			ConsoleWriter.PressAnyKeyToEnd();
		}

		static void GamePlayer(IPlayContext playContext, int gamesToPlay)
		{
			for (var i = 0; i < gamesToPlay; i++)
			{
				var playOutcome = ConsoleGamePlayer.PlayGame(playContext);
				if (!(playOutcome is IPlayGameOutcome))
				{
					break;
				}
			}
		}
	}
}
