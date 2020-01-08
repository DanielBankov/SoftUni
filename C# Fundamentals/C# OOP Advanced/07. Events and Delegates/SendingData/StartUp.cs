using System;

namespace SendingData
{
    public class StartUp
    {
        public static void Main()
        {
            DataModel data = new DataModel() { Context = "some content"};
            DataSender dataSender = new DataSender();
            dataSender.Send(data);
        }
    }
}
