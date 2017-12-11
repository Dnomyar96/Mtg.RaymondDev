using Mtg.Data;
using Mtg.Data.Models;
using Mtg.Data.Models.Enums;
using Mtg.RaymondDev.Helpers;
using Mtg.RaymondDev.Models.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Mtg.RaymondDev.Controllers
{
    public class CollectionController : Controller
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
        
        public ActionResult Index()
        {
            using(var context = new Context())
            {
                var collection = _getCollection(context);

                var model = new CollectionVM
                {
                    CardCount = collection.Cards.Sum(c => c.Amount)
                };

                if (collection.Cards != null && collection.Cards.Count > 0)
                {
                    model.Cards = collection.Cards.Select(c => new CardVM
                    {
                        Id = c.Card.Id,
                        Name = c.Card.Name,
                        Set = c.Card.Set.Name,
                        SetId = c.Card.Set.Id,
                        Amount = c.Amount
                    }).ToList();
                }

                return View(model);
            }
        }

        public ActionResult EditCardDetails(int id)
        {
            using(var context = new Context())
            {
                var collection = _getCollection(context);
                CardVM model;

                if(collection.Cards.Any(c => c.Card.Id == id))
                {
                    var card = collection.Cards.SingleOrDefault(c => c.Card.Id == id);

                    model = new CardVM
                    {
                        Id = card.Card.Id,
                        Name = card.Card.Name,
                        Set = card.Card.Set.Name,
                        Amount = card.Amount,
                        IsNew = false
                    };
                }
                else
                {
                    var card = context.Cards.SingleOrDefault(c => c.Id == id);

                    if (card == null)
                        return HttpNotFound();

                    model = new CardVM
                    {
                        Id = card.Id,
                        Name = card.Name,
                        Set = card.Set.Name,
                        Amount = 1,
                        IsNew = true
                    };
                }

                return View("CardDetails", model);
            }
        }

        public ActionResult DeleteCard(int id)
        {
            using(var context = new Context())
            {
                var collection = _getCollection(context);
                var cardToDelete = collection.Cards.SingleOrDefault(c => c.Card.Id == id);

                if (cardToDelete == null)
                    return HttpNotFound();

                collection.Cards.Remove(cardToDelete);
                context.CollectionCards.Remove(cardToDelete);

                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult SaveCardDetails(CardVM model)
        {
            using(var context = new Context())
            {
                var collection = _getCollection(context);

                if (model.IsNew)
                {
                    var card = context.Cards.SingleOrDefault(c => c.Id == model.Id);

                    collection.Cards.Add(new CollectionCard
                    {
                        Collection = collection,
                        Card = card,
                        Amount = model.Amount
                    });
                }
                else
                {
                    collection.Cards.Single(c => c.Card.Id == model.Id).Amount = model.Amount;
                }

                context.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult AddCardsToCollection(Models.Sets.SetsVM model)
        {
            using (var context = new Context())
            {
                var collection = _getCollection(context);

                foreach(var card in model.Cards)
                {
                    if (card.AmountToAdd > 0)
                    {
                        if (collection.Cards.Any(c => c.Card.Id == card.Id))
                        {
                            collection.Cards.Single(c => c.Card.Id == card.Id).Amount += card.AmountToAdd;
                        }
                        else
                        {
                            var dbCard = context.Cards.SingleOrDefault(c => c.Id == card.Id);

                            collection.Cards.Add(new CollectionCard
                            {
                                Collection = collection,
                                Card = dbCard,
                                Amount = card.AmountToAdd
                            });
                        }
                    }
                }

                context.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        private Collection _getCollection(Context context)
        {
            var user = UserHelper.GetCurrentDbUser(context);
            var collection = context.Collections.SingleOrDefault(c => c.User.Id == user.Id && c.Type == CollectionType.UserCollection);

            if (collection == null)
            {
                context.Collections.Add(new Collection { User = user });
                context.SaveChanges();

                collection = context.Collections.SingleOrDefault(c => c.User.Id == user.Id);
            }

            return collection;
        }
    }
}