using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Text;
using ConsoleApp2;

namespace clientTest1
{
    class Program
    {


        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");

            IPEndPoint endPoint = new IPEndPoint(ip, 12345);
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                clientSocket.Connect(endPoint);
                Console.WriteLine("Connection established");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection failed");
                return;
            }
            Write writing = new Write(clientSocket);
            Read reading  = new Read(clientSocket);
            Thread sendThread = new Thread(new ThreadStart(writing.Sending));
            Thread readThread = new Thread(new ThreadStart(reading.Reading));
            sendThread.Start();
            readThread.Start();

        }

    }
}
