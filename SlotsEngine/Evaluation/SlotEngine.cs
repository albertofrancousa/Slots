using SlotsEngine.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotsEngine.Evaluation
{
	public static class SlotEngine
	{
		public static IPlayOutcome Play(IPlayContext playContext)
		{
			IPlayOutcome playOutcome;

			if (playContext.WithdrawBet())
			{
				playOutcome = TryPlayGame(playContext);
				if(playOutcome is IPlayGameOutcome playGameOutcome)
				{
					playContext.DepositPayout(playGameOutcome.WinAmount);
				}
			}
			else
			{
				var insufficientFundsOutcome = new InsufficientFundsOutcome(playContext.Player);
				playOutcome = insufficientFundsOutcome;
			}

			return playOutcome;
		}

		private static IPlayOutcome TryPlayGame(IPlayContext playContext)
		{
			IPlayOutcome playOutcome;
			try
			{
				playOutcome = PlayGame(playContext);
			}
			catch (Exception exception)
			{
				playContext.RefundBet();
				playOutcome = new PlayExceptionOutcome(exception);
			}
			return playOutcome;
		}

		private static IPlayGameOutcome PlayGame(IPlayContext playContext)
		{
			var slotMachine = playContext.SlotMachine;

			var generator = playContext.Generator;
			var visibleArea = slotMachine.VisibleArea;
			var reels = slotMachine.Reels;
			var viewArea = ReelSetSpinner.SpinReels(generator, visibleArea, reels);

			var paylines = slotMachine.Paylines;
			var viewOfPaylines = ViewOfPaylines.CreateViewOfPaylines(viewArea, paylines);

			var paylineViews = viewOfPaylines.PaylineViews;
			var pays = slotMachine.PayTable.Pays;
			_ = PaylineEvaluator.PaylineViewsMatchPays(paylineViews, pays, out IList<IPayout> payouts);

			var playOutcome = new GamePlayOutcome(viewArea, payouts);
			return playOutcome;
		}
	}
}
