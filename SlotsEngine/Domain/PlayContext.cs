using SlotsEngine.Evaluation;
using SlotsEngine.Machine;

namespace SlotsEngine.Domain
{
	public class PlayerContext : IPlayContext
	{
		public ISlotMachine SlotMachine { get; }

		public IGenerator Generator { get; }

		public IPlayer Player { get; private set; }

		public PlayStats PlayStats { get; } = new PlayStats();

		public PlayerContext(IPlayer player, ISlotMachine slotMachine, IGenerator generator)
		{
			SlotMachine = slotMachine;
			Generator = generator;
			Player = player;
		}

		public bool WithdrawBet()
		{
			var betAmount = SlotMachine.BetInfo.Amount;
			var hasSufficientFunds = Player.Account.TryWithdraw(betAmount);
			return hasSufficientFunds;
		}

		public void DepositPayout(int payout)
		{
			var betAmount = SlotMachine.BetInfo.Amount;
			PlayStats.UpdateStats(betAmount, payout);
			Player.Account.Deposit(payout);
		}

		public void RefundBet()
		{
			var betAmount = SlotMachine.BetInfo.Amount;
			Player.Account.Deposit(betAmount);
		}
	}
}
