using SlotsEngine.Machine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SlotsEngine.Xml
{
	public class SlotMachineFactoryFromXml
	{
		public SlotMachine CreateSlotMachineFromXml(XDocument document)
		{
			var slotMachineLoader = new SlotMachineLoader();

			var betInfofactory = new BetInfoFactoryFromXml();
			slotMachineLoader.BetInfo = betInfofactory.CreateBetInfo(document);

			var visibleAreaFactory = new VisibleAreaFactoryFromXml();
			slotMachineLoader.VisibleArea = visibleAreaFactory.CreateVisibleArea(document);

			var paylinesFactory = new PaylinesFactoryFromXml();
			slotMachineLoader.Paylines = paylinesFactory.CreatePaylines(document);

			var symbolsFactory = new SymbolSetFactoryFromXml();
			slotMachineLoader.SymbolSet = symbolsFactory.CreateSymbols(document);

			var reelsFactory = new ReelsFactoryFromXml();
			slotMachineLoader.Reels = reelsFactory.CreateReels(document);

			var payTableFactory = new PayTableFactoryFromXml();
			slotMachineLoader.PayTable = payTableFactory.CreatePayTable(document);

			var slotMachine = SlotMachine.CloneSlotMachine(slotMachineLoader);
			return slotMachine;
		}
		class SlotMachineLoader : ISlotMachine
		{
			public IBetInfo BetInfo { get; set; }
			public IVisibleArea VisibleArea { get; set; }
			public IPaylines Paylines { get; set; }
			public ISymbolSet SymbolSet { get; set; }
			public IReels Reels { get; set; }
			public IPayTable PayTable { get; set; }
		}
	}
}
