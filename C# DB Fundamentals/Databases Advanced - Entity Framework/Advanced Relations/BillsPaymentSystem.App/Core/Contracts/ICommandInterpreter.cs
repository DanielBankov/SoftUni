using BillsPaymentSystem.Data;

namespace BillsPaymentSystem.App.Core.Contracts
{
    public interface ICommandInterpreter
    {
        string Read(int userId, BillsPaymentSystemContext context);
    }
}
