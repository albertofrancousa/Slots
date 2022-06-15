using SlotsEngine.Machine;
using System.Collections.Generic;

namespace SlotsEngine.Evaluation
{
	public interface IViewColumn
	{
		IList<ISymbol> Symbols { get; }
	}
}
