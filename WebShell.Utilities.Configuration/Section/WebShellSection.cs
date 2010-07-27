using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace WebShell.Utilities.Configuration.Section
{
    public class WebShellSection:ConfigurationSection
    {
        [ConfigurationProperty("content")]
        public ContentProviderElement Content
        {
            get { return (ContentProviderElement)this["content"]; }
            set { this["content"] = value; }
        }

        [ConfigurationProperty("command")]
        public CommandProviderElement Command
        {
            get { return (CommandProviderElement)this["command"];}
            set { this["command"] = value; }
        }
    }
}
