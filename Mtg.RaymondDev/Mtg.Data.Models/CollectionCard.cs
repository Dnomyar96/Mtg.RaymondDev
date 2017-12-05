using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mtg.Data.Models
{
    public class CollectionCard
    {
        public int Id { get; set; }

        public virtual Card Card { get; set; }

        public int Amount { get; set; }

        public virtual Collection Collection { get; set; }
    }
}
