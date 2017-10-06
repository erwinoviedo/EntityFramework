# Entity Framework
Projecto para el curso de EntityFramerwork

## Comandos de EF Code First Migrations

En caso de que exista cambios en el modelo, se debe crear una nueva migracion con el comando  **Add-Migration** seguido de un titulo que de significado a la migracion, por ejemplo:

**Add-Migration AdicionadoCampoFechaCreacionEnUsuarios**

Para crear o actualizar una base de datos, se ejecuta el comando **update-database** 

## Database Seeding

Seeding es el proceso de inicializar o crear una base de datos con datos populados.

Este generalmente es un proceso automatizado que se ejecuta al momento de inicializar una aplicacion.

Los datos suelen ser ficticios y son una representacion pequeña de los posibles datos y escenarios que pueden haber en la base de datos.

En Entity Framework existe un metodo Seed, dentro de la clase Configuration, el mismo que se ejecuta en cada comando **update-database** lo que permite que al momento de actualizar o crear nuestra base de datos, injectemos los datos que queremos se inicialize la base de datos. 

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
        }
    }
    
**NOTA.-**
Si al ejecutar un comando PowerShell les aparece un error de : "File D:\EntityFramework-master\EntityFramework-master\packages\EntityFramework.6.1.3\tools\init.ps1 cannot be loaded. The file D:\EntityFramework-master\EntityFramework-master\packages\EntityFramework.6.1.3\tools\init.ps1 is not digitally signed. You cannot run this script on the current system" significa que el script no esta marcado como confiable por su sistema. 

Para desbloquearlo abrir la carpeta donde esta descargado el codigo fuente carpeta : 

- EntityFramework-master\packages\EntityFramework.6.1.3\tools\

Y hacer click derecho -> Propiedades en la pestaña General al final hacer click en la casilla Desbloquear los siguientes archivos:

- EntityFramework.PowerShell.dll
- EntityFramework.PowerShell.Utility.dll
- EntityFramework.psm1 
- init.ps1

Una vez desbloqueados, reiniciar el visual studio

