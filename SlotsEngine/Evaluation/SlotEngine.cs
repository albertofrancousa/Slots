using SlotsEngine.Domain;
using SlotsEngine.Machine;
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
			var slotMachine = playContext.SlotMachine;

			var generator = playContext.Generator;
			var visibleArea = slotMachine.VisibleArea;
			var reels = slotMachine.Reels;
			var viewArea = ReelSetSpinner.SpinReels(generator, visibleArea, reels);

			var paylines = slotMachine.Paylines;
			var viewOfPaylines = ViewOfPaylines.CreateViewOfPaylines(viewArea, paylines);

			// return the payout
			var paylineViews = viewOfPaylines.PaylineViews;
			var pays = slotMachine.PayTable.Pays;
			var payouts = PlayEvaluator.EvaluatePayoutOnPaylineViews(paylineViews, pays);
			//var payouts = GetSamplePayouts(slotMachine);


			var playOutcome = new PlayOutcome(viewArea, payouts);
			return playOutcome;
		}

		//private static List<IPayout> GetSamplePayouts(ISlotMachine slotMachine)
		//{
		//	var payline1 = slotMachine.Paylines.Items.First();
		//	var pay1 = slotMachine.PayTable.Pays.First();
		//	var payout1 = new Payout(payline1, pay1);

		//	var payline2 = slotMachine.Paylines.Items.Last();
		//	var pay2 = slotMachine.PayTable.Pays.Last();
		//	var payout2 = new Payout(payline2, pay2);

		//	var payouts = new List<IPayout> { payout1, payout2 };
		//	return payouts;
		//}
	}
	public class PlayEvaluator
	{
		public static IEnumerable<IPayout> EvaluatePayoutOnPaylineViews(IList<IPaylineView> paylineViews, IEnumerable<IPay> pays)
		{
			var payouts = new List<IPayout>();

			foreach (var pay in pays)
			{
				var matchDefinitions = pay.ExactMatch.Count;
				for (var paylineIndex = 0; paylineIndex < matchDefinitions; paylineIndex++)
				{


					..... count the number of matches ... create more classes


					for (var matchIndex = 0; matchIndex < matchDefinitions; matchIndex++)
					{
						var matchSymbol = pay.ExactMatch[matchIndex];

						var paylineView = paylineViews[paylineIndex];
						var column = matchIndex;
						var paylineSymbol = paylineView.Symbols[column];
						if (matchSymbol.Equals(paylineSymbol))
						{
							var payline = paylineView.Payline;
							var payout = new Payout(payline, pay);
							payouts.Add(payout);
						}
					}

				}
			}

			return payouts;
		}
	}
}
