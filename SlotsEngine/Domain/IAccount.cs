namespace SlotsEngine.Domain
{
	public interface IAccount
	{
		int Balance { get; }

		int Deposit(int amount);

		int Withdraw(int amount);

		bool HasFundsForAmount(int amount);
	}
}
