namespace BillsPaymentSystem.App.Core.Commands.Contrats
{
    public interface ICommand
    {
        string Execute(int userId);
    }
}
