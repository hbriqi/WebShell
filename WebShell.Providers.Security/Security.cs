using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebShell.ClassLibrary;

namespace WebShell.Providers.Security
{
    public class Security:ISecurity
    {
        public bool IsValidUser()
        {
            throw new NotImplementedException();
        }

        public bool IsValidRole()
        {
            throw new NotImplementedException();
        }

        public void Login(string ReturnCommandName)
        {
            throw new NotImplementedException();
        }
    }
}
