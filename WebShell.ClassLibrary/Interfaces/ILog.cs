using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebShell.ClassLibrary.Interfaces
{
    public interface ILog
    {
        void Write(string context, string title, string message);
    }
}
