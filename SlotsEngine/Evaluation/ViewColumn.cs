using SlotsEngine.Machine;
using System.Collections.Generic;

namespace SlotsEngine.Evaluation
{
	public class ViewColumn : IViewColumn
	{
		public int Index { get; }

		public IList<ISymbol> Symbols { get; }

		public ViewColumn(int index, IList<ISymbol> symbols)
		{
			Index = index;
			Symbols = symbols;
		}
	}
}
