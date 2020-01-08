using System;
using System.Threading;

namespace SendingData
{
    public class DataModelEventArgs : EventArgs
    {
        public DataModel DataModel { get; set; }
    }

    public class DataSender
    {
        //Declaring event handler without generic
        //public delegate void SendDataEventHandler(object source, DataModelEventArgs eventArgs);
        //public event SendDataEventHandler SendData;

        public event EventHandler<DataModelEventArgs> SendData;

        public void Send(DataModel data)
        {
            Console.WriteLine("Sending data...");
            Thread.Sleep(3000);

            OnSendData(data);
            Console.WriteLine("Done!");
        }

        //protected virtual void OnEventName() is based on MS convention 
        protected virtual void OnSendData(DataModel data)
        {
            if(SendData != null)
            {
                SendData(this, new DataModelEventArgs() { DataModel = data });
            }
        }
    }
}
