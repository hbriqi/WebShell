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
            IResult r_object = ObjectBuilder.CreateFrom(WebShell.Utilities.Configuration.WebShellConfig.CommandProviderType);
            if (r_object.Success)
            {
                ICommand command = (ICommand)r_object.Data;
                string strResponse = command.Execute(context.Request.Url.AbsolutePath).Data.ToString();
                context.Response.Write(strResponse);
            }
            else
            {
                context.Response.Write("Can not Found the Resource!");
            }
        }

        #endregion
    }
}
