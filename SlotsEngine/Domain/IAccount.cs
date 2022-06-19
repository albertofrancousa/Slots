namespace SlotsEngine.Domain
{
	public interface IAccount
	{
		int Balance { get; }

		void Deposit(int amount);

		bool TryWithdraw(int amount);
	}
}
