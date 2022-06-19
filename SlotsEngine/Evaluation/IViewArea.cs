using SlotsEngine.Machine;
using System.Collections.Generic;

namespace SlotsEngine.Evaluation
{
	public interface IViewArea
	{
		IVisibleArea VisibleArea { get; }

		IList<IViewColumn> ViewColumns { get; }

		IList<IViewRow> ViewRows { get; }
	}
}
