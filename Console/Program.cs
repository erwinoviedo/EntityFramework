
using Entidates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEF
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new ApplicationContext();
            var documento = new Documento()
            {
                CITE = "C 02-17",
                FechaRecepcion = new DateTime(2017, 02, 01),
                RedirigidoFecha = new DateTime(2017, 03, 05),
                Referencia = "Pago Comisiones Coordinador"
            };
            context.Documentos.Add(documento);

            context.SaveChanges();

            
        }
    }
}
