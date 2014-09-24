using Remoft.Common;
using Remoft.TCP;
using Remoft.UDP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Remoft.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var udp = new UDPListener();
            udp.ReceiveRequest += UdpReceiveRequest;
            var listenerThread = new Thread(udp.StartListener);
            listenerThread.Start();
        }

        static void UdpReceiveRequest(Commands command, IPAddress remoteIP)
        {
            switch (command)
            {
                case Commands.Echo:
                    var tcpClient = new AsynchronousClient(remoteIP);
                    var responseThread = new Thread(tcpClient.SendHostInfo);
                    responseThread.Start();
                    break;
            }
        }
    }
}
