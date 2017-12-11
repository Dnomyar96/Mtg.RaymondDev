using Mtg.Data;
using Mtg.RaymondDev.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mtg.RaymondDev.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new HomeVM();

            using(var context = new Context())
            {
                var sets = context.Sets.Select(s => new SetVM
                {
                    Id = s.Id,
                    Name = s.Name,
                    ReleaseDate = s.ReleaseDate,
                    SetCode = s.Code,
                }).ToList().OrderByDescending(s => s.ReleaseDate);

                model.Sets = sets;
            }

            return View(model);
        }
    }
}