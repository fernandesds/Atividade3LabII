using CinemaAppFeics.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CinemaAppFeics.Controllers
{
    public class CinemaContext : DbContext
    {
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Sessao> Sessoes { get; set; }
        public DbSet<Ingresso> Ingressos { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Ator> Atores { get; set; }


        public CinemaContext() : base("name = strCinema")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToOneConstraintIntroductionConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Requesisões para Sala
            modelBuilder.Entity<Sala>().HasKey(s => s.SalaID);
            modelBuilder.Entity<Sala>().Property(s => s.Numero).IsRequired();
            modelBuilder.Entity<Sala>().Property(s => s.Capacidade).IsRequired();
            modelBuilder.Entity<Sala>().Property(s => s.Descricao).IsRequired();

            //Requesisões para Sessao
            modelBuilder.Entity<Sessao>().HasKey(se => se.SessaoID);
            modelBuilder.Entity<Sessao>().Property(se => se.DataHoraInicio).IsRequired();
            modelBuilder.Entity<Sessao>().Property(se => se.DataHoraFim).IsRequired();

            //Requesisões para Ingresso
            modelBuilder.Entity<Ingresso>().HasKey(i => i.IngressoID);
            modelBuilder.Entity<Ingresso>().Property(i => i.Tipo).IsRequired();

            //Requesisões para Filme
            modelBuilder.Entity<Filme>().HasKey(f => f.FilmeID);
            modelBuilder.Entity<Filme>().Property(f => f.Duracao).IsRequired();
            modelBuilder.Entity<Filme>().Property(f => f.Titulo).IsRequired();

            //Requesisões para Ator
            modelBuilder.Entity<Ator>().HasKey(a => a.AtorID);
            modelBuilder.Entity<Ator>().Property(a => a.Nome).IsRequired();

            //Fazendo relacionamento One-To-Many
            modelBuilder.Entity<Sala>()
                .HasMany(se => se.Sessoes)
                .WithRequired(s => s.Sala)
                .HasForeignKey(s => s.SalaID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sessao>()
                .HasMany(i => i.Ingressos)
                .WithRequired(se => se.Sessao)
                .HasForeignKey(se => se.SessaoID)
                .WillCascadeOnDelete(false);

            //Fazendo relacionamento Many-To-Many
            modelBuilder.Entity<Filme>().HasMany<Ator>(f => f.Atores)
                .WithMany(f => f.Filmes)
                .Map(at =>
                {
                    at.MapLeftKey("FilmeID");
                    at.MapRightKey("AtorID");
                    at.ToTable("Atuadores");
                });
        }
    }
}