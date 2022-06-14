using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlotsEngine;
using SlotsEngine.AutoGenXmlTest;
using SlotsEngine.Domain;
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
			var factory = new BetInfoFactoryFromXml();
			var xdoc = XDocument.Load(GameDefinitionPath);
			var betInfo = factory.CreateBetInfo(xdoc);
			Assert.IsNotNull(betInfo);
			Assert.AreEqual(100, betInfo.Amount);
		}

		[TestMethod]
		public void CreateVisibleAreaFromXml()
		{
			var factory = new VisibleAreaFactoryFromXml();
			var xdoc = XDocument.Load(GameDefinitionPath);
			var visibleArea = factory.CreateVisibleArea(xdoc);
			Assert.AreEqual(3, visibleArea.Rows);
			Assert.AreEqual(3, visibleArea.Columns);
		}

		[TestMethod]
		public void CreatePaylinesFromXml()
		{
			var factory = new PaylinesFactoryFromXml();
			var xdoc = XDocument.Load(GameDefinitionPath);
			var paylines = factory.CreatePaylines(xdoc);
			Assert.IsNotNull(paylines);
			Assert.AreEqual("BasePayLines", paylines.Name);
			Assert.AreEqual(5, paylines.Items.Count());
		}

		[TestMethod]
		public void CreateSymbolSetFromXml()
		{
			var factory = new SymbolSetFactoryFromXml();
			var xdoc = XDocument.Load(GameDefinitionPath);
			var symbolSet = factory.CreateSymbols(xdoc);
			Assert.IsNotNull(symbolSet);
			Assert.AreEqual(6, symbolSet.Items.Count);

			var expectedKing = symbolSet.Items["King"];
			var actualKing = SymbolFactory.CreateSymbol("King");
			Assert.AreSame(expectedKing, actualKing);
		}

		[TestMethod]
		public void CreateReelsFromXml()
		{
			var factory = new ReelsFactoryFromXml();
			var xdoc = XDocument.Load(GameDefinitionPath);
			var reels = factory.CreateReels(xdoc);
			Assert.IsNotNull(reels);
			Assert.AreEqual(3, reels.Items.Count());
			Assert.AreEqual("reel2", reels.Items.ElementAt(1).Name);
		}

		[TestMethod]
		public void CreatePayTableFromXml()
		{
			var factory = new PayTableFactoryFromXml();
			var xdoc = XDocument.Load(GameDefinitionPath);
			var payTable = factory.CreatePayTable(xdoc);
			Assert.IsNotNull(payTable);
			Assert.AreEqual(6, payTable.Pays.Count());
			Assert.AreEqual(700, payTable.Pays.ElementAt(2).Amount);
		}
	}
}
