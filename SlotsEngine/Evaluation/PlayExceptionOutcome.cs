using System;

namespace SlotsEngine.Evaluation
{
	public class PlayExceptionOutcome : IPlayExceptionOutcome
	{
		public Exception Exception { get; }

		public PlayExceptionOutcome(Exception exception)
		{
			Exception = exception;
		}
	}
}
