using System;
using System.Collections.Generic;
using System.Text;
using WebShell.ClassLibrary.Interfaces;
using WebShell.ClassLibrary.Classes;
using System.Web;
using System.Reflection;
using System.Text.RegularExpressions;
using System.IO;
using WebShell.Providers.UI.Properties;

namespace WebShell.Providers.UI
{
    public class Presenter:IPresenter
    {
        public IResult GetViewHTML(string resourceName, dynamic viewType=null)
        {
            Result result= new Result();
            try
            {
                if (resourceName.StartsWith("/")) resourceName = resourceName.Remove(0, 1);
                string rPath = HttpContext.Current.Request.PhysicalApplicationPath + "html\\" + resourceName;
                string strResourceText = File.ReadAllText(rPath);
                string strFinalText = ParsResourceText(strResourceText, viewType);
                result.Data = strFinalText;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                throw ex;
                //TODO: log the error
            }
                return result; 
            
        }

        private string ParsResourceText(string strResourceText, dynamic viewType=null)
        {
            string strBasicText = string.Empty;
            //check for {% extends "base.htm" %} Tag and then substitute block cont
            Match matchExtends=Regex.Match(strResourceText, Settings.Default.Reg_Extend);
            if (matchExtends.Success)
            {
                Match matchFilePath = Regex.Match(matchExtends.Value, Settings.Default.Reg_FilePath);
                string strBasePath = string.Empty;
                if (matchFilePath.Success) strBasePath = matchFilePath.Groups[0].Value;
                strBasePath = strBasePath.Replace("\"", "");// remove "" from file path
                strBasePath = HttpContext.Current.Request.PhysicalApplicationPath + "html\\" + strBasePath;
                string strBaseContent = File.ReadAllText(strBasePath);
                //substitute blocks content, {% block someblock %} some content {% endblock %}
                foreach (Match matchBaseBlock in Regex.Matches(strBaseContent, Settings.Default.Reg_BlockStart))
                {
                    string strBlockName = Regex.Replace(matchBaseBlock.Value, Settings.Default.Reg_BlockName, "");
                    string strPattern = Settings.Default.Reg_BlockStartSearch.Replace("\\w*", strBlockName)
                        + Settings.Default.Reg_BlockContent
                        + Settings.Default.Reg_BlockEndSearch;
                    Match matchResourcBlock = Regex.Match(strResourceText, strPattern);
                    if (matchResourcBlock.Success)
                    {
                        strBaseContent = strBaseContent.Replace(matchBaseBlock.Value, matchResourcBlock.Value);
                    }

                }
                //set basic text for next manpulation
                strBasicText = Regex.Replace(strBaseContent, Settings.Default.Reg_BlockEnd, "");
            }
            else
            {
                strBasicText = strResourceText;
            }

            //substitute {% include "somefile.ext" %}
            foreach (Match matchInclude in Regex.Matches(strBasicText, Settings.Default.Reg_Include))
            {
                string strFilePath = Regex.Match(matchInclude.Value, Settings.Default.Reg_FilePath).Value.Replace("\"", "").Replace("\'", "");
                strFilePath = HttpContext.Current.Request.PhysicalApplicationPath + strFilePath;
                string strIncludeText = File.ReadAllText(strFilePath);
                //replce tag with actualy content
                strBasicText = strBasicText.Replace(matchInclude.Value, strIncludeText);
            }

            //sustitute varaibles {{variable}}
            string strFinalText = strBasicText;
            if (viewType != null)
            {
                foreach (Match matchVariable in Regex.Matches(strFinalText, Settings.Default.Reg_VarPattern))
                {
                    string strPropName = Regex.Replace(matchVariable.Value, Settings.Default.Reg_VarName, "");
                    PropertyInfo proInfo = viewType.GetType().GetProperty(strPropName);
                    if (proInfo != null)
                    {
                        strFinalText = strFinalText.Replace(matchVariable.Value, proInfo.GetValue(viewType, null).ToString());
                    }
                }
            }
           
            return strFinalText;
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
