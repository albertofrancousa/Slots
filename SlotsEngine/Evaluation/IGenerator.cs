using System.Collections.Generic;

namespace SlotsEngine.Evaluation
{
	public interface IGenerator
	{
		IList<int> Values { get; }

		int NextValue(int maxValue);

		int NextValue(int minValue, int maxValue);

		void Clear();
	}
}
