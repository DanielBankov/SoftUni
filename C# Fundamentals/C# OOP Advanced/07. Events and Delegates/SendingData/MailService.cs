using System;

namespace SendingData
{
    public class MailService
    {
        public void OnMailSendWhenDataSended(object source, DataModelEventArgs e)
        {
            Console.WriteLine($"Message {e.DataModel.Context} send.");
        }
    }
}
