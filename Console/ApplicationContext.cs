using Entidates;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEF
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("cnn")
        {
            //Constructor
        }
        public DbSet<Documento> Documentos { get; set; }
    }

}
