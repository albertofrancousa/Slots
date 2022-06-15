using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SlotsEngine.AutoGenXmlTest
{
	public class GameFactory
	{
		public static Game LoadGameDefinition()
		{
			var mySerializer = new XmlSerializer(typeof(Game));
			using (var myFileStream = new FileStream(@".\Data\GameDefinition.xml", FileMode.Open))
			{
				var game = (Game)mySerializer.Deserialize(myFileStream);
				return game;
			}
		}
	}
}
