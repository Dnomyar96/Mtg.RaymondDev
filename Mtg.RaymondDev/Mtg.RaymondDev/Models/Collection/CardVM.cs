﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mtg.RaymondDev.Models.Collection
{
    public class CardVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Set { get; set; }

        public int SetId { get; set; }

        public int Amount { get; set; }

        public bool IsNew { get; set; }

        public decimal? Price { get; set; }
    }
}