using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remoft.Plugins
{
    public interface IPlugin
    {
        string Icon { get; }
        string Title { get; }
    }
}
