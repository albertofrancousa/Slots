using System.Collections.Generic;

namespace SlotsEngine.Evaluation
{
	public class GamePlayOutcome : IPlayGameOutcome
	{
		public IViewArea ViewArea { get; }

		public int WinAmount { get; }

		public IEnumerable<IPayout> Payouts { get; }

		public GamePlayOutcome(IViewArea viewArea, IEnumerable<IPayout> payouts)
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
