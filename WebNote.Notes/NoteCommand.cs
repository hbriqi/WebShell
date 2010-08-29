using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebNote.ViewModels;
using WebShell.ClassLibrary;
using WebShell.Utilities;
using System.Web;
using System.Reflection;

namespace WebNote.Notes
{
    class NoteCommand:ICommand
    {
        static IPresenter presenter = ObjectBuilder.CreateFrom(WebShellConfig.GetCommandType("presenter")).Data as IPresenter;
        #region ICommand Members

        public IResult Execute(string command)
        {
            IResult result = new Result();
            string strCommandName = GetCommand(command);
            string strMethodName = strCommandName.ToLower() + "_" + HttpContext.Current.Request.HttpMethod.ToLower();
            MethodInfo mi = ObjectBuilder.GetMethodInfo(this, strMethodName);
            result = mi.Invoke(this, null) as IResult;

            return result;
        }

        public string GetCommand(string command)
        {
            string strCommandName = command.ToLower();
            if (strCommandName.StartsWith("/"))
            {
                strCommandName = strCommandName.Remove(0, 1);
            }
            if (strCommandName != string.Empty) strCommandName = strCommandName.Split('/')[0];
            else strCommandName = "default";

            return strCommandName;
        }
        #endregion

        public IResult Default_GET()
        {
            IResult result = new Result();
            HttpContext.Current.Session["activeMI"] = "public_notes";
            result = presenter.GetViewHTML("home.htm");

            return result;
        }

        public IResult Default_POST()
        {
            IResult result = new Result();
            dynamic view = new NoteView();
            presenter.SetViewModel( view, HttpContext.Current.Request);

            return result;
        }

        public IResult Add_GET()
        {
            IResult result = new Result();
            HttpContext.Current.Session["activeMI"] = "add_note";
            result = presenter.GetViewHTML("AddNote.htm");

            return result;
        }
    }
}
