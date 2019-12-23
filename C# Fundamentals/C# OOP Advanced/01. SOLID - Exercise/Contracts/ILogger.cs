namespace SOLID_Exercise.Contracts
{
    public interface ILogger
    {
        void Error(string dateTime, string ErrorLevel);

        void Info(string dateTime, string ErrorLevel);
    }
}
