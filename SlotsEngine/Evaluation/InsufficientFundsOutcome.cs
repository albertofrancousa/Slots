using SlotsEngine.Domain;

namespace SlotsEngine.Evaluation
{
	public class InsufficientFundsOutcome : IInsufficientFundsOutcome
	{
		public IPlayer Player { get; }

		public InsufficientFundsOutcome(IPlayer player)
		{
			Player = player;
		}
	}
}
