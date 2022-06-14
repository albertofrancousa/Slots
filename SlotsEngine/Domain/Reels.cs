using System.Collections.Generic;

namespace SlotsEngine.Domain
{
	public class Reels : IReels
	{
		private readonly List<IReel> _reels = new List<IReel>();

		public string Name { get; }

		public IEnumerable<IReel> Items => _reels;

		public Reels(string name)
		{
			Name = name;
		}

		public void AddReel(IReel reel)
		{
			_reels.Add(reel);
		}
	}
}
