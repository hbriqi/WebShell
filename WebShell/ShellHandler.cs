using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using WebShell.ClassLibrary.Interfaces;
using WebShell.ClassLibrary.Classes;
using WebShell.Utilities.Configuration;

namespace WebShell
{
    class ShellHandler:IHttpHandler
    {
       
        #region IHttpHandler Members

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            IResult r_object = ObjectBuilder.CreateFrom(WebShell.Utilities.Configuration.WebShellConfig.GetCommandType("dispatcher"));
            if (r_object.Success)
            {
                ICommand command = (ICommand)r_object.Data;
                string ComRoot = WebShellConfig.Root.ToLower();
                string strCommand = context.Request.Url.AbsolutePath.ToLower();
               
                if (strCommand.StartsWith(ComRoot))
                {
                    strCommand = strCommand.Remove(0, ComRoot.Length);
                }
                else if (strCommand.StartsWith("/"))
                {
                    strCommand = strCommand.Remove(0, 1);
                }

                if (strCommand == string.Empty)
                    strCommand = "home";

                IResult result = command.Execute(strCommand);
                
                if (result.Success == true)
                {
                    context.Response.Write(result.Data);
                }
                else
                {
                    //TODO: if result not succeeded so appropriate action should be taken => High Priority
                    context.Response.Write("Command Result is not trusted.");
                }

            }
            else
            {
                //TODO: manage response to be more meaningful  
                context.Response.Write("Resource not found.");
            }
        }

        #endregion
    }
}
