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

		public PlayContext(SlotMachine slotMachine, IGenerator generator)
		{
			SlotMachine = slotMachine;
			Generator = generator;
		}

		public bool CanSetPlayerContext(IPlayer player)
		{
			var betAmount = player.CurrentBetAmount;
			var hasSufficientFunds = player.Account.HasFundsForAmount(betAmount);
			Player = player;
			Generator.Clear();
			return hasSufficientFunds;
		}

		public void UpdatePayout(int payout)
		{
			var betAmount = Player.CurrentBetAmount;
			var hasSufficientFunds = Player.Account.HasFundsForAmount(betAmount);
			if (hasSufficientFunds)
			{
				Player.Account.Withdraw(betAmount);
				Player.Account.Deposit(payout);
			}
			else
			{
				throw new System.Exception();
			}
			PlayStats.UpdateStats(betAmount, payout);
		}
	}
}
