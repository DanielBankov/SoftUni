using System;
using System.Threading;

namespace SendingData
{
    public class DataSender
    {
        public delegate void SendDataEventHandler(object source, EventArgs eventArgs);
        public event SendDataEventHandler SendData;

        public void Send(DataModel data)
        {
            Console.WriteLine("Sending data...");
            Thread.Sleep(3000);

            OnSendData();
            Console.WriteLine("Done!");
        }

        //protected virtual void OnEventName() is based on MS convention 
        protected virtual void OnSendData()
        {
            if(SendData != null)
            {
                SendData(this, EventArgs.Empty);
            }
        }
    }
}
