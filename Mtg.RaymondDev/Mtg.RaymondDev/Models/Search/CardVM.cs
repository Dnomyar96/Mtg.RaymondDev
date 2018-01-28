using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mtg.RaymondDev.Models.Search
{
    public class CardVM
    {
        public string Name { get; set; }

        public string Set { get; set; }

        public string ManaCost { get; set; }

        public string Type { get; set; }

        public string Text { get; set; }

        public int Amount { get; set; }
    }
}