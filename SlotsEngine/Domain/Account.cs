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

		public void Deposit(int amount)
		{
			lock (_balanceLock)
			{
				Balance += amount;
			}
		}

		public bool TryWithdraw(int amount)
		{
			lock (_balanceLock)
			{
				bool sufficientFunds = Balance >= amount;
				if (sufficientFunds)
				{
					Balance -= amount;
				}
				return sufficientFunds;
			}
		}
	}
}
