using Mtg.Data.Models;
using Mtg.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mtg.Data.Extensions
{
    public static class SetExtension
    {
        public static IEnumerable<Card> GetCardsWithColorIdentity(this Set set, IEnumerable<ColorIdentity> colors)
        {
            var cards = new List<Card>();

            if (colors.Contains(ColorIdentity.Multi))
                foreach (var card in set.Cards.Where(c => c.IsMultiColored()))
                    cards.Add(card);

            if (colors.Contains(ColorIdentity.Colorless))
                foreach (var card in set.Cards.Where(c => c.GetColorIdentity() == ColorIdentity.Colorless))
                    cards.Add(card);

            if (colors.Contains(ColorIdentity.Black))
                foreach (var card in set.Cards.Where(c => c.GetColorIdentity() == ColorIdentity.Black))
                    cards.Add(card);

            if (colors.Contains(ColorIdentity.Blue))
                foreach (var card in set.Cards.Where(c => c.GetColorIdentity() == ColorIdentity.Blue))
                    cards.Add(card);

            if (colors.Contains(ColorIdentity.Green))
                foreach (var card in set.Cards.Where(c => c.GetColorIdentity() == ColorIdentity.Green))
                    cards.Add(card);

            if (colors.Contains(ColorIdentity.Red))
                foreach (var card in set.Cards.Where(c => c.GetColorIdentity() == ColorIdentity.Red))
                    cards.Add(card);

            if (colors.Contains(ColorIdentity.White))
                foreach (var card in set.Cards.Where(c => c.GetColorIdentity() == ColorIdentity.White))
                    cards.Add(card);

            return cards;
        }
    }
}
