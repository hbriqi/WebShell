using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace WebShell.Utilities.Configuration.Section
{
    public class CommandProviderElement:ConfigurationElement
    {
        [ConfigurationProperty("providerType")]
        public string ProviderType
        {
            get { return (string)this["providerType"]; }
            set { this["providerType"] = value; }
        }
    }
}
