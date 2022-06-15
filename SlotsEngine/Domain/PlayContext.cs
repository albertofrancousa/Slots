using SlotsEngine.Evaluation;
using SlotsEngine.Machine;

namespace SlotsEngine.Domain
{
	public class PlayContext : IPlayContext
	{
		public ISlotMachine SlotMachine { get; }

		public IGenerator Generator { get; }

		public IPlayer Player { get; private set; }

		public int BetAmount { get; private set; }

		public int GameNumber { get; private set; }

		public PlayContext(SlotMachine slotMachine, IGenerator generator)
		{
			SlotMachine = slotMachine;
			Generator = generator;
		}

		public void SetPlayerContext(IPlayer player, int betAmount)
		{
			Player = player;
			BetAmount = betAmount;
			Player.Account.Withdraw(betAmount);
			GameNumber++;
			Generator.Clear();
		}
	}
}
