using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mtg.RaymondDev.Models.Sets
{
    public class CardVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string ManaCost { get; set; }

        public string Rarity { get; set; }

        /// <summary>
        /// Temporarily added to make adding large quantities of cards to a collection easier
        /// </summary>
        public int AmountToAdd { get; set; }

        public decimal? Price { get; set; }
    }
}