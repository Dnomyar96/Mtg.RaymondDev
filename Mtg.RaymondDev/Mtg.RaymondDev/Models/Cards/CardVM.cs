using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mtg.RaymondDev.Models.Cards
{
    public class CardVM
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Set { get; set; }

        public string ManaCost { get; set; }

        public string Rarity { get; set; }

        public int Amount { get; set; }
    }
}