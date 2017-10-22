using SgCon.API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace SgCon.API.EntityFramework
{
    public class SgConContext : DbContext
    {
        public SgConContext() : base("SgConConnection")
        {

        }

        public DbSet<Condominio> Condominio { get; set; }
        public DbSet<Predio> Predio { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Condominio>()
                .ToTable("Condominio");

            modelBuilder.Entity<Predio>().ToTable("Predio");
            modelBuilder.Entity<Predio>()
                .HasRequired(p => p.Condominio)
                .WithMany(p => p.Predios)
                .HasForeignKey<int>(p => p.IdCondominio);


        }

    }
}