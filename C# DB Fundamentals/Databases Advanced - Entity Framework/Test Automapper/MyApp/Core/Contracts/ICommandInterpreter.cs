namespace MyApp.Core.Contracts
{
    internal interface ICommandInterpreter
    {
        string Read(string[] inputArgs);
    }
}
