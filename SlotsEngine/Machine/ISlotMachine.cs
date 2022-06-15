using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotsEngine.Machine
{
	public interface ISlotMachine
	{
		IBetInfo BetInfo { get; }
		IVisibleArea VisibleArea { get; }
		IPaylines Paylines { get; }
		ISymbolSet SymbolSet { get; }
		IReels Reels { get; }
		IPayTable PayTable { get; }
	}
}
