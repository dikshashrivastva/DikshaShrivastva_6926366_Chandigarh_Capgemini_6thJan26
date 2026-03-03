using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBankProject
{
    internal class OnlineBank
    {
		public const string Country = "India";
		public static string BankType;

		public string accN, bankN;
		public int accNo;

		static OnlineBank()
		{
			BankType = "National Bank";
			Console.WriteLine("Static Constructor Called");
		}

		public OnlineBank()
		{
			Console.WriteLine("Welcome to Online Banking");
		}

		public OnlineBank(string bankName, int accountNo, string accountName)
		{
			bankN = bankName;
			accNo = accountNo;
			accN = accountName;
		}

		public void GetDetails()
		{
			Console.WriteLine("Enter Bank Name:");
			bankN = Console.ReadLine();

			Console.WriteLine("Enter Account Number:");
			accNo = Convert.ToInt32(Console.ReadLine());

			Console.WriteLine("Enter Account Holder Name:");
			accN = Console.ReadLine();
		}

		public void DisplayDetails()
		{
			Console.WriteLine("\nAccount Details");
			Console.WriteLine("Country: " + Country);
			Console.WriteLine("Bank Type: " + BankType);
			Console.WriteLine("Bank Name: " + bankN);
			Console.WriteLine("Account No: " + accNo);
			Console.WriteLine("Account Holder: " + accN);
		}
	}

}

