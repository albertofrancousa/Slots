using SlotsEngine.Domain;
using SlotsEngine.Machine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotsEngine.Evaluation
{
	public class SlotEngine
	{
		public IPlayOutcome Play(IPlayContext playContext)
		{
			var slotMachine = playContext.SlotMachine;

			var generator = playContext.Generator;
			var visibleArea = slotMachine.VisibleArea;
			var reels = slotMachine.Reels;
			var viewArea = ReelSetSpinner.SpinReels(generator, visibleArea, reels);

			// evaluate the view area

			// return the outcome
			var payouts = GetSamplePayouts(slotMachine);

			var playOutcome = new PlayOutcome(viewArea, payouts);
			return playOutcome;
		}

		private static List<IPayout> GetSamplePayouts(ISlotMachine slotMachine)
		{
			var payline1 = slotMachine.Paylines.Items.First();
			var pay1 = slotMachine.PayTable.Pays.First();
			var payout1 = new Payout(payline1, pay1);

			var payline2 = slotMachine.Paylines.Items.Last();
			var pay2 = slotMachine.PayTable.Pays.Last();
			var payout2 = new Payout(payline2, pay2);

			var payouts = new List<IPayout> { payout1, payout2 };
			return payouts;
		}
	}
}
