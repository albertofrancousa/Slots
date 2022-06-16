using System.Collections.Generic;

namespace SlotsEngine.Machine
{
	public interface IPay
	{
		IList<ISymbol> ExactMatch { get; }

		int Amount { get; }
	}
}
