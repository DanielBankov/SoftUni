namespace SOLID_Exercise.Appenders
{
    using System.IO;
    using Contracts;
    using Loggers.Enums;

    public class FileAppender : Appender
    {
        private const string path = "../../../log.txt";

        private readonly ILogFile fileAppender;

        public FileAppender(ILayout simpleLayout, ILogFile fileAppender) 
            : base(simpleLayout)
        {
            this.fileAppender = fileAppender;
        }

        public override void Append(string dateTime, ReportLevel errorLevel, string message)
        {
            if (this.ReportLevel <= errorLevel)
            {
                string content = string.Format(this.Layout.Format, dateTime, errorLevel, message);
                File.AppendAllText(path, content + "\n");

                fileAppender.Write(content);
                this.MessagesCount++;
            }
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {(this.ReportLevel.ToString().ToUpper())}, Messages appended: {MessagesCount}, File size: {this.fileAppender.Size}";
        }
    }
}
