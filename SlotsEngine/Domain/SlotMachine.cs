using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotsEngine.Domain
{
	public class SlotMachine : ISlotMachine
	{
		public IBetInfo BetInfo { get; private set; }
		public IVisibleArea VisibleArea { get; private set; }
		public IPaylines Paylines { get; private set; }
		public ISymbolSet SymbolSet { get; private set; }
		public IReels Reels { get; private set; }
		public IPayTable PayTable { get; private set; }

		public static SlotMachine CloneSlotMachine(ISlotMachine slotMachine)
		{
			var cloneSlotMachine = new SlotMachine
			{
				BetInfo = slotMachine.BetInfo,
				VisibleArea = slotMachine.VisibleArea,
				Paylines = slotMachine.Paylines,
				SymbolSet = slotMachine.SymbolSet,
				Reels = slotMachine.Reels,
				PayTable = slotMachine.PayTable
			};

			return cloneSlotMachine;
		}
	}
}
