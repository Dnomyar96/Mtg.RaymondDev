using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mtg.RaymondDev.Models.Collection
{
    public class CollectionVM
    {
        public int CardCount { get; set; }

        public int UniqueCardCount { get; set; }

        public IEnumerable<StatsVM> Stats { get; set; }
    }
}