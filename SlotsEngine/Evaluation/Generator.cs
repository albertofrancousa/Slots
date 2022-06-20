using System;
using System.Collections;
using System.Collections.Generic;

namespace SlotsEngine.Evaluation
{
	public class Generator : IGenerator
	{
		private readonly Random _random;
		private readonly List<int> _values = new List<int>();

		public IList<int> Values => _values;

		public Generator(Random random)
		{
			_random = random;
		}

		public int NextValue(int maxValue)
		{
			return NextValue(0, maxValue);
		}

		public int NextValue(int minValue, int maxValue)
		{
			var randomMaxValue = maxValue + 1;
			var value = _random.Next(minValue, randomMaxValue);
			_values.Add(value);
			return value;
		}

		public void Clear()
		{
			_values.Clear();
		}
	}
}
