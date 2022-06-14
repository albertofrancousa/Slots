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
			var xdoc = XDocument.Load(GameDefinitionPath);
			var gameElement = xdoc.Root;
			var betInfoElement = gameElement.Element("BetInfo");
			var factory = new BetInfoFactoryFromXml();
			var betInfo = factory.CreateBetInfo(betInfoElement);
			Assert.IsNotNull(betInfo);
			Assert.AreEqual(100, betInfo.Amount);
		}

		[TestMethod]
		public void CreateVisibleAreaFromXml()
		{
			var xdoc = XDocument.Load(GameDefinitionPath);
			var gameElement = xdoc.Root;
			var visibleAreaElement = gameElement.Element("VisibleArea");
			var factory = new VisibleAreaFactoryFromXml();
			var visibleArea = factory.CreateVisibleArea(visibleAreaElement);
			Assert.AreEqual(3, visibleArea.Rows);
			Assert.AreEqual(3, visibleArea.Columns);
		}

		[TestMethod]
		public void CreatePaylinesFromXml()
		{
			var xdoc = XDocument.Load(GameDefinitionPath);
			var gameElement = xdoc.Root;
			var paylinesElement = gameElement.Element("Paylines");
			var factory = new PaylinesFactoryFromXml();
			var paylines = factory.CreatePaylines(paylinesElement);
			Assert.IsNotNull(paylines);
			Assert.AreEqual("BasePayLines", paylines.Name);
			Assert.AreEqual(5, paylines.Items.Count());
		}

		[TestMethod]
		public void CreateSymbolSetFromXml()
		{
			var xdoc = XDocument.Load(GameDefinitionPath);
			var gameElement = xdoc.Root;
			var symbolsElement = gameElement.Element("Symbols");

			var factory = new SymbolSetFactoryFromXml();
			var symbolSet = factory.CreateSymbols(symbolsElement);
			Assert.IsNotNull(symbolSet);
			Assert.AreEqual(6, symbolSet.Items.Count);

			var expectedKing = symbolSet.Items["King"];
			var actualKing = SymbolFactory.CreateSymbol("King");
			Assert.AreSame(expectedKing, actualKing);
		}

		[TestMethod]
		public void CreateReelsFromXml()
		{
			var xdoc = XDocument.Load(GameDefinitionPath);
			var gameElement = xdoc.Root;
			var reelsElement = gameElement.Element("Reels");

			var factory = new ReelsFactoryFromXml();
			var reels = factory.CreateReels(reelsElement);
			Assert.IsNotNull(reels);
			Assert.AreEqual(3, reels.Items.Count());
			Assert.AreEqual("reel2", reels.Items.ElementAt(1).Name);
		}

		[TestMethod]
		public void CreatePayTableFromXml()
		{
			var xdoc = XDocument.Load(GameDefinitionPath);
			var gameElement = xdoc.Root;
			var payTableElement = gameElement.Element("PayTable");

			var factory = new PayTableFactoryFromXml();
			var payTable = factory.CreatePayTable(payTableElement);
			Assert.IsNotNull(payTable);
			Assert.AreEqual(6, payTable.Pays.Count());
			Assert.AreEqual(700, payTable.Pays.ElementAt(2).Amount);
		}
	}
}
