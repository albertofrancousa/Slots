using System;

namespace SlotsEngine.Evaluation
{
	public interface IPlayExceptionOutcome : IPlayOutcome
	{
		Exception Exception { get; }
	}
}
