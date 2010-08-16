using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebShell.Utilities.Configuration;
using WebShell.ClassLibrary.Interfaces;
using WebShell.ClassLibrary.Classes;

namespace WebShell.Utilities
{
    public class Log
    {
        static ILog log = ObjectBuilder.CreateFrom(WebShellConfig.GetLoggerType()).Data as ILog;
        public static void Write(string context, string title, string message)
        {
            log.Write(context, title, message);
        }
    }
}
