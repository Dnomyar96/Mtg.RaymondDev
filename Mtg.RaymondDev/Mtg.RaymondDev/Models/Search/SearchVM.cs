using Mtg.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mtg.RaymondDev.Models.Search
{
    public class SearchVM
    {
        public string DescriptionContains { get; set; }

        public string TypeContains { get; set; }

        public IEnumerable<ColorIdentity> ColorIdentities { get; set; }

        public IEnumerable<SelectListItem> ColoridentitiesSelectList { get; set; }
    }
}