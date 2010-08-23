using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebShell.ClassLibrary.Interfaces
{
   public  interface ISecurity
    {
       bool IsValidUser();
       bool IsValidRole();
       void Login(string ReturnCommandName);
    }
}
