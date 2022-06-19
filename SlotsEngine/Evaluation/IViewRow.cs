using SlotsEngine.Machine;
using System.Collections.Generic;

namespace SlotsEngine.Evaluation
{
	public interface IViewRow
	{
		int Index { get; }

		IList<ISymbol> Symbols { get; }
	}
}
