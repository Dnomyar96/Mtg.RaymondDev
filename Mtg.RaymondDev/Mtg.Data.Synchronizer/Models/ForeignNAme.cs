using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mtg.Data.Synchronizer.Models
{
    public class ForeignName
    {
        public string Language { get; set; }

        public string Name { get; set; }

        public int MultiverseId { get; set; }
    }
}
