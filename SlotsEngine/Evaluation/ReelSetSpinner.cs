using SlotsEngine.Machine;
using System.Collections.Generic;
using System.Linq;

namespace SlotsEngine.Evaluation
{
	public static class ReelSetSpinner
	{
		public static IViewArea SpinReels(IGenerator generator, IVisibleArea visibleArea, IReels reels)
		{
			var viewColumns = new List<IViewColumn>();
			var reelsCount = reels.Items.Count();

			for (var reelIndex = 0; reelIndex < reelsCount; reelIndex++)
			{
				var reel = reels.Items[reelIndex];
				var stop = generator.NextValue(reel.Length);
				var symbols = GetViewSymbols(visibleArea.Rows, reel, stop);
				var viewColumn = new ViewColumn(reelIndex, symbols);
				viewColumns.Add(viewColumn);
			}

			var viewArea = new ViewArea(visibleArea, viewColumns);
			return viewArea;
		}

		private static IList<ISymbol> GetViewSymbols(int length, IReel reel, int stop)
		{
			var symbols = new List<ISymbol>();

			for (var i = 0; i < length; i++)
			{
				var index = (i + stop) % reel.Length;
				var symbol = reel.Symbols[index];
				symbols.Add(symbol);
			}

			return symbols;
		}
	}
}
