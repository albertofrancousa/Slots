using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotsEngine.Domain
{
	public class Player : IPlayer
	{
		public string Name { get; }

		public IAccount Account { get; }

		private Player(string name, int initialBalance)
		{
			Name = name;
			Account = new Account(initialBalance);
		}

		public static IPlayer CreatePlayer(string name, int initialBalance)
		{
			var player = new Player(name, initialBalance);
			return player;
		}
	}
}
