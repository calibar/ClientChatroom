using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Read
    {
        private Socket skt;
        public Read(Socket socket) {
            skt = socket;
        }
        public void Reading()
        {
            byte[] br = new byte[1024];
            int recieve;
            while (true)
            {
                try { recieve = skt.Receive(br); }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                    /*Console.ReadLine();*/
                    break;
                }
                
                string output = Encoding.UTF8.GetString(br, 0, recieve);
                Console.WriteLine(output);
            }
        }
    }
}
