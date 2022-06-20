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
		private static readonly bool _showLosses = Properties.Settings1.Default.ShowLosses;

		public static IPlayOutcome PlayGame(IPlayContext playContext)
		{

			var playOutcome = SlotEngine.Play(playContext);

			switch (playOutcome)
			{
				case IPlayGameOutcome playGameOutcome:
					if (playGameOutcome.WinAmount > 0 || _showLosses)
					{
						ConsoleWriter.WritePlayOutcome(playContext, playGameOutcome);
					}
					break;

				case IInsufficientFundsOutcome _:
					ConsoleWriter.WriteInsufficientFundsMessage(playContext);
					break;

				case IPlayExceptionOutcome exceptionOutcome:
					ConsoleWriter.WriteExceptionMessage(exceptionOutcome.Exception);
					break;
			}

			return playOutcome;
		}
	}
}
