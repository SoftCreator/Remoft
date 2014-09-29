using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remoft.Plugins
{
    public class PluginManager
    {
        public List<IPlugin> GetAllPlugins()
        {
            var result = new List<IPlugin>();
            var type = typeof(IPlugin);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsInterface && !p.IsAbstract);
            foreach (Type t in types)
            {
                var instance = (IPlugin)Activator.CreateInstance(t);
                result.Add(instance);
            }
            return result;
        }
    }
}
