using SlotsEngine.Evaluation;

namespace SlotsEngine.Domain
{
	public class Account : IAccount
	{
		private static readonly object _balanceLock = new object();

		public int Balance { get; private set; }

		internal Account(int initialBalance)
		{
			Balance = initialBalance;
		}

		public int Deposit(int amount)
		{
			lock (_balanceLock)
			{
				Balance += amount;
			}
			return Balance;
		}

		public int Withdraw(int amount)
		{
			lock (_balanceLock)
			{
				if (Balance < amount)
				{
					throw new InsufficientFundsException($"Insufficient account balance '{Balance}' to withdraw amount '{amount}'.");
				}
				Balance -= amount;
			}
			return Balance;
		}

		public bool HasFundsForAmount(int amount)
		{
			return Balance >= amount;
		}
	}
}
