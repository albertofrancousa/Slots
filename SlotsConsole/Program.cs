using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SlotsConsole
{
	internal class Program
	{
		private const string GameDefinitionPath = @".\Data\GameDefinition.xml";

		static void Main(string[] args)
		{
			var xdoc = XDocument.Load(GameDefinitionPath);
			var gameElement = xdoc.Root;

		}
	}
}
