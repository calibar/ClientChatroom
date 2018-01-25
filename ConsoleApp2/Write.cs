using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Write
    {
        private Socket skt;
        public Write(Socket socket) {
            skt = socket;
        }
        public void Sending()
        {
            string input;
            do
            {
                input = Console.ReadLine();
                byte[] bw = Encoding.UTF8.GetBytes(input + "\r");
                skt.Send(bw, 0, bw.Length, SocketFlags.None);
            } while (!input.Equals("Quit"));
            skt.Shutdown(SocketShutdown.Both);
            skt.Close();
        }
    }
}

