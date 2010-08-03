using System;
using System.Collections.Generic;
using System.Text;
using WebShell.Utilities.Configuration.Section;
using System.Configuration;

namespace WebShell.Utilities.Configuration
{
    public static class WebShellConfig
    {
        static WebShellSection shellSectin = (WebShellSection)ConfigurationManager.GetSection("webShell");

        public static Type GetCommandType(string name)
        {
            Type commandProviderType = Type.GetType(shellSectin.Commands[name].ProviderType);
            if (commandProviderType == null)
                throw new Exception("Command provider section is not configured properly");
            return commandProviderType;
        }

        public static string Root
        {
            get 
            {
                string root = string.Empty;
                try
                {
                    root = shellSectin.Settings["root"].Value.ToString();
                    return root;
                }
                catch (Exception ex)
                {
                    //TODO: add apropriate message here concerned with ex => Low priorty
                    throw ex;
                }
            }
        }
    }
}
