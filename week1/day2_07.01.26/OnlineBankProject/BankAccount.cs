using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBankProject
{
	abstract class BankAccount
	{
		private int balance;   // encapsulation

		public int Balance
		{
			get { return balance; }
			protected set { balance = value; }
		}

		public void Deposit(int amt)
		{
			Balance += amt;
		}

		public abstract void Withdrawal(int amt);  // abstraction
	}

}
