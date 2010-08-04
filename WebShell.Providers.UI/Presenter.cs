using System;
using System.Collections.Generic;
using System.Text;
using WebShell.ClassLibrary.Interfaces;
using WebShell.ClassLibrary.Classes;
using System.Web;

namespace WebShell.Providers.UI
{
    public class Presenter<T> : IPresenter<T>
    {
        public IResult GetViewHTML(string resourceName)
        {
            throw new Exception("Method not implemented");
        }

        public IResult GetViewModel(T viewType, HttpRequest httpRequest)
        {
            throw new Exception("Method not implemented");
        }

        public IResult Localize(string resourceName)
        {
            throw new Exception("Method not implemented");
        }
    }
}
