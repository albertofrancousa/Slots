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

		public int BetAmount { get; }

		private Player(string name, int initialBalance, int defaultBetAmount)
		{
			Name = name;
			Account = new Account(initialBalance);
			BetAmount = defaultBetAmount;
		}

		public static IPlayer CreatePlayer(string name, int initialBalance, int defaultBetAmount)
		{
			var player = new Player(name, initialBalance, defaultBetAmount);
			return player;
		}
	}
}
