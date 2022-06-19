namespace SlotsEngine.Domain
{
	public interface IPlayer
	{
		string Name { get; }

		IAccount Account { get; }

		int BetAmount { get; }
	}
}
