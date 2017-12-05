using Mtg.Data;
using Mtg.Data.Models;
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

                var model = new CollectionVM();
                if (collection.Cards != null && collection.Cards.Count > 0)
                {
                    model.Cards = collection.Cards.Select(c => new CardVM
                    {
                        Id = c.Card.Id,
                        Name = c.Card.Name,
                        Amount = c.Amount
                    }).ToList();
                }

                return View(model);
            }
        }

        public ActionResult AddCardToCollection(int cardId)
        {
            using (var context = new Context())
            {
                var collection = _getCollection(context);
                var card = context.Cards.SingleOrDefault(c => c.Id == cardId);

                if (card == null)
                    return HttpNotFound();

                if (collection.Cards.Any(c => c.Card.Id == card.Id))
                {
                    collection.Cards.Single(c => c.Card.Id == card.Id).Amount++;
                }
                else
                {
                    collection.Cards.Add(new CollectionCard
                    {
                        Collection = collection,
                        Card = card,
                        Amount = 1
                    });
                }

                context.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        private Collection _getCollection(Context context)
        {
            var user = UserHelper.GetCurrentDbUser(context);
            var collection = context.Collections.SingleOrDefault(c => c.User.Id == user.Id);

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