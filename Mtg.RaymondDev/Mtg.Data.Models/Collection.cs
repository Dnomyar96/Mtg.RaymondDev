using Mtg.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mtg.Data.Models
{
    public class Collection
    {
        public Collection()
        {
            Cards = new List<CollectionCard>();
        }

        public int Id { get; set; }

        public virtual ICollection<CollectionCard> Cards { get; set; }

        public virtual User User { get; set; }

        public string Name { get; set; }

        public CollectionType Type { get; set; }
    }
}
