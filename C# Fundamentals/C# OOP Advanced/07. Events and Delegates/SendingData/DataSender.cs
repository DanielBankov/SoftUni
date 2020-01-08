using System;
using System.Threading;

namespace SendingData
{
    public class DataSender
    {
        public void Send(DataModel data)
        {
            Console.WriteLine("Sending data...");
            Thread.Sleep(3000);
            Console.WriteLine("Done!");
        }
    }
}
