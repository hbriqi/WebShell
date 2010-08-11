using System;
using System.Collections.Generic;
using System.Text;
using WebShell.ClassLibrary.Interfaces;
using WebShell.ClassLibrary.Classes;
using System.Web;
using WebShell.Utilities.Configuration;
using WebNote.ViewModels;

namespace WebNote.Users
{
   public class UsersCommand:ICommand
    {
        #region ICommand Members

        public IResult Execute(string command)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public string GetCommand(string command)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IResult Execute_GET(string command)
        {
            IResult result = new Result();
            IPresenter presenter = ObjectBuilder.CreateFrom(WebShellConfig.GetPresenterType()).Data as IPresenter;
            dynamic view=new UserView();
            view.Name = "Hisham";
            result = presenter.GetViewHTML("AddUser.htm", view);

            return result;
        }

        public IResult Execute_POST(string command)
        {
            IResult result = new Result();
            HttpRequest httpRequest = HttpContext.Current.Request;
            IPresenter presenter = ObjectBuilder.CreateFrom(WebShellConfig.GetPresenterType()).Data as IPresenter;
            dynamic view = new UserView();
            presenter.SetViewModel(view, httpRequest);
            result.Data= "Welcom "+view.Name;
            result.Success = true;
            return result;
        }

        public IResult Execute_PUT(string command)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IResult Execute_DELETE(string command)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
