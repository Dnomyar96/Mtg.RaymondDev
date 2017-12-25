using Mtg.Data.Models;
using Mtg.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mtg.Data.Extensions
{
    public static class CardExtensions
    {
        public static ColorIdentity GetColorIdentity(this Card card)
        {
            if (IsMultiColored(card))
                return ColorIdentity.Multi;

            if (card.ManaCost != null && card.ManaCost.Contains("B"))
                return ColorIdentity.Black;

            if (card.ManaCost != null && card.ManaCost.Contains("W"))
                return ColorIdentity.White;

            if (card.ManaCost != null && card.ManaCost.Contains("U"))
                return ColorIdentity.Blue;

            if (card.ManaCost != null && card.ManaCost.Contains("G"))
                return ColorIdentity.Green;

            if (card.ManaCost != null && card.ManaCost.Contains("R"))
                return ColorIdentity.Red;

            return ColorIdentity.Colorless;
        }

        public static bool IsMultiColored(this Card card)
        {
            if (card.ManaCost != null
                && ((card.ManaCost.Contains("B}{") && !card.ManaCost.Contains("B}{B}"))
                || (card.ManaCost.Contains("W}{") && !card.ManaCost.Contains("W}{W}"))
                || (card.ManaCost.Contains("U}{") && !card.ManaCost.Contains("U}{U}"))
                || (card.ManaCost.Contains("G}{") && !card.ManaCost.Contains("G}{G}"))
                || (card.ManaCost.Contains("R}{") && !card.ManaCost.Contains("R}{R}"))))
            {
                return true;
            }

            return false;
        }
    }
}
