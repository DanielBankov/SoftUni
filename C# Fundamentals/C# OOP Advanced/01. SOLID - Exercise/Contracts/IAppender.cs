namespace SOLID_Exercise.Contracts
{
    using Loggers.Enums;

    public interface IAppender
    {
        ReportLevel ReportLevel { get; set; }

        int MessagesCount { get; }

        void Append(string dateTime, ReportLevel errorLevel, string message);
    }
}
