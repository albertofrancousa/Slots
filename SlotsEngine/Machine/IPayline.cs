using System.Collections.Generic;

namespace SlotsEngine.Machine
{
	public interface IPayline
	{
		string Name { get; }
		IList<int> Offsets { get; }
	}
}
