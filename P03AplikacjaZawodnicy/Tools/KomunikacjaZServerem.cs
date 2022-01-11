using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace P03AplikacjaZawodnicy.Tools
{
    class KomunikacjaZServerem
    {
        public static void WyslijDane(string s)
        {
            UdpClient udpClient = null;
            int port = 59550;

            byte[] buffer;
            try
            {
                udpClient = new UdpClient();
                udpClient.Connect(IPAddress.Loopback, port);

                buffer = Encoding.ASCII.GetBytes(s);
                udpClient.Send(buffer, buffer.Length);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (udpClient != null)
                    udpClient.Close();
            }

        }
    }
}
