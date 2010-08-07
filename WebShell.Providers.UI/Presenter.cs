using System;
using System.Collections.Generic;
using System.Text;
using WebShell.ClassLibrary.Interfaces;
using WebShell.ClassLibrary.Classes;
using System.Web;
using System.Reflection;
using System.Text.RegularExpressions;
using System.IO;

namespace WebShell.Providers.UI
{
    public class Presenter:IPresenter
    {
        public IResult GetViewHTML(string resourceName)
        {
            IResult result= null;
            //TODO: add try catch blocks => High
            string rPath=HttpContext.Current.Server.MapPath("html/"+resourceName);
            string strResourceText = File.ReadAllText(rPath);
            string strFinalText = ParsResourceText(strResourceText);
            return result; 
            
        }

        private string ParsResourceText(string strResourceText)
        {
            SubstituteInclude(strResourceText);
            if (Regex.Match(strResourceText, "\\{%\\s?extends \\\"\\w*\\.?\\w*\\\"\\s?%\\}").Length > 0)
            {
            }

            //TODO: remove string.empty
            return string.Empty;
        }

        private void SubstituteInclude(string strResourceText)
        {
            throw new NotImplementedException();
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
