using Mtg.Data;
using Mtg.Data.Models;
using Mtg.Data.Models.Enums;
using Mtg.RaymondDev.Helpers;
using Mtg.RaymondDev.Models.Decks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mtg.RaymondDev.Controllers
{
    public class DecksController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = UserHelper.GetCurrentUser();

            using (var context = new Context())
            {
                if (user == null || context.Users.SingleOrDefault(u => u.Id == user.Id) == null)
                    filterContext.Result = RedirectToAction("Index", "Login");
            }
        }

        // GET: Decks
        public ActionResult Index()
        {
            using(var context = new Context())
            {
                var decks = context.Collections.Where(c => c.Type == CollectionType.Deck).ToList();

                var model = new DecksVM
                {
                    Decks = decks.Select(d => new DeckVM
                    {
                        Id = d.Id,
                        Name = d.Name
                    })
                };

                return View(model);
            }
        }

        public ActionResult CreateDeck()
        {
            var model = new DeckVM
            {
                Id = 0,
                Name = ""
            };
            return View(model);
        }

        public ActionResult SaveDeck(DeckVM vm)
        {
            bool isNew = vm.Id == 0;
            
            using(var context = new Context())
            {                
                if(isNew)
                {
                    var collection = new Collection
                    {
                        Name = vm.Name,
                        User = UserHelper.GetCurrentDbUser(context),
                        Type = CollectionType.Deck
                    };

                    context.Collections.Add(collection);
                }

                context.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        public ActionResult ShowDeck(int id)
        {
            using(var context = new Context())
            {
                var deck = context.Collections.SingleOrDefault(c => c.Id == id && c.Type == CollectionType.Deck);

                if (deck == null)
                    return HttpNotFound();

                var model = new DeckVM
                {
                    Id = deck.Id,
                    Name = deck.Name,
                    Cards = deck.Cards.Select(c => new CardVM {
                        Id = c.Card.Id,
                        Name = c.Card.Name,
                        Amount = c.Amount
                    })
                };

                return View(model);
            }
        }
    }
}