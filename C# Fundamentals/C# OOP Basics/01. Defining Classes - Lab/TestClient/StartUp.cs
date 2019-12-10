using System;
using System.Collections.Generic;
using System.Linq;

namespace TestClient
{
    public class StartUp
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split().ToArray();
            Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();

            while (input[0] != "End")
            {
                switch (input[0])
                {
                    case "Create":
                        Create(input, accounts);
                        break;
                    case "Deposit":
                        Decposit(input, accounts);
                        break;
                    case "Withdraw":
                        Withdraw(input, accounts);
                        break;
                    case "Print":
                        Print(input, accounts);
                        break;
                }

                input = Console.ReadLine().Split().ToArray();
            }
        }

        private static void Print(string[] input, Dictionary<int, BankAccount> accounts)
        {
            int id = int.Parse(input[1]);

            if (accounts.ContainsKey(id))
            {
                Console.WriteLine(accounts[id]);
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void Withdraw(string[] input, Dictionary<int, BankAccount> accounts)
        {
            int id = int.Parse(input[1]);
            decimal amount = decimal.Parse(input[2]);

            if (accounts.ContainsKey(id))
            {
                if (accounts[id].Balance >= amount)
                {
                    accounts[id].Balance -= amount;
                }
                else
                {
                    Console.WriteLine("Insufficient balance");
                }
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void Decposit(string[] input, Dictionary<int, BankAccount> accounts)
        {
            int id = int.Parse(input[1]);
            decimal amount = decimal.Parse(input[2]);

            if (accounts.ContainsKey(id))
            {
                accounts[id].Balance += amount;
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void Create(string[] input, Dictionary<int, BankAccount> accounts)
        {
            int id = int.Parse(input[1]);

            if (!accounts.ContainsKey(id))
            {
                BankAccount acc = new BankAccount();
                acc.Id = id;
                accounts.Add(id, acc);
            }
            else
            {
                Console.WriteLine("Account already exists");
            }
        }
    }
}
