using SlotsEngine.Machine;
using System.Collections.Generic;

namespace SlotsEngine.Evaluation
{
	public interface IPaylineView
	{
		IPayline Payline { get; }

		IList<ISymbol> Symbols { get; }
	}
}
