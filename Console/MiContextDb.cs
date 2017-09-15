using Console.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    public class MiContextDb: DbContext
    {
        public DbSet<Estudiante> Estudiante { get; set; }
        public DbSet<Contacto> Contactos { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public MiContextDb():base("MiConnectionString")
        {

        }
    }

}
