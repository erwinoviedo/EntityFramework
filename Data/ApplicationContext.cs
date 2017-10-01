using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<AgendaPersona> AgendaPersonas { get; set; }
        public ApplicationContext() : base("cnn")
        {
            //Constructor.            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Fluent API

            modelBuilder.Entity<Documento>()
                .HasRequired(documento => documento.Destinatario)
                .WithMany()
                .HasForeignKey(dcto => dcto.DestinatarioId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Documento>()
                .HasRequired(documento => documento.Emisor)
                .WithMany()
                .HasForeignKey(dcto => dcto.EmisorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Documento>()
               .HasRequired(documento => documento.Redirigido)
               .WithMany()
               .HasForeignKey(dcto => dcto.RedirigidoId)
               .WillCascadeOnDelete(false);
        }
    }
}
