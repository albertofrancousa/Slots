using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlotsEngine.Machine;

namespace SlotsTests
{
	[TestClass]
	public class DomainTests
	{
		[TestMethod]
		public void CreateSymbol()
		{
			var name = "Ace";
			var ace = SymbolFactory.CreateSymbol(name);
			Assert.AreEqual(name, ace.Name);

			var aceCopy = SymbolFactory.CreateSymbol(name);
			Assert.AreEqual(ace, aceCopy);
		}
	}
}
