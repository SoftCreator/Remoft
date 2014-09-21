using Remoft.Common;
using Remoft.UDP;
using System;
using System.Collections.Generic;
using System.Linq;
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
            
        }

        static void UdpReceiveRequest(Commands command)
        {
            switch (command)
            {
                case Commands.Echo:
                    break;
            }
        }
    }
}
