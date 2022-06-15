using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlotsEngine;
using SlotsEngine.AutoGenXmlTest;
using SlotsEngine.Machine;
using SlotsEngine.Xml;
using System;
using System.Linq;
using System.Xml.Linq;

namespace SlotsTests
{
	[TestClass]
	public class LoadXmlTests
	{
		private const string GameDefinitionPath = @".\Data\GameDefinition.xml";

		[TestMethod]
		public void CreateBetInfoFromXml()
		{
			var betInfofactory = new BetInfoFactoryFromXml();
			var document = XDocument.Load(GameDefinitionPath);
			var betInfo = betInfofactory.CreateBetInfo(document);
			Assert.IsNotNull(betInfo);
			Assert.AreEqual(100, betInfo.Amount);
		}

		[TestMethod]
		public void CreateVisibleAreaFromXml()
		{
			var visibleAreaFactory = new VisibleAreaFactoryFromXml();
			var document = XDocument.Load(GameDefinitionPath);
			var visibleArea = visibleAreaFactory.CreateVisibleArea(document);
			Assert.AreEqual(3, visibleArea.Rows);
			Assert.AreEqual(3, visibleArea.Columns);
		}

		[TestMethod]
		public void CreatePaylinesFromXml()
		{
			var paylinesFactory = new PaylinesFactoryFromXml();
			var document = XDocument.Load(GameDefinitionPath);
			var paylines = paylinesFactory.CreatePaylines(document);
			Assert.IsNotNull(paylines);
			Assert.AreEqual("BasePayLines", paylines.Name);
			Assert.AreEqual(5, paylines.Items.Count());
		}

		[TestMethod]
		public void CreateSymbolSetFromXml()
		{
			var symbolsFactory = new SymbolSetFactoryFromXml();
			var document = XDocument.Load(GameDefinitionPath);
			var symbolSet = symbolsFactory.CreateSymbols(document);
			Assert.IsNotNull(symbolSet);
			Assert.AreEqual(6, symbolSet.Items.Count);

			var expectedKing = symbolSet.Items["King"];
			var actualKing = SymbolFactory.CreateSymbol("King");
			Assert.AreSame(expectedKing, actualKing);
		}

		[TestMethod]
		public void CreateReelsFromXml()
		{
			var reelsFactory = new ReelsFactoryFromXml();
			var document = XDocument.Load(GameDefinitionPath);
			var reels = reelsFactory.CreateReels(document);
			Assert.IsNotNull(reels);
			Assert.AreEqual(3, reels.Items.Count());
			Assert.AreEqual("reel2", reels.Items.ElementAt(1).Name);
		}

		[TestMethod]
		public void CreatePayTableFromXml()
		{
			var payTableFactory = new PayTableFactoryFromXml();
			var document = XDocument.Load(GameDefinitionPath);
			var payTable = payTableFactory.CreatePayTable(document);
			Assert.IsNotNull(payTable);
			Assert.AreEqual(6, payTable.Pays.Count());
			Assert.AreEqual(700, payTable.Pays.ElementAt(2).Amount);
		}
	}
}
