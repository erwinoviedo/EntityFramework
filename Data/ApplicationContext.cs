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

        //Connection string "cnn" esta definido en el archivo app.config
        public ApplicationContext() : base("cnn")
        {
            //Constructor.            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Fluent API
            //Fluent API es otra manera de configurar las clases de dominio o entidades.
            //Provee mayor funcionalidad que los atributos DataAnotations
            //mayor informacion :
            //http://www.entityframeworktutorial.net/code-first/fluent-api-in-code-first.aspx
            //https://msdn.microsoft.com/en-us/library/jj591617(v=vs.113).aspx

            //Enlazar las propiedades de navegacion con sus respectivos Ids
            //Se debe realizar mediante Fluent API porque no se lo puede realizar con atributos DataAnotations

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
