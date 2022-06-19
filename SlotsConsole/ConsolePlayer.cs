using SlotsEngine.Domain;
using SlotsEngine.Evaluation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotsConsole
{
	internal static class ConsoleGamePlayer
	{
		public static IPlayOutcome PlayGame(IPlayContext playContext)
		{

			var playOutcome = SlotEngine.Play(playContext);

			switch (playOutcome)
			{
				case IPlayGameOutcome playGameOutcome:
					var showLosses = Properties.Settings1.Default.ShowLosses;
					if (playGameOutcome.WinAmount > 0 || showLosses)
					{
						ConsoleWriter.WritePlayOutcome(playContext, playGameOutcome);
						ConsoleWriter.WriteWinOutcome(playContext, playGameOutcome);
					}
					break;

				case IInsufficientFundsOutcome _:
					ConsoleWriter.WriteInsufficientFundsMessage(playContext.Player);
					break;

				case IPlayExceptionOutcome exceptionOutcome:
					ConsoleWriter.WriteExceptionMessage(exceptionOutcome.Exception);
					break;
			}

			return playOutcome;
		}
	}
}
