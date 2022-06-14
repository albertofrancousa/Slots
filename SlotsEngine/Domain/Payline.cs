using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SlotsEngine.Domain
{
	public class Payline : IPayline
	{
		public string Name { get; }

		public IList<int> Offsets { get; }

		public Payline(string name, IList<int> offsets)
		{
			Name = name;
			Offsets = offsets;
		}
	}
}
