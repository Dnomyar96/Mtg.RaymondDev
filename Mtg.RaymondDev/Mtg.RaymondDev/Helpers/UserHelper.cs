using Mtg.Data;
using Mtg.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mtg.RaymondDev.Helpers
{
    public class UserHelper
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public const string CURRENTUSER = "currentUser";

        public static void SetCurrentUser(User user)
        {
            HttpContext.Current.Session[CURRENTUSER] = new UserHelper
            {
                Id = user.Id,
                UserName = user.UserName
            };
        }

        public static UserHelper GetCurrentUser()
        {
            return (UserHelper)HttpContext.Current.Session[CURRENTUSER];
        }

        public static User GetCurrentDbUser(Context context)
        {
            var user = (UserHelper)HttpContext.Current.Session[CURRENTUSER];

            return context.Users.SingleOrDefault(u => u.Id == user.Id);
        }

        public static void ClearCurrentUser()
        {
            HttpContext.Current.Session[CURRENTUSER] = null;
        }
    }
}