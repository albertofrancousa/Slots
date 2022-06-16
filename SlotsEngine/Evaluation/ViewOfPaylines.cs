using SlotsEngine.Machine;
using System.Collections.Generic;

namespace SlotsEngine.Evaluation
{
	public class ViewOfPaylines
	{
		public IViewArea ViewArea { get; }
		public IPaylines Paylines { get; }
		public IList<IPaylineView> PaylineViews { get; } = new List<IPaylineView>();
		private ViewOfPaylines(IViewArea viewArea, IPaylines paylines, IList<IPaylineView> paylineItemViews)
		{
			ViewArea = viewArea;
			Paylines = paylines;
			PaylineViews = paylineItemViews;
		}
		public static ViewOfPaylines CreateViewOfPaylines(IViewArea viewArea, IPaylines paylines)
		{
			var paylineViews = new List<IPaylineView>();

			foreach (var payline in paylines.Items)
			{
				var symbolsOnPayline = GetSymbolsOnPayline(viewArea, payline);
				var viewPayline = new PaylineView(payline, symbolsOnPayline);
				paylineViews.Add(viewPayline);
			}

			var paylinesView = new ViewOfPaylines(viewArea, paylines, paylineViews);
			return paylinesView;
		}
		private static IList<ISymbol> GetSymbolsOnPayline(IViewArea viewArea, IPayline payline)
		{
			var symbolsOnPayline = new List<ISymbol>();

			int columns = viewArea.VisibleArea.Columns;
			for (var column = 0; column < columns; column++)
			{
				var viewColumn = viewArea.ViewColumns[column];
				var symbolOnViewColumn = GetSymbolOnViewColumn(viewColumn, payline);
				symbolsOnPayline.Add(symbolOnViewColumn);
			}

			return symbolsOnPayline;
		}
		private static ISymbol GetSymbolOnViewColumn(IViewColumn viewColumn, IPayline payline)
		{
			var columnOffset = payline.Offsets[viewColumn.Index];
			var symbol = viewColumn.Symbols[columnOffset];
			return symbol;
		}
	}
}
