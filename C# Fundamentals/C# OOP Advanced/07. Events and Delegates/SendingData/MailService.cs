using System;

namespace SendingData
{
    public class MailService
    {
        public void OnMailSendWhenDataSended(object source, EventArgs e)
        {
            Console.WriteLine("Message send.");
        }
    }
}
