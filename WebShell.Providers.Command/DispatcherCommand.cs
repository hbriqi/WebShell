using System;
using System.Collections.Generic;
using System.Text;
using WebShell.ClassLibrary;
using WebShell.Utilities.Configuration;
using System.Web;

namespace WebShell.Providers.Command
{
    class DispatcherCommand:ICommand
    {
        #region ICommand Members

        /// <summary>
        /// dispatcher will fire corresponding command according to the incoming URL
        /// </summary>
        /// <param name="command">request command by URL</param>
        /// <returns></returns>
        public IResult Execute(string command)
        {
            string strCommand = GetCommand(command);
            ICommand iCommand = null;
            Result comResult = new Result();
            comResult.Success=false;
            IResult oResult= ObjectBuilder.CreateFrom(WebShellConfig.GetCommandType(strCommand));
            if (oResult.Success)
            {
                iCommand = oResult.Data as ICommand;
                command = command.Remove(0, strCommand.Length);
                if (command.StartsWith("/")) command.Remove(0, 1);

                if (HttpContext.Current.Request.HttpMethod == "GET")
                {
                    comResult = iCommand.Execute_GET(command) as Result;
                }
                else if (HttpContext.Current.Request.HttpMethod == "POST")
                {
                    comResult = iCommand.Execute_POST(command) as Result;
                }
                else if (HttpContext.Current.Request.HttpMethod == "PUT")
                {
                    comResult = iCommand.Execute_PUT(command) as Result;
                }
                else if (HttpContext.Current.Request.HttpMethod == "DELETE")
                {
                    comResult = iCommand.Execute_DELETE(command) as Result;
                }

            }
            

            return comResult;
        }

        /// <summary>
        /// Get command name
        /// </summary>
        /// <param name="command">request command by URL</param>
        /// <returns></returns>
        public string GetCommand(string command)
        {
            string strCommandName =command.ToLower();
            strCommandName = strCommandName.Split('/')[0];
                       
            return strCommandName;
        }

        #endregion

        #region ICommand Members


        public IResult Execute_GET(string command)
        {
            throw new Exception("The method or operation is not implemented.");
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
