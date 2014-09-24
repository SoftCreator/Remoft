using Remoft.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Remoft.UDP
{
    public class UDPListener
    {
        private readonly int listenPort;

        public delegate void ProcessUDPEvent(Commands command, IPAddress remoteIP);

        public event ProcessUDPEvent ReceiveRequest;

        public UDPListener()
        {
            var settings = new Remoft.Common.Settings();
            listenPort = settings.UdpPort;
        }

        public void StartListener()
        {
            bool done = false;

            UdpClient listener = new UdpClient(listenPort);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);

            try
            {
                while (!done)
                {
                    byte[] bytes = listener.Receive(ref groupEP);
                    string msg = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
                    Console.WriteLine(msg);
                    Commands command;
                    if (Enum.TryParse<Commands>(msg, out command))
                    {
                        switch (command)
                        {
                            case Commands.Stop:
                                done = true;
                                break;
                        }
                        if (ReceiveRequest != null) ReceiveRequest(command, groupEP.Address);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                listener.Close();
            }
        }

        public void SendBroadcast(string message, IPAddress broadcast)
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram,
                ProtocolType.Udp);
            byte[] sendbuf = Encoding.UTF8.GetBytes(message);
            IPEndPoint ep = new IPEndPoint(broadcast, listenPort);
            s.SendTo(sendbuf, ep);
        }

    }
}
