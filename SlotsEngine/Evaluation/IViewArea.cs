using SlotsEngine.Domain;
using System.Collections.Generic;

namespace SlotsEngine.Evaluation
{
	public interface IViewArea
	{
		IVisibleArea VisibleArea { get; }
		IList<IViewColumn> ViewColumns { get; }
	}
}
