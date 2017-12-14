using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mtg.Data.Models
{
    public class CardPricing
    {
        public int Id { get; set; }

        public Card Card { get; set; }

        public decimal Price { get; set; }
    }
}
