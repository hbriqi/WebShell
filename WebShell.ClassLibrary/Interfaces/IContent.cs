using System;
using System.Collections.Generic;
using System.Text;

namespace WebShell.ClassLibrary.Interfaces
{
    public interface IContent
    {
        string Retrive(string resourceName);
        string localize(string resourceName);
    }
}
