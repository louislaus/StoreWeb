using log4net;
using System;
using System.IO;

namespace StoreWeb.Core.Log
{
    public static class Logger
    {
        private static readonly ILog Logger_Error = LogManager.GetLogger("logerror");
        private static readonly ILog Logger_Info = LogManager.GetLogger("loginfo");
        static Logger()
        {
            FileInfo log4netFile = new FileInfo(string.Format("{0}/Config/log4net.config",AppDomain.CurrentDomain.BaseDirectory));
        }
        public static void Log(string message,Exception ex)
        {
            Logger_Error.Error(message, ex);
        }
        public static void LogInfo(string message)
        {
            Logger_Error.Error(message);
        }
    }
}
