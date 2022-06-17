namespace SlotsEngine.Domain
{
	public class PlayStats
	{
		public int GamesPlayed { get; private set; }
		public int TotalAmountBet { get; private set; }
		public int MinimumBet { get; private set; }
		public int MaximumBet { get; private set; }
		public int TotalPayout { get; private set; }
		public int MinimumPayout { get; private set; }
		public int MaximumPayout { get; private set; }
		internal void UpdateStats(int betAmount, int payout)
		{
			GamesPlayed++;

			if (GamesPlayed == 1)
			{
				MinimumBet = MaximumBet = betAmount;
				MinimumPayout = MaximumPayout = payout;
			}
			else
			{
				MinimumBet = betAmount < MinimumBet ? betAmount : MinimumBet;
				MaximumBet = betAmount > MaximumBet ? betAmount : MaximumBet;
				MinimumPayout = payout < MinimumPayout ? payout : MinimumPayout;
				MinimumPayout = payout > MaximumPayout ? payout : MaximumPayout;
			}

			TotalAmountBet += betAmount;
			TotalPayout += payout;
		}
	}
}
