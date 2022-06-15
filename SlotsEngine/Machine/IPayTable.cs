using System.Collections.Generic;

namespace SlotsEngine.Machine
{
	public interface IPayTable
	{
		string Name { get; }

		IEnumerable<IPay> Pays { get; }
	}
}
