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

		void SetPlayerInContext(IPlayer player);

		bool WithdrawBet();

		void DepositPayout(int payout);

		void RefundBet();
	}
}
