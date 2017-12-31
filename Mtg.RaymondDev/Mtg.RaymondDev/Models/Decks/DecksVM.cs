using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mtg.RaymondDev.Models.Decks
{
    public class DecksVM
    {
        public IEnumerable<DeckVM> Decks { get; set; }
    }
}