using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mtg.RaymondDev.Models.Collection
{
    public class CollectionVM
    {
        public IEnumerable<CardVM> Cards { get; set; }
    }
}