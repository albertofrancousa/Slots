using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlotsEngine.Domain;
using SlotsEngine.Evaluation;
using SlotsEngine.Machine;
using SlotsEngine.Xml;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace SlotsTests
{
	[TestClass]
	public class EvaluationTests
	{
		private IPlayGameOutcome _playOutcome;

		[TestInitialize]
		public void GetPlayOutcome()
		{
			var player = Player.CreatePlayer("Alberto", 1500, 100);
			var playContext = GetPlayContext();
			playContext.SetPlayerInContext(player);
			var playOutcome = SlotEngine.Play(playContext);
			if (playOutcome is IPlayGameOutcome gameOutcome)
			{
				_playOutcome = gameOutcome;
			}
			else
			{
				throw new Exception("Cannot create play game outcome.");
			}
		}

		public IPlayContext GetPlayContext()
		{
			var slotMachine = GetSlotMachine();
			var generator = new Generator();
			var playContext = new PlayContext(slotMachine, generator);
			return playContext;
		}

		private ISlotMachine GetSlotMachine()
		{
			const string GameDefinitionPath = @".\Data\GameDefinition.xml";
			var slotMachineFactory = new SlotMachineFactoryFromXml();
			var document = XDocument.Load(GameDefinitionPath);
			var slotMachine = slotMachineFactory.CreateSlotMachineFromXml(document);
			return slotMachine;
		}

		[TestMethod]
		public void RowsOfSymbolsOnViewAreaTest()
		{
			var columnsCount = _playOutcome.ViewArea.VisibleArea.Columns;
			var rowsCount = _playOutcome.ViewArea.VisibleArea.Rows;
			var viewColumns = _playOutcome.ViewArea.ViewColumns;
			var viewRows = _playOutcome.ViewArea.ViewRows;

			var topLeftSymbolFromColumn = viewColumns[0].Symbols[0];
			var topLeftSymbolFromRow = viewRows[0].Symbols[0];
			Assert.AreSame(topLeftSymbolFromColumn, topLeftSymbolFromRow);

			var topRightSymbolFromColumn = viewColumns[columnsCount - 1].Symbols[0];
			var topRightSymbolFromRow = viewRows[0].Symbols[columnsCount - 1];
			Assert.AreSame(topRightSymbolFromColumn, topRightSymbolFromRow);

			var bottomLeftSymbolFromColumn = viewColumns[0].Symbols[rowsCount - 1];
			var bottomLeftSymbolFromRow = viewRows[rowsCount - 1].Symbols[0];
			Assert.AreSame(bottomLeftSymbolFromColumn, bottomLeftSymbolFromRow);

			var bottomRightSymbolFromColumn = viewColumns[columnsCount - 1].Symbols[rowsCount - 1];
			var bottomRightSymbolFromRow = viewRows[rowsCount - 1].Symbols[columnsCount - 1];
			Assert.AreSame(bottomRightSymbolFromColumn, bottomRightSymbolFromRow);
		}
	}
}
