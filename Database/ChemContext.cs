using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LabNotes
{
     public class ChemContext : DbContext
    {
        public DbSet<Compound> Compounds { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Element> Elements { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=models.db");
    }
}
