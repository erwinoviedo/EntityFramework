namespace Migraciones.Migrations
{
    using Entidades;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Diagnostics;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Migraciones.MigrationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Migraciones.MigrationContext context)
        {
            //  This method will be called after migrating to the latest version.
            
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //{
            //    System.Diagnostics.Debugger.Launch();
            //}

            //Definir Id's fijos para objetos que se usaran como referencia de llaves foraneas haciendo seeding 

            var destinatario  = new AgendaPersona { Id = 1, Nombre = "Maria",  Apellido = "Espinoza" };
            var emisor        = new AgendaPersona { Id = 2, Nombre = "Jose",   Apellido = "Delgado" };
            var redirigido    = new AgendaPersona { Id = 3, Nombre = "Adrian", Apellido = "Hurtado" };

            context.AgendaPersonas.AddOrUpdate(
                persona=>new { persona.Nombre, persona.Apellido }, 
                destinatario,
                emisor,
                redirigido,
                new AgendaPersona { Nombre = "Ruben", Apellido = "Aguilera" },
                new AgendaPersona { Nombre = "Maria Magdalena", Apellido = "Alpire" }
            );            
            
            context.Documentos.AddOrUpdate(
                documento=>documento.CITE,
                new Documento { CITE = "ABC", DestinatarioId = destinatario.Id, EmisorId = emisor.Id, RedirigidoId = redirigido.Id, FechaCreacion = new DateTime(2017,2,15), FechaRecepcion = new DateTime(2017, 2, 15) , HaSidoRecibido = false,RecibidoPor="", Referencia ="Ref 1.1 - Texto de test", RedirigidoFecha = new DateTime(2017,3,15)},
                new Documento { CITE = "ABD", DestinatarioId = destinatario.Id, EmisorId = emisor.Id, RedirigidoId = redirigido.Id, FechaCreacion = new DateTime(2017, 2, 15), FechaRecepcion = new DateTime(2017, 2, 15), HaSidoRecibido = false, RecibidoPor = "", Referencia = "Ref 2.1 - Texto de test", RedirigidoFecha = new DateTime(2017, 3, 15) },
                new Documento { CITE = "ABE", DestinatarioId = destinatario.Id, EmisorId = emisor.Id, RedirigidoId = redirigido.Id, FechaCreacion = new DateTime(2017, 2, 15), FechaRecepcion = new DateTime(2017, 2, 15), HaSidoRecibido = false, RecibidoPor = "", Referencia = "Ref 3.1 - Texto de test", RedirigidoFecha = new DateTime(2017, 3, 15) },
                new Documento { CITE = "ABF", DestinatarioId = destinatario.Id, EmisorId = emisor.Id, RedirigidoId = redirigido.Id, FechaCreacion = new DateTime(2017, 2, 15), FechaRecepcion = new DateTime(2017, 2, 15), HaSidoRecibido = false, RecibidoPor = "", Referencia = "Ref 4.1 - Texto de test", RedirigidoFecha = new DateTime(2017, 3, 15) },
                new Documento { CITE = "ABG", DestinatarioId = destinatario.Id, EmisorId = emisor.Id, RedirigidoId = redirigido.Id, FechaCreacion = new DateTime(2017, 2, 15), FechaRecepcion = new DateTime(2017, 2, 15), HaSidoRecibido = false, RecibidoPor = "", Referencia = "Ref 1.1 - Texto de test", RedirigidoFecha = new DateTime(2017, 3, 15) }
            );

            context.SaveChanges();
        }
    }
}
