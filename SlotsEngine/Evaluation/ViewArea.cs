using SlotsEngine.Machine;
using System.Collections.Generic;

namespace SlotsEngine.Evaluation
{
	public class ViewArea : IViewArea
	{
		public IVisibleArea VisibleArea { get; }

		public IList<IViewColumn> ViewColumns { get; }

		public IList<IViewRow> ViewRows { get; }

		public ViewArea(IVisibleArea visibleArea, IList<IViewColumn> viewColumns)
		{
			VisibleArea = visibleArea;
			ViewColumns = viewColumns;
			ViewRows = GetViewRows(visibleArea, viewColumns);
		}

		private static IList<IViewRow> GetViewRows(IVisibleArea visibleArea, IList<IViewColumn> viewColumns)
		{
			var viewRows = new List<IViewRow>();
			for (var rowNumber = 0; rowNumber < visibleArea.Rows; rowNumber++)
			{
				var viewRow = GetViewRow(rowNumber, visibleArea.Columns, viewColumns);
				viewRows.Add(viewRow);
			}
			return viewRows;
		}

		private static IViewRow GetViewRow(int rowNumber, int columns, IList<IViewColumn> viewColumns)
		{
			var symbolsOnRow = GetSymbolsOnRow(rowNumber, columns, viewColumns);
			var viewRow = new ViewRow(rowNumber, symbolsOnRow);
			return viewRow;
		}

		private static IList<ISymbol> GetSymbolsOnRow(int row, int columns, IList<IViewColumn> viewColumns)
		{
			var symbolsOnRow = new List<ISymbol>();
			for (var column = 0; column < columns; column++)
			{
				var symbol = viewColumns[column].Symbols[row];
				symbolsOnRow.Add(symbol);
			}
			return symbolsOnRow;
		}
	}
}
