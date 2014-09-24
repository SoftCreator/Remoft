using Remoft.Common;
using Remoft.UDP;
using Remoft.TCP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Remoft.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var tcpListener = new AsynchronousSocketListener();
            var tcpListenerThread = new Thread(tcpListener.StartListening);
            tcpListenerThread.Start();

            var udpWrapper = new UdpWrapperTimer();
            var timer = new Timer(udpWrapper.SendEcho);
            timer.Change(0, 5000);

            Console.ReadLine();
        }

        private class UdpWrapperTimer
        {
            private UDPListener udpListener = new UDPListener();

            public void SendEcho(Object stateInfo)
            {
                udpListener.SendBroadcast(Commands.Echo.ToString(), new IPHelper().Broadcast);
            }
        }
    }
}
