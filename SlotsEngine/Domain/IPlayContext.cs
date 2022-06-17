using SlotsEngine.Evaluation;
using SlotsEngine.Machine;

namespace SlotsEngine.Domain
{
	public interface IPlayContext
	{
		ISlotMachine SlotMachine { get; }

		IGenerator Generator { get; }

		IPlayer Player { get; }

		PlayStats PlayStats { get; }

		bool CanSetPlayerContext(IPlayer player);

		void UpdatePayout(int payout);
	}
}
