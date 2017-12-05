using Mtg.Data;
using Mtg.RaymondDev.Models.Sets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mtg.RaymondDev.Controllers
{
    public class SetsController : Controller
    {
        public ActionResult SetDetails(int id)
        {
            var model = new SetsVM();

            using(var context = new Context())
            {
                var set = context.Sets.Where(s => s.Id == id).FirstOrDefault();

                if (set == null)
                    return new HttpNotFoundResult();

                model.Name = set.Name;
                model.Cards = set.Cards.Select(c => new CardVM
                {
                    Id = c.Id,
                    Name = c.Name,
                    ManaCost = c.ManaCost,
                    Type = c.Type,
                    Rarity = c.Rarity
                }).ToList();
            }

            return View("SetDetails", model);
        }
    }
}