using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mtg.RaymondDev.Models.Search
{
    public class ResultVM
    {
        public IEnumerable<CardVM> Cards { get; set; }

        public int CardCount { get; set; }
    }
}