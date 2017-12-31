using HtmlAgilityPack;
using Mtg.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mtg.Data.PricingSyncronizer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Started");

            //_ixalan();
            //_kaladesh();
            //_amonkhet();
            //_hourOfDevestation();
            //_theros();
            //_shadowsOverInnistrad();
            //_unstable();
            _magic2015();
            _journeyIntoNyx();

            Console.WriteLine("Done");
            Console.ReadLine();
        }

        private static void _ixalan()
        {
            _getSetPricing("http://www.bazaarofmagic.nl/magic/ixalan-c-2848.html?page=", 243, "Ixalan");
        }

        private static void _kaladesh()
        {
            _getSetPricing("http://www.bazaarofmagic.nl/magic/kaladesh-c-2856.html?page=", 230, "Kaladesh");
        }

        private static void _amonkhet()
        {
            _getSetPricing("http://www.bazaarofmagic.nl/magic/amonkhet-c-2852.html?page=", 238, "Amonkhet");
        }

        private static void _hourOfDevestation()
        {
            _getSetPricing("http://www.bazaarofmagic.nl/magic/hour-of-devastation-c-2850.html?page=", 241, "Hour Of Devestation");
        }

        private static void _theros()
        {
            _getSetPricing("http://www.bazaarofmagic.nl/magic/theros-c-2876.html?page=", 185, "Theros");
        }

        private static void _shadowsOverInnistrad()
        {
            _getSetPricing("http://www.bazaarofmagic.nl/magic/shadows-over-innistrad-c-2860.html?page=", 222, "Shadows Over Innistrad");
        }

        private static void _unstable()
        {
            _getSetPricing("http://www.bazaarofmagic.nl/magic/unstable-c-5994.html?page=", 246, "Unstable");
        }

        private static void _magic2015()
        {
            _getSetPricing("http://www.bazaarofmagic.nl/magic/magic-2015-c-3466.html?page=", 195, "Magic 2015 Core Set");
        }

        private static void _journeyIntoNyx()
        {
            _getSetPricing("http://www.bazaarofmagic.nl/magic/journey-into-nyx-c-2872.html?page=", 189, "Journey into Nyx");
        }

        private static void _getSetPricing(string baseUrl, int setId, string setName)
    {
            using (var context = new Context())
            {
                Console.WriteLine($"{setName}: Started");

                var set = context.Sets.SingleOrDefault(x => x.Id == setId);
                var hasNextPage = true;
                var count = 1;

                while (hasNextPage)
                {
                    Console.WriteLine($"{setName}: page " + count);

                    var web = new HtmlWeb();
                    var document = web.Load(baseUrl + count);

                    var node = document.DocumentNode.SelectNodes("//table[@class='product-listing1']").FirstOrDefault();
                    var nodes = node.SelectNodes(".//tr");
                    foreach (var tr in nodes)
                    {
                        var cardName = "";
                        var price = "";

                        var td = tr.SelectNodes(".//td").Where(x => x.InnerHtml.Contains("<a href=") && !x.InnerHtml.Contains("<img")).FirstOrDefault();
                        if (td != null)
                        {
                            var a = td.SelectNodes(".//a").FirstOrDefault();
                            cardName = a.InnerHtml;
                        }

                        td = tr.SelectNodes(".//td").Where(x => x.InnerHtml.Contains("&euro;")).FirstOrDefault();
                        if (td != null)
                        {
                            price = td.InnerHtml.Replace("&euro;&nbsp;", "");
                        }

                        if (cardName.Contains(" (1)"))
                            cardName = cardName.Replace(" (1)", "");

                        if (!string.IsNullOrWhiteSpace(cardName))
                        {
                            var card = set.Cards.FirstOrDefault(c => c.Name == cardName);
                            var cardPrice = Convert.ToDecimal(price);

                            if (card != null)
                            {
                                var existingCard = context.CardPricing.SingleOrDefault(c => c.Card.Id == card.Id);
                                if (existingCard != null)
                                {
                                    if (existingCard.Price != cardPrice)
                                    {
                                        existingCard.Price = cardPrice;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"{setName}: Skipping {cardName}. Card's price hasn't changed.");
                                    }
                                }
                                else
                                {
                                    var pricing = new CardPricing
                                    {
                                        Card = card,
                                        Price = cardPrice
                                    };

                                    context.CardPricing.Add(pricing);
                                }
                            }
                            else
                            {
                                if (cardName.Contains("token") || cardName.Contains("Token"))
                                    Console.WriteLine($"{setName}: Skipping " + cardName);
                                else
                                    Console.WriteLine($"WARNING: No card found in set with name '{cardName}'");
                            }
                        }
                    }

                    var nextPageButton = document.DocumentNode.SelectNodes("//img").Where(x => x.OuterHtml.Contains("images/icons/page_next.png"));
                    if (nextPageButton != null && nextPageButton.Count() > 0)
                        hasNextPage = true;
                    else
                        hasNextPage = false;

                    count++;
                }

                context.SaveChanges();

                Console.WriteLine($"{setName}: Saved");
            }
        }
    }
}
