using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Remoft.Common
{
    public class IPHelper
    {
        public IPAddress IP { get; private set; }
        public IPAddress Broadcast { get; private set; }
        public string HostName { get; private set; }

        public IPHelper()
        {
            HostName = Dns.GetHostName();
            IP = GetIpAddress();
            var subnetMask = GetSubnetMask(IP);
            Broadcast = GetBroadcastAddress(IP, subnetMask);
        }

        private IPAddress GetIpAddress()
        {
            //This returns the first IP4 address or null
            return Dns.GetHostEntry(HostName).AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
        }

        private IPAddress GetBroadcastAddress(IPAddress address, IPAddress subnetMask)
        {

            byte[] ipAdressBytes = address.GetAddressBytes();
            byte[] subnetMaskBytes = subnetMask.GetAddressBytes();

            if (ipAdressBytes.Length != subnetMaskBytes.Length)
                throw new ArgumentException("Lengths of IP address and subnet mask do not match.");

            byte[] broadcastAddress = new byte[ipAdressBytes.Length];
            for (int i = 0; i < broadcastAddress.Length; i++)
            {
                broadcastAddress[i] = (byte)(ipAdressBytes[i] | (subnetMaskBytes[i] ^ 255));
            }
            return new IPAddress(broadcastAddress);
        }

        private uint ReturnFirtsOctet(string ipAddress)
        {
            System.Net.IPAddress iPAddress = System.Net.IPAddress.Parse(ipAddress);
            byte[] byteIP = iPAddress.GetAddressBytes();
            uint ipInUint = (uint)byteIP[0];
            return ipInUint;
        }

        private IPAddress GetSubnetMask(IPAddress ipAddress)
        {

            uint firstOctet = ReturnFirtsOctet(ipAddress.ToString());
            if (firstOctet >= 0 && firstOctet <= 127)
                return IPAddress.Parse("255.0.0.0");
            else if (firstOctet >= 128 && firstOctet <= 191)
                return IPAddress.Parse("255.255.0.0");
            else if (firstOctet >= 192 && firstOctet <= 223)
                return IPAddress.Parse("255.255.255.0");
            else return IPAddress.Parse("0.0.0.0");
        }

    }
}
