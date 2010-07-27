using System;
using System.Collections.Generic;
using System.Text;
using WebShell.Utilities.Configuration.Section;
using System.Configuration;

namespace WebShell.Utilities.Configuration
{
    public static class WebShellConfig
    {
        public static Type CommandProviderType
        {
            get 
            {
                WebShellSection shellSectin=(WebShellSection)ConfigurationManager.GetSection("webShell");
                Type commandProviderType=Type.GetType(shellSectin.Command.ProviderType);
                if (commandProviderType == null)
                    throw new Exception("Command provider section is not configured properly");
                return commandProviderType;
            }
        }

        public static Type ContentProviderType
        {
            get
            {
                WebShellSection shellSectin = (WebShellSection)ConfigurationManager.GetSection("webShell");
                Type commandProviderType = Type.GetType(shellSectin.Content.ProviderType);
                if (commandProviderType == null)
                    throw new Exception("Content provider section is not configured properly");
                return commandProviderType;
            }
        }
    }
}
