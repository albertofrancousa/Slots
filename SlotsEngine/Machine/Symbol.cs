using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotsEngine.Machine
{
	public class Symbol : ISymbol
	{
		public string Name { get; }

		public Symbol(string name)
		{
			Name = name;
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
