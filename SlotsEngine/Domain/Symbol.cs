using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotsEngine.Domain
{
	public class Symbol : ISymbol
	{
		public string Name { get; }

		public Symbol(string name)
		{
			Name = name;
		}
	}
}
