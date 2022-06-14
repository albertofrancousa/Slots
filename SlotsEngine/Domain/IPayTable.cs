using System.Collections.Generic;

namespace SlotsEngine.Domain
{
	public interface IPayTable
	{
		string Name { get; }

		IEnumerable<IPay> Pays { get; }
	}
}
