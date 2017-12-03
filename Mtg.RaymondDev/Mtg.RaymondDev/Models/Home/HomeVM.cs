using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mtg.RaymondDev.Models.Home
{
    public class HomeVM
    {
        public IEnumerable<SetVM> Sets { get; set; }
    }
}