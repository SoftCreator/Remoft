using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remoft.Common
{
    public class Settings
    {
        public int UdpPort = 11000;
        public int TcpPort = 11001;

        public NetworkMachineDTO LocalMachine
        {
            get
            {
                var helper = new IPHelper();
                var result = new NetworkMachineDTO
                {
                    HostName = helper.HostName,
                    IP = helper.IP.ToString(),
                    UserName = System.Security.Principal.WindowsIdentity.GetCurrent().Name
                };
                return result;
            }
        }
    }
}
