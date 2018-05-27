using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace TravelYourWay.Models
{
    public class TravelYourWayContext : DbContext
    {
        public TravelYourWayContext() : base("DefaultConnection")
        {
        }

        public DbSet<Agencija> agencijas { get; set; }
        public DbSet<Dogadjaji> dogadjajis { get; set; }
        public DbSet<Korisnik> korisniks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<TravelYourWay.Models.Administrator> Administrators { get; set; }

        public System.Data.Entity.DbSet<TravelYourWay.Models.PrijavaNaDogadjaj> PrijavaNaDogadjajs { get; set; }
    }
}