using Mtg.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mtg.Data.Synchronizer
{
    class Program
    {
        private static string _path = @"C:\Users\Dnomyar96\Desktop\Mtg\AllSets-x.json";

        static void Main(string[] args)
        {
            Console.WriteLine("Start");

            var serializer = new JsonSerializer();
            Dictionary<string, Models.Set> data = new Dictionary<string, Models.Set>();

            using (var s = File.Open(_path, FileMode.Open))
            using (var sr = new StreamReader(s))
            using (var reader = new JsonTextReader(sr))
            {
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        data = serializer.Deserialize<Dictionary<string, Models.Set>>(reader);
                    }
                }
            }

            foreach (var set in data.OrderBy(x => x.Value.ReleaseDate))
            {
                Console.WriteLine("Inserting set: " + set.Value.Name);

                using (var context = new Context())
                {
                    if (context.Sets.Any(s => s.Name == set.Value.Name))
                    {
                        Console.WriteLine("Skipping set: " + set.Value.Name);
                    }
                    else
                    {
                        var newSet = new Set
                        {
                            Block = set.Value.Block,
                            Booster = set.Value.Booster,
                            Border = set.Value.Border,
                            Code = set.Value.Code,
                            GathererCode = set.Value.GathererCode,
                            MagicCardsInfoCode = set.Value.MagicCardsInfoCode,
                            Name = set.Value.Name,
                            OldCode = set.Value.OldCode,
                            OnlineOnly = set.Value.OnlineOnly,
                            ReleaseDate = set.Value.ReleaseDate,
                            Type = set.Value.Type,
                            Cards = new List<Card>()
                        };
                        foreach (var card in set.Value.Cards)
                        {
                            Console.WriteLine("\tInserting card: " + card.Name);

                            var newCard = new Card
                            {
                                Artist = card.Artist,
                                Border = card.Border,
                                CardId = card.Id,
                                Cmc = card.Cmc,
                                ColorIdentity = card.ColorIdentity,
                                Colors = card.Colors,
                                Flavor = card.Flavor,
                                Hand = card.Hand,
                                ImageName = card.ImageName,
                                Layout = card.Layout,
                                Life = card.Life,
                                Loyalty = card.Loyalty,
                                ManaCost = card.ManaCost,
                                MciNumber = card.MciNumber,
                                MultiverseId = card.MultiverseId,
                                Name = card.Name,
                                Names = card.Names,
                                Number = card.Number,
                                OriginalText = card.OriginalText,
                                OriginalType = card.OriginalType,
                                Power = card.Power,
                                Printings = card.Printings,
                                Rarity = card.Rarity,
                                ReleaseDate = card.ReleaseDate,
                                Reserved = card.Reserved,
                                Source = card.Source,
                                Starter = card.Starter,
                                SubTypes = card.SubTypes,
                                SuperTypes = card.SuperTypes,
                                Text = card.Text,
                                TimeShifted = card.TimeShifted,
                                Toughness = card.Toughness,
                                Type = card.Type,
                                Types = card.Types,
                                Variations = card.Variations,
                                WaterMark = card.WaterMark,
                                ForeignNames = new List<ForeignName>(),
                                Legalities = new List<Legality>(),
                                Rulings = new List<Ruling>()
                            };

                            if (card.ForeignNames != null)
                            {
                                foreach (var name in card.ForeignNames)
                                {
                                    var newName = new ForeignName
                                    {
                                        Language = name.Language,
                                        MultiverseId = name.MultiverseId,
                                        Name = name.Name
                                    };

                                    newCard.ForeignNames.Add(newName);
                                }
                            }

                            if (card.Legalities != null)
                            {
                                foreach (var legality in card.Legalities)
                                {
                                    var newLegal = new Legality
                                    {
                                        Format = legality.Format,
                                        LegalityDetail = legality.LegalityDetail
                                    };

                                    newCard.Legalities.Add(newLegal);
                                }
                            }

                            if (card.Rulings != null)
                            {
                                foreach (var ruling in card.Rulings)
                                {
                                    var newRuling = new Ruling
                                    {
                                        Date = ruling.Date,
                                        Text = ruling.Text
                                    };

                                    newCard.Rulings.Add(newRuling);
                                }
                            }

                            newSet.Cards.Add(newCard);
                        }

                        context.Sets.Add(newSet);
                        context.SaveChanges();
                    }
                }
            }

            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
