using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace WebShell.Utilities.Configuration.Section
{
    public class WebShellSection:ConfigurationSection
    {
        [ConfigurationProperty("commands", IsRequired=true)]
        public CommandProviderCollection Commands
        {
            get { return this["commands"] as CommandProviderCollection; }
           
        }

        [ConfigurationProperty("settings", IsRequired = true)]
        public SettingCollection Settings
        {
            get { return this["settings"] as SettingCollection; }

        }
   
    }
}
