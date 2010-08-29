using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebNote.ViewModels
{
   public class NoteView
    {
       public string Title { get; set; }
       public string IsPublic { get; set; }
       public string NoteText { get; set; }
       public string Tag { get; set; }
    }
}
