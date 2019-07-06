using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CustomHttpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            const string NewLine = "\r\n";
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 80);
            tcpListener.Start();

            while (true)
            {
                TcpClient tcpClient = tcpListener.AcceptTcpClient();

                using (NetworkStream stream = tcpClient.GetStream())
                {
                    byte[] requestBytes = new byte[100000];
                    int readBytes = stream.Read(requestBytes, 0, requestBytes.Length);

                    var stringRequest = Encoding.UTF8.GetString(requestBytes, 0, readBytes);
                    Console.WriteLine(new string('-', 80));
                    Console.WriteLine(stringRequest);

                    string response = "HTTP/1.0 200 OK" + NewLine +
                                      "Content-Type: text/html" + NewLine +
                                      "Content-Length: 20" + NewLine + NewLine +
                                      "<h1> Hello Web! <h1>";

                    byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                    stream.Write(responseBytes, 0, responseBytes.Length);
                }
            }
        }
    }
}
