using System.Collections.Generic;

namespace SlotsEngine.Machine
{
	public interface IPay
	{
		IEnumerable<ISymbol> ExactMatch { get; }

		int Amount { get; }
	}
}
