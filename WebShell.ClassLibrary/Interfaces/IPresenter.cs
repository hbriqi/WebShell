using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace WebShell.ClassLibrary.Interfaces
{
    public interface IPresenter
    {
        void SetViewModel(ref Type viewType, HttpRequest httpRequest);
        IResult GetViewHTML(string resourceName);
        IResult Localize(string resourceName);

    }
}

