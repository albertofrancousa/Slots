using System.Collections.Generic;

namespace SlotsEngine.Machine
{
	public interface IPaylines
	{
		string Name { get; }

		IEnumerable<IPayline> Items { get; }
	}
}
