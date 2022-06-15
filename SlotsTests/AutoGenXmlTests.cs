using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlotsEngine.AutoGenXmlTest;
using System;

namespace SlotsTests
{
	[TestClass]
	public class AutoGenXmlTests
	{
		[TestMethod]
		public void LoadGameDefinitionTest()
		{
			var game = GameFactory.LoadGameDefinition();
			Assert.IsNotNull(game);
			Assert.AreEqual("BasicSlotGame", game.name);
			Assert.AreEqual("baseSymbols", game.Symbols.name);
			Assert.AreEqual("King", game.Symbols.Symbol[1].name);
		}
	}
}
