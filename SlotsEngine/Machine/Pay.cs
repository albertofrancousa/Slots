using System.Collections.Generic;

namespace SlotsEngine.Machine
{
	public class Pay : IPay
	{
		public IList<ISymbol> ExactMatch { get; }

		public int Amount { get; }

		public Pay(IList<ISymbol> symbols, int amount)
		{
			ExactMatch = symbols;
			Amount = amount;
		}
	}
}
