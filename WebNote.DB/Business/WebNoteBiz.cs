using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebNote.DB;

namespace WebNote.DB.Business
{
    public static class WebNoteBiz
    {
        public static void AddUser(string email, string password)
        {
            using (WebNoteEntities entities = new WebNoteEntities())
            {
                //TODO: encrypt password, Add user role
                User user = new User();
                user.Name = "";
                user.Email = email;
                user.Password = password;

                entities.AddToUsers(user);
                entities.SaveChanges();  
            }

        }
    }
}
