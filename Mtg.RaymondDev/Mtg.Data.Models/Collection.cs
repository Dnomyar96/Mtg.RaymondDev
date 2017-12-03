using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mtg.Data.Models
{
    public class Collection
    {
        public int Id { get; set; }

        public ICollection<Card> Cards { get; set; }

        public User User { get; set; }
    }
}
