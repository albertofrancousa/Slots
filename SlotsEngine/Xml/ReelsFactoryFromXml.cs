using SlotsEngine.Domain;
using System.Collections;
using System.Xml.Linq;

namespace SlotsEngine.Xml
{
	public class ReelsFactoryFromXml : IReelsFactory
	{
		public IReels CreateReels(XElement element)
		{
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
