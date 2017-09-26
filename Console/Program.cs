
using Entidades;
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

            context.AgendaPersonas.Add(new AgendaPersona
            {
                Nombre = "RRHH",
                Apellido = "."
            });
            context.AgendaPersonas.Add(new AgendaPersona
            {
                Nombre = "Finanzas",
                Apellido = "."
            });
            context.AgendaPersonas.Add(new AgendaPersona
            {
                Nombre = "Sec. General",
                Apellido = "."
            });

           context.SaveChanges();
           var documento = new Documento()
             {
                 Id = 1,
                 CITE = "C 02-17",
                 FechaRecepcion = new DateTime(2017, 02, 01),
                 RedirigidoFecha = new DateTime(2017, 03, 05),
                 Referencia = "Pago Comisiones Coordinador",
                 DestinatarioId = 1,
                 EmisorId = 2,
                 RedirigidoId = 3
             };
            context.Documentos.Add(documento);
            context.SaveChanges();
        }
    }
}
