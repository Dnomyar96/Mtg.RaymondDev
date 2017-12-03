using Mtg.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using MySql.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mtg.Data
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class Context : DbContext
    {
        public Context() : base("MtgContext") { }

        public DbSet<Card> Cards { get; set; }
        public DbSet<ForeignName> ForeignNames { get; set; }
        public DbSet<Legality> Legalities { get; set; }
        public DbSet<Ruling> Rulings { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Collection> Collections { get; set; }
    }
}
