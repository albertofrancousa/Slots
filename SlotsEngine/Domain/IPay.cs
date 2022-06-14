using System.Collections.Generic;

namespace SlotsEngine.Domain
{
	public interface IPay
	{
		IEnumerable<ISymbol> ExactMatch { get; }

		int Amount { get; }
	}
}
