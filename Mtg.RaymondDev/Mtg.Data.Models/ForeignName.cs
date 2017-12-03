﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mtg.Data.Models
{
    public class ForeignName
    {
        public int Id { get; set; }

        public string Language { get; set; }

        public string Name { get; set; }

        public int MultiverseId { get; set; }
    }
}
