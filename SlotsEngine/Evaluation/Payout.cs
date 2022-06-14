using SlotsEngine.Domain;

namespace SlotsEngine.Evaluation
{
	public class Payout : IPayout
	{
		public IPayline Payline { get; }
		public IPay Pay { get; }
		public Payout(IPayline payline, IPay pay)
		{
			Payline = payline;
			Pay = pay;
		}
	}
}
