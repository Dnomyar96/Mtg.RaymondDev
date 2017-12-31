using Mtg.Data;
using Mtg.Data.Models.Enums;
using Mtg.RaymondDev.Models.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mtg.Data.Extensions;

namespace Mtg.RaymondDev.Controllers
{
    public class CardsController : Controller
    {
        // GET: Cards
        public ActionResult Index()
        {
            using(var context = new Context())
            {
                var sets = context.Sets;
                var model = new SetsVM
                {
                    Sets = sets.Select(s => new SetVM
                    {
                        Id = s.Id,
                        Name = s.Name
                    }).OrderByDescending(s => s.Id).ToList()
                };

                return View(model);
            }
        }

        public ActionResult GetCardsBySets(IEnumerable<int> setIds)
        {
            using(var context = new Context())
            {
                var sets = context.Sets.Where(s => setIds.Contains(s.Id));
                var cards = sets.SelectMany(s => s.Cards);

                var model = new CardsVM
                {
                    Cards = cards.Select(c => new CardVM
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Set = c.Set.Name,
                        ManaCost = c.ManaCost,
                        Rarity = c.Rarity,
                        Amount = 0
                    }).ToList()
                };

                return View("Cards", model);
            }
        }

        public ActionResult GetCards(SetsVM vm)
        {
            using (var context = new Context())
            {
                var setIdsToInclude = vm.Sets.Where(s => s.IncludeBlack || s.IncludeBlue || s.IncludeColorless || s.IncludeGreen
                    || s.IncludeMulti || s.IncludeRed || s.IncludeWhite).Select(s => s.Id);
                var setsToInclude = context.Sets.Where(s => setIdsToInclude.Contains(s.Id)).ToList();

                var cards = setsToInclude.SelectMany(s => s.GetCardsWithColorIdentity(_getColorIdentitiesToInclude(vm, s.Id)));
                var model = new CardsVM
                {
                    Cards = cards.Select(c => new CardVM
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Set = c.Set.Name,
                        ManaCost = c.ManaCost,
                        Rarity = c.Rarity,
                        Amount = 0
                    }).OrderBy(c => c.Rarity).ToList()
                };

                return View("Cards", model);
            }
        }

        private IEnumerable<ColorIdentity> _getColorIdentitiesToInclude(SetsVM sets, int setId)
        {
            var set = sets.Sets.SingleOrDefault(s => s.Id == setId);
            var colors = new List<ColorIdentity>();

            if (set.IncludeBlack)
                colors.Add(ColorIdentity.Black);

            if (set.IncludeBlue)
                colors.Add(ColorIdentity.Blue);

            if (set.IncludeColorless)
                colors.Add(ColorIdentity.Colorless);

            if (set.IncludeGreen)
                colors.Add(ColorIdentity.Green);

            if (set.IncludeMulti)
                colors.Add(ColorIdentity.Multi);

            if (set.IncludeRed)
                colors.Add(ColorIdentity.Red);

            if (set.IncludeWhite)
                colors.Add(ColorIdentity.White);

            return colors;
        }
    }
}