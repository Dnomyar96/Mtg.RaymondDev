using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mtg.Data.Models
{
    public class Legality
    {
        public int Id { get; set; }

        public string Format { get; set; }

        public string LegalityDetail { get; set; }
    }
}
