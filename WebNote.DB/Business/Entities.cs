using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebNote.DB;

namespace WebNote.DB.Business
{
    public static class WebNote
    {
        public static void tt()
        {
            using (WebNoteEntities e = new WebNoteEntities())
            {
                User u = new User();
                u.Roles.Add(new Role { Id = 2 });
            }
        }
    }
}
