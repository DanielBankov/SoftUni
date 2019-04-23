namespace MyApp.Core.Command.Contracts
{
    internal interface ICommand
    {
        string Execute(string[] inputArgs);
    }
}
