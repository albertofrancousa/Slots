using SlotsEngine.Machine;
using System.Collections;
using System.Linq;
using System.Xml.Linq;

namespace SlotsEngine.Xml
{
	public class ReelsFactoryFromXml : IReelsFactory
	{
		public IReels CreateReels(XDocument document)
		{
			var elements = document.Root.Elements("Reels");
			var element = elements.FirstOrDefault();

			var name = element.Attribute("name").Value;
			var reels = new Reels(name);

			var reelFactory = new ReelFactoryFromXml();
			var reelElements = element.Elements("Reel");

			foreach (var reelElement in reelElements)
			{
				var reel = reelFactory.CreateReel(reelElement);
				reels.AddReel(reel);
			}

			return reels;
		}
	}
}
