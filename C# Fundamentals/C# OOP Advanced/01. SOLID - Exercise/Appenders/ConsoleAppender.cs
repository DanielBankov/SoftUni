namespace SOLID_Exercise.Appenders
{
    using Contracts;
    using Loggers.Enums;

    using System;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout simpleLayout)
            :base(simpleLayout)
        {
        }

        public override void Append(string dateTime, ReportLevel errorLevel, string message)
        {
            if (this.ReportLevel <= errorLevel)
            {
                Console.WriteLine(string.Format(this.Layout.Format, dateTime, errorLevel, message));
                this.MessagesCount++;
            }
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {(this.ReportLevel.ToString().ToUpper())}, Messages appended: {MessagesCount}";
        }
    }
}
