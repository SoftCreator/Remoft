using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remoft.Plugins
{
    public class RemoftConsole : IPlugin
    {
        string Process(string data)
        {
            return "";
        }
        public string Icon { get { return ""; } }
        public string Title { get { return "Console"; } }
    }
}
