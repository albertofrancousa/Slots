using SlotsEngine.Evaluation;
using System.Collections.Generic;

namespace SlotsEngine.Domain
{
	public class Account : IAccount
	{
		private static readonly object _balanceLock = new object();
		private readonly List<int> _transactions = new List<int>();

		public int Balance { get; private set; }

		internal Account(int initialBalance)
		{
			Balance = initialBalance;
			_transactions.Add(initialBalance);
		}

		public void Deposit(int amount)
		{
			lock (_balanceLock)
			{
				Balance += amount;
				_transactions.Add(amount);
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
					_transactions.Add(-amount);
				}
				return sufficientFunds;
			}
		}
	}
}
