namespace BankManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            SavingAccount sa = new SavingAccount(101, "diksha", 50000);
            sa.Deposit(2000);
            sa.CalculateInterest();
            sa.Display();

			Console.WriteLine("******************");

            CheckingAccount ca = new CheckingAccount(102, "Aditya", 700000);
            ca.Withdraw(3500);
            ca.Display();
		}
    }
}
