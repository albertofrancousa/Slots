using System.Collections.Generic;

namespace SlotsEngine.Domain
{
	public interface IPaylines
	{
		string Name { get; }

		IEnumerable<IPayline> Items { get; }
	}
}
