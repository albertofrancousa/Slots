using System.Collections.Generic;

namespace SlotsEngine.Machine
{
	public interface IPaylines
	{
		string Name { get; }

		IList<IPayline> Items { get; }
	}
}
