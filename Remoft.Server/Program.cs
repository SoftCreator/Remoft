using Remoft.Common;
using Remoft.UDP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remoft.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var udp = new UDPListener();
            var settings = new Settings();
            var ipHelper = new IPHelper();
            udp.SendBroadcast("ECHO", ipHelper.Broadcast);
        }
    }
}
