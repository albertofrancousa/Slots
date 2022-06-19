using SlotsEngine.Machine;
using System.Collections.Generic;

namespace SlotsEngine.Evaluation
{
	public static class PaylineEvaluator
	{
		public static bool PaylineViewsMatchPays(IList<IPaylineView> paylineViews, IEnumerable<IPay> pays, out IList<IPayout> payouts)
		{
			List<IPayout> allPayouts = new List<IPayout>();
			foreach (var pay in pays)
			{
				if (PaylineViewsMatchPay(paylineViews, pay, out IList<IPayout> paylineViewsPayouts))
				{
					allPayouts.AddRange(paylineViewsPayouts);
				}
			}
			payouts = allPayouts;
			return payouts != null;
		}

		private static bool PaylineViewsMatchPay(IList<IPaylineView> paylineViews, IPay pay, out IList<IPayout> payouts)
		{
			payouts = null;
			for (var paylineIndex = 0; paylineIndex < pay.ExactMatch.Count; paylineIndex++)
			{
				var paylineView = paylineViews[paylineIndex];
				if (PaylineViewMatchesPay(paylineView, pay, out IPayout payout))
				{
					if (payouts is null)
					{
						payouts = new List<IPayout>();
					}
					payouts.Add(payout);
				}
			}
			return payouts != null;
		}

		private static bool PaylineViewMatchesPay(IPaylineView paylineView, IPay pay, out IPayout payout)
		{
			payout = null;
			var matchingSymbolsCount = CountMatchingSymbols(paylineView, pay);
			if (matchingSymbolsCount == pay.ExactMatch.Count)
			{
				var payline = paylineView.Payline;
				payout = new Payout(payline, pay);
			}
			return payout != null;
		}

		private static int CountMatchingSymbols(IPaylineView paylineView, IPay pay)
		{
			var matchingSymbolsCount = 0;
			for (var matchIndex = 0; matchIndex < pay.ExactMatch.Count; matchIndex++)
			{
				var matchSymbol = pay.ExactMatch[matchIndex];

				var column = matchIndex;
				var paylineSymbol = paylineView.Symbols[column];

				matchingSymbolsCount += matchSymbol.Equals(paylineSymbol) ? 1 : 0;
			}
			return matchingSymbolsCount;
		}
	}
}
