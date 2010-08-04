using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace WebShell.ClassLibrary.Interfaces
{
    public interface IPresenter<T>
    {
        IResult GetViewModel(T viewType, HttpRequest httpRequest);
        IResult GetViewHTML(string resourceName);
        IResult Localize(string resourceName);
    }
}

