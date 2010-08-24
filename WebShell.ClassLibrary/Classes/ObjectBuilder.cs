using System;
using System.Collections.Generic;
using System.Text;

namespace WebShell.ClassLibrary
{
    /// <summary>
    /// type creator 
    /// </summary>
   public class ObjectBuilder
    {
       public static IResult CreateFrom(Type type)
       {
           Result result = new Result();
           object oValue=Activator.CreateInstance(type);
           if (oValue == null)
           {
               result.Success = false;
               result.Data = "Object type is missed!";
           }
           else
           {
               result.Success = true;
               result.Data = oValue;
           }

           return result;
       }
    }
}
