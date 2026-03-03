using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBankProject
{
	class BankingException : Exception
	{
		public BankingException(string message) : base(message)
		{
		}
	}
}
