﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mtg.Data.Models
{
    public class Ruling
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Text { get; set; }
    }
}
