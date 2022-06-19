using SlotsEngine.Machine;
using System.Collections.Generic;

namespace SlotsEngine.Evaluation
{
	public class PaylineView : IPaylineView
	{
		public IPayline Payline { get; }
		public IList<ISymbol> Symbols { get; }
		public PaylineView(IPayline payline, IList<ISymbol> symbols)
		{
			Payline = payline;
			Symbols = symbols;
		}
	}
}
