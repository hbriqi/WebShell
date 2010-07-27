using System;
using System.Collections.Generic;
using System.Text;
using WebShell.ClassLibrary.Interfaces;
using WebShell.ClassLibrary.Classes;

namespace WebShell.Providers.Command
{
    class DispatcherCommand:ICommand
    {
        #region ICommand Members

        public IResult Execute(string command)
        {
            Result result = new Result();
            result.Success = true;
            string message = "your url is: " + command;
            result.Data = message;
            return result;
        }

        public string Pars(string command)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
