using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebShell.ClassLibrary;
using WebShell.Utilities.Configuration;

namespace WebShell.Utilities
{
    public class Security
    {
        public static ISecurity iSecurity = ObjectBuilder.CreateFrom(WebShellConfig.GetSecurityType()).Data as ISecurity;

        public static bool IsValidUser()
        {
            return iSecurity.IsValidUser();
        }

        public static bool IsValidRole()
        {
            return iSecurity.IsValidRole();
        }

        public static void Login(string returnCommandName)
        {
            iSecurity.Login(returnCommandName);
        }
    }
}
