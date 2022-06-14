using SlotsEngine.Domain;
using System.Collections.Generic;

namespace SlotsEngine.Evaluation
{
	public class ViewColumn : IViewColumn
	{
		public IList<ISymbol> Symbols { get; }
		public ViewColumn(IList<ISymbol> symbols)
		{
			Symbols = symbols;
		}
	}
}
