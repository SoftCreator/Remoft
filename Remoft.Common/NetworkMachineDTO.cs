using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Remoft.Common
{
    [DataContract]
    public class NetworkMachineDTO : IEquatable<NetworkMachineDTO>
    {
        [DataMember]
        public string HostName { get; set; }
        [DataMember]
        public string IP { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string ExtraData { get; set; }

        public string Serialize()
        {
            using (var stream1 = new MemoryStream())
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(NetworkMachineDTO));
                ser.WriteObject(stream1, this);
                stream1.Position = 0;
                StreamReader sr = new StreamReader(stream1);
                return sr.ReadToEnd();
            }
        }

        public static NetworkMachineDTO Deserialize(string serialized)
        {
            var ser = new DataContractJsonSerializer(typeof(NetworkMachineDTO));
            using (var ms = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(serialized)))
            {
                var result = (NetworkMachineDTO)ser.ReadObject(ms);
                return result;
            }
        }

        public bool Equals(NetworkMachineDTO other)
        {
            return other.Serialize() == this.Serialize();
        }
    }
}
