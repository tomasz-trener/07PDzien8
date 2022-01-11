using Newtonsoft.Json;
using P08AplikacjaZawodnicy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P06Server
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener tcpServer;
            UdpClient udpServer;

            udpServer = new UdpClient(59550);

            var watekUdp = new Thread(new ParameterizedThreadStart(UDPServerNasluchiwanie));

            watekUdp.IsBackground = true;
            watekUdp.Name = "UDPSerwerWatek";
            watekUdp.Start(udpServer);

            Console.ReadKey();
        }

        private static void UDPServerNasluchiwanie(object arg)
        {
            UdpClient uc = (UdpClient)arg;
            IPEndPoint remoteEP;
            byte[] buffer; 
            remoteEP = null;
            buffer = uc.Receive(ref remoteEP);

            if (buffer != null && buffer.Length > 0)
            {
                string s = Encoding.ASCII.GetString(buffer);

                ZawodnikVM zawodnik= JsonConvert.DeserializeObject<ZawodnikVM>(s);

                Console.WriteLine(zawodnik.PodstawoweDane);
            }

        }
    }
}
