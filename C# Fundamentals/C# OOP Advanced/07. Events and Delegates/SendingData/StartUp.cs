using System;

namespace SendingData
{
    public class StartUp
    {
        public static void Main()
        {
            DataModel data = new DataModel() { Context = "some content"};
            DataSender dataSender = new DataSender(); //publisher
            MailService mail = new MailService(); //subscriber

            dataSender.SendData += mail.OnMailSendWhenDataSended;
            dataSender.Send(data);
        }
    }
}
