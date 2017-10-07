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

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.AgendaPersonas.AddOrUpdate(
                persona=>new { persona.Nombre, persona.Apellido }, 
                new AgendaPersona { Nombre = "Maria", Apellido ="Espinoza" },
                new AgendaPersona { Nombre = "Jose", Apellido = "Delgado" },
                new AgendaPersona { Nombre = "Adrian", Apellido = "Hurtado" },
                new AgendaPersona { Nombre = "Ruben", Apellido = "Aguilera" },
                new AgendaPersona { Nombre = "Maria Magdalena", Apellido = "Alpire" }
            );

            
            context.SaveChanges();
        }
    }
}
