using System;
using System.Runtime.Serialization;

namespace SlotsEngine.Evaluation
{
	[Serializable]
	internal class InsufficientFundsException : Exception
	{
		public InsufficientFundsException()
		{
		}

		public InsufficientFundsException(string message) : base(message)
		{
		}

		public InsufficientFundsException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected InsufficientFundsException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
