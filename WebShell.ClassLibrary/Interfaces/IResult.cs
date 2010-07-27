using System;
using System.Collections.Generic;
using System.Text;

namespace WebShell.ClassLibrary.Interfaces
{
    public interface IResult
    {
        bool Success { get; set;}
        object Data{get; set;}
    }
}
