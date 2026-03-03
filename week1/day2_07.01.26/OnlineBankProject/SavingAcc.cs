using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBankProject
{
	class SavingAcc : BankAccount, InterTransaction
	{
		public AccountType AccType = AccountType.Savings;

		public override void Withdrawal(int amt)
		{
			try
			{
				if (amt <= 0)
					throw new BankingException("Invalid withdrawal amount!");

				if (amt > Balance)
					throw new BankingException("Insufficient balance!");

				Balance -= amt;
				Console.WriteLine("Withdrawal Successful");
			}
			catch (BankingException ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
		}
	}


}
