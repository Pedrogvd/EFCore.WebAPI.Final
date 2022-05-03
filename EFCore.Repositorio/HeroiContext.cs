using EFCore.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Repositorio
{
    public class HeroiContext : DbContext
    {
        public HeroiContext()
        {
                
        }

        public HeroiContext(DbContextOptions<HeroiContext> options) : base(options) { }

        public DbSet<Heroi> Herois { get; set; }

        public DbSet<Batalha> Batalhas { get; set; }
    
        public DbSet<Arma> Armas { get; set; }

        public DbSet<HeroiBatalha> HeroisBatalhas { get; set; }

        public DbSet<IdentidadeSecreta> IdentidadeSecretas { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
       /*     optionsBuilder.UseSqlServer("Password=sa123456.;Persist Security Info=True;User ID=sa;Initial Catalog=HeroApp;Data Source=CPX-XT08NX9AP07");*/
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeroiBatalha>(entity =>
            {
                /*pra desabilitar a exclusão em cascata*/
               foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                {
                    relationship.DeleteBehavior = DeleteBehavior.Restrict;
                }

                entity.HasKey(e => new { e.BatalhaId, e.HeroiId });

            });

        }

    }
}
