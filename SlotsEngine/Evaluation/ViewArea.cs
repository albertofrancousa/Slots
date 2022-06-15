using SlotsEngine.Machine;
using System.Collections.Generic;

namespace SlotsEngine.Evaluation
{
	public class ViewArea : IViewArea
	{
		public IVisibleArea VisibleArea { get; }
		public IList<IViewColumn> ViewColumns { get; }
		public ViewArea(IVisibleArea visibleArea, IList<IViewColumn> viewColumns)
		{
			VisibleArea = visibleArea;
			ViewColumns = viewColumns;
		}
	}
}
