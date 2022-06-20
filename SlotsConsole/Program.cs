using SlotsEngine.Machine;
using SlotsEngine.Evaluation;
using SlotsEngine.Xml;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SlotsEngine.Domain;

namespace SlotsConsole
{
	internal class Program
	{
		static void Main()
		{
			var player = ConsolePlayerFactory.CreatePlayerInstance();
			var playContext = ConsolePlayContextFactory.CreateInstance(player);
			var gamesToPlay = Properties.Settings1.Default.GamesToPlay;

			ConsoleWriter.WritePlayerInfo(gamesToPlay, playContext.Player);

			for (var i = 0; i < gamesToPlay; i++)
			{
				var playOutcome = ConsoleGamePlayer.PlayGame(playContext);
				if (!(playOutcome is IPlayGameOutcome))
				{
					break;
				}
			}

			ConsoleWriter.WriteFinalMessage(playContext);
			ConsoleWriter.PressAnyKeyToEnd();
		}
	}
}
