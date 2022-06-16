using System.Collections.Generic;

namespace SlotsEngine.Machine
{
	public interface IReels
	{
		string Name { get; }

		IList<IReel> Items { get; }
	}
}
