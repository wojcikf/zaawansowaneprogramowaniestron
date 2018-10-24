using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektWojcik.Models
{
    public class KsiegarniaKontekst : DbContext
    {

        public DbSet<Ksiazka> Ksiazki {get;set;}
        public DbSet<Gatunek> Gatunki { get; set; }

        public DbSet<Autor> Autorzy { get; set; }
        public DbSet<AutorKsiazki> AutorzyKsiazek { get; set; }
        public DbSet<Wydawca> Wydawcy { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AutorKsiazki>()
                .HasKey(v => new { v.IdAutora, v.IdKsiazki });

            modelBuilder.Entity<AutorKsiazki>()
                .HasOne(v => v.Autor)
                .WithMany(a => a.Ksiazki)
                .HasForeignKey(ba => ba.IdAutora);

            modelBuilder.Entity<AutorKsiazki>()
                .HasOne(v => v.Ksiazka)
                .WithMany(a => a.Autorzy)
                .HasForeignKey(ba => ba.IdKsiazki);
        }
        public KsiegarniaKontekst(DbContextOptions<KsiegarniaKontekst> opcje): base(opcje) {}

    }
}
