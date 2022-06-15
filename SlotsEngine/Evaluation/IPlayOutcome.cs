using System.Collections.Generic;

namespace SlotsEngine.Evaluation
{
	public interface IPlayOutcome
	{
		IViewArea ViewArea { get; }

		int WinAmount { get; }

		IEnumerable<IPayout> Payouts { get; }
	}
}
