using System.Collections.Generic;

namespace SlotsEngine.Machine
{
	public class PayTable : IPayTable
	{
		public string Name { get; }

		public IEnumerable<IPay> Pays { get; }

		public PayTable(string name, IEnumerable<IPay> pays)
		{
			Name = name;
			Pays = pays;
		}
	}
}
