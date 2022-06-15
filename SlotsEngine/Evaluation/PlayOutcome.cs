using System.Collections.Generic;

namespace SlotsEngine.Evaluation
{
	public class PlayOutcome : IPlayOutcome
	{
		public IViewArea ViewArea { get; }

		public int WinAmount { get; }

		public IEnumerable<IPayout> Payouts { get; }

		public PlayOutcome(IViewArea viewArea, IEnumerable<IPayout> payouts)
		{
			ViewArea = viewArea;
			Payouts = payouts;

			foreach(var payout in payouts)
			{
				WinAmount += payout.Pay.Amount;
			}
		}
	}
}
