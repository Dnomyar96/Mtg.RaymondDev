using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mtg.RaymondDev.Models.Collection
{
    public class StatsVM
    {
        public string Set { get; set; }

        public int Amount { get; set; }

        public int UniqueAmount { get; set; }
    }
}