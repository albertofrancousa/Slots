using SlotsEngine.Domain;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotsEngine.Evaluation
{
	public class SlotPlayer
	{
		public IPlayOutcome Play(ISlotMachine slotMachine, IGenerator generator, int betAmount)
		{
			// verify balance and deduct bet amount
			// spin the reel set
			var viewArea = ReelSetSpinner.SpinReels(generator, slotMachine.VisibleArea, slotMachine.Reels);
			// evaluate the view area
			// return the outcome
			var payout = new Payout(null, null);

			var playOutcome = new PlayOutcome(betAmount, payout, viewArea);
			return playOutcome;
		}
	}
}
