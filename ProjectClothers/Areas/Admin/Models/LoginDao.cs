using ProjectClothers.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectClothers.Areas.Admin.Models
{
    public class LoginDao
    {
        DbClothers context = null;

        public LoginDao()
        {
            context = new DbClothers();
        }

        public bool CheckLogin(string username, string password)
        {
            var user = context.Users.Where(m => (m.Username == username) && (m.Password == password)).FirstOrDefault();
            if (user != null)
                return true;
            else return false;
        }
        public List<User> getUsers()
        {
            return context.Users.ToList();
        }
    }
}