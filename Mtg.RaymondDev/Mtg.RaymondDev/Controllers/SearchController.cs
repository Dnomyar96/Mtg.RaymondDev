using Mtg.Data;
using Mtg.Data.Models;
using Mtg.Data.Models.Enums;
using Mtg.RaymondDev.Helpers;
using Mtg.RaymondDev.Models.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mtg.RaymondDev.Controllers
{
    public class SearchController : Controller
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
            var model = new SearchVM
            {
                DescriptionContains = "",
                TypeContains = "",
                ColorIdentities = new List<ColorIdentity>(),
                ColoridentitiesSelectList = new List<SelectListItem>()
                {
                    new SelectListItem
                    {
                        Text = ColorIdentity.Black.ToString(),
                        Value = ColorIdentity.Black.ToString()
                    },
                    new SelectListItem
                    {
                        Text = ColorIdentity.Blue.ToString(),
                        Value = ColorIdentity.Blue.ToString()
                    },
                    new SelectListItem
                    {
                        Text = ColorIdentity.Green.ToString(),
                        Value = ColorIdentity.Green.ToString()
                    },
                    new SelectListItem
                    {
                        Text = ColorIdentity.Red.ToString(),
                        Value = ColorIdentity.Red.ToString()
                    },
                    new SelectListItem
                    {
                        Text = ColorIdentity.White.ToString(),
                        Value = ColorIdentity.White.ToString()
                    },
                    new SelectListItem
                    {
                        Text = ColorIdentity.Colorless.ToString(),
                        Value = ColorIdentity.Colorless.ToString()
                    },
                    new SelectListItem
                    {
                        Text = ColorIdentity.Multi.ToString(),
                        Value = ColorIdentity.Multi.ToString()
                    }
                }
            };

            return View(model);
        }

        public ActionResult SearchCards(SearchVM vm)
        {
            var searchDescription = !string.IsNullOrWhiteSpace(vm.DescriptionContains);
            var searchType = !string.IsNullOrWhiteSpace(vm.TypeContains);
            var limitColorIdentities = vm.ColorIdentities != null && vm.ColorIdentities.Count() > 0;

            using (var context = new Context())
            {
                var cards = new List<CardVM>();
                var collection = _getCollection(context);

                if (searchDescription)
                {
                    var resultCards = collection.Cards
                        .Where(cc => cc.Card.Text.Contains(vm.DescriptionContains))
                        .Select(c => new CardVM
                        {
                            Name = c.Card.Name,
                            Set = c.Card.Set.Name,
                            ManaCost = c.Card.ManaCost,
                            Type = c.Card.Type,
                            Text = c.Card.Text,
                            Amount = c.Amount
                        })
                        .Where(c => !cards.Contains(c));

                    cards.AddRange(resultCards);
                }

                if (searchType)
                {
                    var resultCards = collection.Cards
                        .Where(cc => cc.Card.Type.Contains(vm.TypeContains))
                        .Select(c => new CardVM
                        {
                            Name = c.Card.Name,
                            Set = c.Card.Set.Name,
                            ManaCost = c.Card.ManaCost,
                            Type = c.Card.Type,
                            Text = c.Card.Text,
                            Amount = c.Amount
                        })
                        .Where(c => !cards.Contains(c));

                    cards.AddRange(resultCards);
                }

                var model = new ResultVM
                {
                    Cards = cards,
                    CardCount = cards.Count
                };

                return View("SearchResult", model);
            }
        }
        
        private Collection _getCollection(Context context)
        {
            var user = UserHelper.GetCurrentDbUser(context);
            var collection = context.Collections.SingleOrDefault(c => c.User.Id == user.Id && c.Type == CollectionType.UserCollection);

            if (collection == null)
            {
                context.Collections.Add(new Collection { User = user, Type = CollectionType.UserCollection });
                context.SaveChanges();

                collection = context.Collections.SingleOrDefault(c => c.User.Id == user.Id);
            }

            return collection;
        }
    }
}