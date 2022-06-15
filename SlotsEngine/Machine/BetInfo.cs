namespace SlotsEngine.Machine
{
	public class BetInfo : IBetInfo
	{
		public int Amount { get; }

		public BetInfo(int amount)
		{
			Amount = amount;
		}
	}
}
