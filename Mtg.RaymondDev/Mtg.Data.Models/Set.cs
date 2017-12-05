using Mtg.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mtg.Data.Models
{
    public class Set
    {
        public Set()
        {
            Cards = new List<Card>();
        }

        public int Id { get; set; }

        /// <summary>
        /// The name of the set
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The set's abbreviated code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The code that Gatherer uses for the set. Only present if different than 'code'
        /// </summary>
        public string GathererCode { get; set; }

        /// <summary>
        /// An old style code used by some Magic software. Only present if different than 'gathererCode' and 'code'
        /// </summary>
        public string OldCode { get; set; }

        /// <summary>
        /// The code that magiccards.info uses for the set. Only present if magiccards.info has this set
        /// </summary>
        public string MagicCardsInfoCode { get; set; }

        /// <summary>
        /// When the set was released (YYYY-MM-DD). For promo sets, the date the first card was released
        /// </summary>
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// The type of border on the cards
        /// </summary>
        public Border Border { get; set; }

        /// <summary>
        /// Type of set
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The block this set is in
        /// </summary>
        public string Block { get; set; }

        /// <summary>
        /// Present and set to true if the set was only released online
        /// </summary>
        public bool OnlineOnly { get; set; }

        /// <summary>
        /// Booster contents for this set, see below for details
        /// </summary>
        public dynamic Booster { get; set; }

        /// <summary>
        /// The cards in the set
        /// </summary>
        public virtual ICollection<Card> Cards { get; set; }
    }
}
