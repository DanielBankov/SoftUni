using System;

namespace BankAccount
{
    public class StartUp
    {
        public static void Main()
        {
            BankAccount account = new BankAccount();

            account.Id = 1;
            account.Deposit(15);
            account.Withdraw(10);

            Console.WriteLine(account);
        }
    }
}
