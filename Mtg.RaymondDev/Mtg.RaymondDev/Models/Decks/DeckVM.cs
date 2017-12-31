using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mtg.RaymondDev.Models.Decks
{
    public class DeckVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<CardVM> Cards { get; set; }
    }
}