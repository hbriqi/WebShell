using System;
using System.Collections.Generic;
using System.Text;

namespace WebShell.ClassLibrary.Interfaces
{
    public interface ICommand
    {
        IResult Execute(string command);
        string Pars(string command);   
    }
}
