using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mtg.RaymondDev.Models.Sets
{
    public class SetsVM
    {
        public string Name { get; set; }

        public IEnumerable<CardVM> Cards { get; set; }
    }
}