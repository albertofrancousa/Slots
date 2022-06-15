using System.Collections.Generic;

namespace SlotsEngine.Machine
{
	public class Pay : IPay
	{
		public IEnumerable<ISymbol> ExactMatch { get; }

		public int Amount { get; }

		public Pay(IEnumerable<ISymbol> symbols, int amount)
		{
			ExactMatch = symbols;
			Amount = amount;
		}
	}
}
