using System;
using System.Collections.Generic;
using System.Text;
using WebShell.ClassLibrary.Interfaces;
using WebShell.ClassLibrary.Classes;
using System.Web;
using System.Reflection;

namespace WebShell.Providers.UI
{
    public class Presenter:IPresenter
    {
        public IResult GetViewHTML(string resourceName)
        {
            throw new Exception("Method not implemented");
        }

        public void SetViewModel(ref Type viewType, HttpRequest httpRequest)
        {
            foreach(PropertyInfo propertiy in viewType.GetType().GetProperties())
            {
                if (propertiy.CanWrite)
                {
                    propertiy.SetValue(viewType, "test view model", null);
                }
            }
           
        }

        public IResult Localize(string resourceName)
        {
            throw new Exception("Method not implemented");
        }
    }
}
