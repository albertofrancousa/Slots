using SlotsEngine.Machine;

namespace SlotsEngine.Evaluation
{
	public interface IPayout
	{
		IPayline Payline { get; }

		IPay Pay { get; }
	}
}
