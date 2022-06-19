using SlotsEngine.Machine;
using System.Collections.Generic;

namespace SlotsEngine.Evaluation
{
	public class ViewRow : IViewRow
	{
		public int Index { get; }

		public IList<ISymbol> Symbols { get; }

		public ViewRow(int index, IList<ISymbol> symbols)
		{
			Index = index;
			Symbols = symbols;
		}
	}
}
