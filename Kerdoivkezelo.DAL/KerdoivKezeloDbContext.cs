using Kerdoivkezelo.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kerdoivkezelo.DAL
{
    public class KerdoivKezeloDbContext : DbContext
    {
        public KerdoivKezeloDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Kerdes> Kerdesek { get; set; }
        public DbSet<KerdesElem> KerdesElemek { get; set; }
        public DbSet<KerdesOsszerendeles> KerdesOsszerendelesek { get; set; }
        public DbSet<Kerdoiv> Kerdoivek { get; set; }
        public DbSet<KerdoivKitoltese> KerdoivKitoltesek { get; set; }
        public DbSet<ValaszElem> ValaszElemek{ get; set; }
        public DbSet<ValaszOsszerendeles> ValaszOsszerendelesek{ get; set; }
        protected  override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ValaszOsszerendeles>().HasKey(r => new {r.ValaszElemId, r.KerdesId});
            modelBuilder.Entity<KerdesOsszerendeles>().HasKey(r => new { r.KerdesId, r.KerdesElemId});
            modelBuilder.Entity<KerdoivKitoltese>().HasKey(r => new { r.FelhasznaloId, r.KerdoivId});

            //modelBuilder.Entity<ValaszOsszerendeles>().HasMany("Kerdes");
        }
    }
}
