using SlotsEngine.Evaluation;
using SlotsEngine.Machine;

namespace SlotsEngine.Domain
{
	public interface IPlayContext
	{
		int BetAmount { get; }

		IGenerator Generator { get; }

		IPlayer Player { get; }

		ISlotMachine SlotMachine { get; }

		int GameNumber { get; }

		void SetPlayerContext(IPlayer player, int betAmount);
	}
}
