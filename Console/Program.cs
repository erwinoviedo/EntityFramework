using Console.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new MiContextDb();

            var bolivia = new Pais
            {
                Nombre = "Bolivia"
            };

            context.Paises.Add(bolivia);

            context.SaveChanges();
        }
    }
}
