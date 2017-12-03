using Mtg.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mtg.RaymondDev.Helpers
{
    public class CurrentUser
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public const string CURRENTUSER = "currentUser";

        public static void SetCurrentUser(User user)
        {
            HttpContext.Current.Session[CURRENTUSER] = new CurrentUser
            {
                Id = user.Id,
                UserName = user.UserName
            };
        }

        public static void ClearCurrentUser()
        {
            HttpContext.Current.Session[CURRENTUSER] = null;
        }
    }
}