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
        public ActionResult SetDetails(int id, string filterColor = "", bool orderByRarity = false)
        {
            var model = new SetsVM { Id = id };

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
                    Rarity = c.Rarity,
                    AmountToAdd = 0
                }).ToList();
            }

            if (!string.IsNullOrWhiteSpace(filterColor))
            {
                switch (filterColor)
                {
                    case "black":
                        model.Cards = model.Cards.Where(c => c.ManaCost != null && c.ManaCost.Contains("B"));
                        break;
                    case "white":
                        model.Cards = model.Cards.Where(c => c.ManaCost != null && c.ManaCost.Contains("W"));
                        break;
                    case "blue":
                        model.Cards = model.Cards.Where(c => c.ManaCost != null && c.ManaCost.Contains("U"));
                        break;
                    case "green":
                        model.Cards = model.Cards.Where(c => c.ManaCost != null && c.ManaCost.Contains("G"));
                        break;
                    case "red":
                        model.Cards = model.Cards.Where(c => c.ManaCost != null && c.ManaCost.Contains("R"));
                        break;
                    default:
                        break;
                }
            }

            if (orderByRarity)
                model.Cards = model.Cards.OrderBy(c => c.Name).OrderBy(c => c.Rarity);

            return View("SetDetails", model);
        }
    }
}