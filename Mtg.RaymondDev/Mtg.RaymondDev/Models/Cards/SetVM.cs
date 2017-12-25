using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mtg.RaymondDev.Models.Cards
{
    public class SetVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IncludeBlack { get; set; }

        public bool IncludeBlue { get; set; }

        public bool IncludeWhite { get; set; }

        public bool IncludeRed { get; set; }

        public bool IncludeGreen { get; set; }

        public bool IncludeColorless { get; set; }

        public bool IncludeMulti { get; set; }
    }
}