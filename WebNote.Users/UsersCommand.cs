using System;
using System.Collections.Generic;
using System.Text;
using WebShell.ClassLibrary.Interfaces;
using WebShell.ClassLibrary.Classes;
using System.Web;

namespace WebNote.Users
{
   public class UsersCommand:ICommand
    {
        #region ICommand Members

        public IResult Execute(string command)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public string GetCommand(string command)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IResult Execute_GET(string command)
        {
            Result result = new Result();
            HttpRequest httpRequest = HttpContext.Current.Request;
            result.Data = "Welcome new user";
            result.Success = true;

            return result;
        }

        public IResult Execute_POST(string command)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IResult Execute_PUT(string command)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IResult Execute_DELETE(string command)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
