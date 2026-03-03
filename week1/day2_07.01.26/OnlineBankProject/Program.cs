namespace OnlineBankProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
			OnlineBank sbi = new OnlineBank();
			//OnlineBank bob = new OnlineBank("Bob", 44323234, "Aditya");
			sbi.GetDetails();
			sbi.DisplayDetails();

			//bob.DisplayDetails();

			// Object creation
			SavingAcc acc = new SavingAcc();

			//// Deposit
			//int amountToDeposit;
			//Console.WriteLine("Enter amount to Deposit:");
   //         amountToDeposit = int.Parse(Console.ReadLine());
			//acc.Deposit(amountToDeposit);
			//Console.WriteLine("Balance after deposit: " + acc.Balance);

			//// Withdraw
			//int amountToWithdraw;
			//Console.WriteLine("Enter amount to Withdraw:");
			//amountToWithdraw = int.Parse(Console.ReadLine());
			//acc.Withdrawal(amountToWithdraw);
			//Console.WriteLine("Balance after withdrawal: " + acc.Balance);

			// STRUCT 
			Customer cust;
			cust.CustomerId = 101;
			cust.Name = "Aditya";
			cust.Email = "aditya@gmail.com";
			cust.DisplayCustomer();

			// GENERIC 
			TransactionLog<string> log = new TransactionLog<string>();

			// Deposit
			Console.WriteLine("Enter amount to Deposit:");
			int amountToDeposit = int.Parse(Console.ReadLine());
			acc.Deposit(amountToDeposit);
			log.AddLog("Deposited: " + amountToDeposit);

			// Withdraw
			Console.WriteLine("Enter amount to Withdraw:");
			int amountToWithdraw = int.Parse(Console.ReadLine());
			acc.Withdrawal(amountToWithdraw);
			log.AddLog("Withdraw Attempt: " + amountToWithdraw);

			// Show Logs
			log.ShowLogs();


			Console.ReadLine();
		}
    }
}
