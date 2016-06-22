using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = @"log4net.config", Watch = true)]
namespace HelperUnit.Units.Log
{
    public static class Log4NetHelper
    {
        public static ILog Default {
            get { return LogManager.GetLogger("System"); }
        }

        public static ILog GetLogger(string name)
        {
            var log = LogManager.GetLogger(name);
            return log;
        }

    }
}
