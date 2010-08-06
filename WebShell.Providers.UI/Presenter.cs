using System;
using System.Collections.Generic;
using System.Text;
using WebShell.ClassLibrary.Interfaces;
using WebShell.ClassLibrary.Classes;
using System.Web;
using System.Reflection;
using System.Text.RegularExpressions;

namespace WebShell.Providers.UI
{
    public class Presenter:IPresenter
    {
        public IResult GetViewHTML(string resourceName)
        {
            IResult result= null;
            
            return result; 
            
        }

        public void SetViewModel(dynamic viewType, HttpRequest httpRequest)
        {
            foreach (PropertyInfo property in viewType.GetType().GetProperties())
            {
                if (property.CanWrite)
                {
                    //TODO: set values using httpResquest data => High
                    property.SetValue(viewType, "test view model", null);
                }
            }
           
        }

        public IResult Localize(string resourceName)
        {
            throw new Exception("Method not implemented");
        }
    }
}
