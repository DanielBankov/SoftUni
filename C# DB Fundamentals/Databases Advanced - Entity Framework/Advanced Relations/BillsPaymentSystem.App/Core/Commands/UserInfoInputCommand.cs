using BillsPaymentSystem.App.Core.Commands.Contrats;
using BillsPaymentSystem.Data;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace BillsPaymentSystem.App.Core.Commands
{
    public class UserInfoInputCommand : ICommand
    {
        private readonly BillsPaymentSystemContext context;

        public UserInfoInputCommand(BillsPaymentSystemContext context)
        {
            this.context = context;
        }

        public string Execute(int userId)
        {
            var user = context.Users.FirstOrDefault(u => u.UserId == userId);

            if(user == null)
            {
                throw new ArgumentException("Invalid user id");
            }

            var userInfo = context.PaymentMethods.FirstOrDefault(x => x.UserId == userId);



            //user = celiq user
            return "execute return";
        }
    }
}
