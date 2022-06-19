using SlotsEngine.Evaluation;
using SlotsEngine.Machine;

namespace SlotsEngine.Domain
{
	public class PlayContext : IPlayContext
	{
		public ISlotMachine SlotMachine { get; }

		public IGenerator Generator { get; }

		public IPlayer Player { get; private set; }

		public PlayStats PlayStats { get; } = new PlayStats();

		public PlayContext(ISlotMachine slotMachine, IGenerator generator)
		{
			SlotMachine = slotMachine;
			Generator = generator;
		}

		public void SetPlayerInContext(IPlayer player)
		{
			Player = player;
			Generator.Clear();
		}

		public bool WithdrawBet()
		{
			var betAmount = Player.BetAmount;
			var hasSufficientFunds = Player.Account.TryWithdraw(betAmount);
			return hasSufficientFunds;
		}

		public void DepositPayout(int payout)
		{
			var betAmount = Player.BetAmount;
			PlayStats.UpdateStats(betAmount, payout);
			Player.Account.Deposit(payout);
		}

		public void RefundBet()
		{
			var betAmount = Player.BetAmount;
			Player.Account.Deposit(betAmount);
		}
	}
}
