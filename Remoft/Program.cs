using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remoft
{
    using Remoft.Common;
    using Remoft.UDP;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Security;
 
namespace MorganUtil
{
    class Program
    {
 
        static void Main(string[] args)
        {
            var settings = new Settings();
            Console.WriteLine(settings.LocalMachine.Serialize());
            Console.ReadLine();
        }
    }
}
}
