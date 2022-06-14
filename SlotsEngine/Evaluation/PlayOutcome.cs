namespace SlotsEngine.Evaluation
{
	public class PlayOutcome : IPlayOutcome
	{
		public int BetAmount { get; }

		public IPayout Payout { get; }

		public IViewArea ViewArea { get; }

		public PlayOutcome(int betAmount, IPayout payout, IViewArea viewArea)
		{
			BetAmount = betAmount;
			Payout = payout;
			ViewArea = viewArea;
		}
	}
}
