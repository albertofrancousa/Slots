namespace SlotsEngine.Domain
{
	public interface IPlayer
	{
		string Name { get; }

		IAccount Account { get; }

		int DefaultBetAmount { get; }

		int CurrentBetAmount { get; }

		void UpdateCurrentBetAmount(int betAmount);

		void ResetCurrentBetAmount();
	}
}
