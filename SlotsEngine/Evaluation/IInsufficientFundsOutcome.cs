using SlotsEngine.Domain;

namespace SlotsEngine.Evaluation
{
	public interface IInsufficientFundsOutcome : IPlayOutcome
	{
		IPlayer Player { get; }
	}
}
