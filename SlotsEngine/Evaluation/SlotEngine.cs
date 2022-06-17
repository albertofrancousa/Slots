using SlotsEngine.Domain;
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

			var paylineViews = viewOfPaylines.PaylineViews;
			var pays = slotMachine.PayTable.Pays;
			_ = PaylineEvaluator.PaylineViewsMatchPays(paylineViews, pays, out IList<IPayout> payouts);

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
}
