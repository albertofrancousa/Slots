using System.Collections.Generic;

namespace SlotsEngine.Machine
{
	public interface IReels
	{
		string Name { get; }
		IEnumerable<IReel> Items { get; }
	}
}
