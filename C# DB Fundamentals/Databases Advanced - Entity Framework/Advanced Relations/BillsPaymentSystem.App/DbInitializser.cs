using BillsPaymentSystem.Data;
using BillsPaymentSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BillsPaymentSystem.App
{
    public class DbInitializser
    {
        public static void Seed(BillsPaymentSystemContext context)
        {
            List<CreditCard> creditCards = new List<CreditCard>();
            List<BankAccount> bankAccounts = new List<BankAccount>();
            List<User> users = new List<User>();

            SeedUsers(context, users);
            SeedCreditCards(context, creditCards);
            SeedBankAccount(context, bankAccounts);
            SeedPaymentMethod(context, users, bankAccounts, creditCards);
        }

        private static void SeedPaymentMethod(BillsPaymentSystemContext context,
                List<User> users, List<BankAccount> bankAccounts, List<CreditCard> creditCards)
        {
            var paymentMethods = new[]
            {
                 new PaymentMethod()
                 {  
                    User = users[0],
                    BankAccount = bankAccounts[0],
                    CreditCard = creditCards[0]
                 },

                 new PaymentMethod()
                 {
                    User = users[1],
                    BankAccount = bankAccounts[1],
                    CreditCard = creditCards[1]
                 }
            };

            context.AddRange(paymentMethods);
            context.SaveChanges();
        }

        private static void SeedCreditCards(BillsPaymentSystemContext context, List<CreditCard> creditCards)
        {
            for (int i = 0; i < 5; i++)
            {
                var creditCard = new CreditCard()
                {
                    Limit = new Random().Next(-500, 2500),
                    MoneyOwed = new Random().Next(-500, 2500),
                    ExpirationDate = DateTime.Now.AddDays(new Random().Next(-500, 2000))
                };

                if (!IsValid(creditCard))
                {
                    continue;
                }

                creditCards.Add(creditCard);
            }

            context.AddRange(creditCards);
            context.SaveChanges();
        }

        private static void SeedBankAccount(BillsPaymentSystemContext context, List<BankAccount> bankAccounts)
        {
            var bankName = new[] { "UniCredit", "DSK", "PostBank", " ", "Fibank" };
            var swiftCode = new[] { "NASBBGSF", "BNBGBGSF", "CEDPBGSF", "CITIBGSFTRD", null };

            for (int i = 0; i < 5; i++)
            {
                var bankAccount = new BankAccount()
                {
                    BankName = bankName[i],
                    SwiftCode = swiftCode[i],
                    Balance = new Random().Next(-10, 2500),
                };

                if (!IsValid(bankAccount))
                {
                    continue;
                }

                bankAccounts.Add(bankAccount);
            }

            context.AddRange(bankAccounts);
            context.SaveChanges();
        }

        private static void SeedUsers(BillsPaymentSystemContext context, List<User> users)
        {
            string[] firstNames = new[] { "Gosho", "Pesho", "Kiro", null };
            string[] lastNames = new[] { "Goshov", "Peshov", "Kirov", "Stamatov" };
            string[] emails = new[] { "Gosho@gmail.com", "Pesho@abv.bg", "Kiro@yahoo.com", "Error.bg" };
            string[] password = new[] { "12345", "544321", "Kiro2312", "Stamat4o", };

            for (int i = 0; i < firstNames.Length; i++)
            {
                User user = new User()
                {
                    FirstName = firstNames[i],
                    LastName = lastNames[i],
                    Email = emails[i],
                    Password = password[i]
                };

                if (!IsValid(user))
                {
                    continue;
                }

                users.Add(user);
            }

            context.Users.AddRange(users);
            context.SaveChanges();
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(entity, validationContext, validationResults, true);

            return isValid;
        }
    }
}
