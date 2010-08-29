using System;
using System.Collections.Generic;
using System.Text;
using WebShell.ClassLibrary;
using WebShell.Utilities;
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
                
                bool isValidUser = false;
                object[] oArr= iCommand.GetType().GetCustomAttributes(typeof(LoginRequired), true);
                LoginRequired loginRequired=null;
                if (oArr.Length > 0)
                {
                    loginRequired = oArr[0] as LoginRequired;
                    isValidUser = WebShell.Utilities.Security.IsValidUser();
                }
                else
                { 
                    isValidUser = true; 
                }

                if (isValidUser)
                {
                    command = command.Remove(0, strCommand.Length);
                    if (command.StartsWith("/")) command=command.Remove(0, 1);
                    comResult = iCommand.Execute(command) as Result;
                    
                }
                else if (!isValidUser && loginRequired != null)
                {
                    string message = "try to access \"login required\" form \r\n command url:" + HttpContext.Current.Request.RawUrl;
                    WebShell.Utilities.Log.Write(this.ToString(), "not authorized user", message);                   
                    if (loginRequired.RedirectTo != null)
                    {
                        HttpContext.Current.Response.Redirect(AppData.GetBaseUrl() + "/security/login/?" + loginRequired.RedirectTo);

                    }
                    else
                    {
                        HttpContext.Current.Response.Redirect(AppData.GetBaseUrl() + "/security/login/?" + command);
                    }
                }
                else
                {
                    //may be not reachable
                    comResult.Data = "You are not authorized user";
                    WebShell.Utilities.Log.Write(this.ToString(), "not autorized user", "command url:" + HttpContext.Current.Request.RawUrl);
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
