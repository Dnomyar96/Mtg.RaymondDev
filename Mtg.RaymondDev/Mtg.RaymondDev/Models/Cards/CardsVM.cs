using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mtg.RaymondDev.Models.Cards
{
    public class CardsVM
    {
        public IEnumerable<CardVM> Cards { get; set; }
    }
}