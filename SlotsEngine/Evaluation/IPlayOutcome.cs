namespace SlotsEngine.Evaluation
{
	public interface IPlayOutcome
	{
		int BetAmount { get; }

		IPayout Payout { get; }

		IViewArea ViewArea { get; }
	}
}
