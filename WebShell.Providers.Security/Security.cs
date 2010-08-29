using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebShell.ClassLibrary;

namespace WebShell.Providers.Security
{
    public class Security:ISecurity,ICommand
    {
        public bool IsValidUser()
        {
            return true;
        }

        public bool IsValidRole()
        {
            throw new NotImplementedException();
        }

        public IResult Login(string ReturnCommandName)
        {
            throw new NotImplementedException();
        }

        #region ICommand Members

        public IResult Execute(string command)
        {
            throw new NotImplementedException();
        }

        public IResult Execute_GET(string command)
        {
            IResult result = new Result();
            result.Success = true;
            result.Data = "User Login";
            return result;
        }

        public IResult Execute_POST(string command)
        {
            throw new NotImplementedException();
        }

        public IResult Execute_PUT(string command)
        {
            throw new NotImplementedException();
        }

        public IResult Execute_DELETE(string command)
        {
            throw new NotImplementedException();
        }

        public string GetCommand(string command)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
