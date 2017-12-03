using Mtg.Data;
using Mtg.Data.Models;
using Mtg.RaymondDev.Helpers;
using Mtg.RaymondDev.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mtg.RaymondDev.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View(new LoginVM());
        }

        public ActionResult Login(LoginVM vm)
        {
            using (var context = new Context())
            {
                var user = context.Users.SingleOrDefault(u => u.UserName == vm.UserName);

                if (user == null || !HashHelper.Verify(vm.Password, user.Password))
                    return View("Index", new LoginVM { ErrorMessage = "Invalid combination of username and password" });

                CurrentUser.SetCurrentUser(user);

                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Logout()
        {
            CurrentUser.ClearCurrentUser();

            return RedirectToAction("Index");
        }

        public ActionResult RegisterAdmin()
        {             
            var userName = "Admin";
            var passWord = "mtgAdmin";

            var hash = HashHelper.Hash(passWord);

            using(var context = new Context())
            {
                if (!context.Users.Any(u => u.UserName == userName))
                {
                    context.Users.Add(new User
                    {
                        UserName = userName,
                        Password = hash
                    });

                    context.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
    }
}