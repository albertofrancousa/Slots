using System.Collections.Generic;

namespace SlotsEngine.Domain
{
	public interface IReels
	{
		string Name { get; }
		IEnumerable<IReel> Items { get; }
	}
}
