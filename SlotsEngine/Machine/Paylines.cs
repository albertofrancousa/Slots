using System.Collections.Generic;

namespace SlotsEngine.Machine
{
	public class Paylines : IPaylines
	{
		private readonly List<IPayline> _paylines = new List<IPayline>();

		public string Name { get; }

		public IList<IPayline> Items => _paylines;

		public Paylines(string name)
		{
			Name = name;
		}

		public void AddPayline(IPayline payline)
		{
			_paylines.Add(payline);
		}
	}
}
