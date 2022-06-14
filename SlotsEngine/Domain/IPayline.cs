using System.Collections.Generic;

namespace SlotsEngine.Domain
{
	public interface IPayline
	{
		string Name { get; }
		IList<int> Offsets { get; }
	}
}
