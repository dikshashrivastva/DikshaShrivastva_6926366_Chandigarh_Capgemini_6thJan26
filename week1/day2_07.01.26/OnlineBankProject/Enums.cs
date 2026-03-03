using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBankProject
{
		enum AccountType
		{
			Savings,
			Current,
			Salary
		}

		enum TransactionStatus
		{
			Success,
			Failed,
			InsufficientBalance
		}
}
