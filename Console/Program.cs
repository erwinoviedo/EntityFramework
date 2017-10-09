
using Data;
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

            AdicionarDocumentoConGraphs();
            Console.Read();
        }
        static void MostrarCantidadDeDocumentosRepository()
        {
            var miContexto = new ApplicationContext();

            var cantidadTotal = miContexto.Documentos.Count();

            Console.WriteLine($"Cantidad de documentos : {cantidadTotal}");
        }
        static void MostrarCantidadDeDocumentos()
        {
            var miContexto = new ApplicationContext();

            var cantidadTotal = miContexto.Documentos.Count();

            Console.WriteLine($"Cantidad de documentos : {cantidadTotal}");
        }
        static void MostrarElPrimerDocumento()
        {
            var miContexto = new ApplicationContext();

            var primerDocumento = miContexto.Documentos.First();

            Console.WriteLine($"Primer documento CITE: {primerDocumento.CITE}; Nombre Emisor: {primerDocumento.Emisor.Nombre}");
        }

        static void ObtenerLosDocumentosDeGestionActual()
        {
            var miContexto = new ApplicationContext();

            var resultado = miContexto.Documentos.Where(documento => documento.FechaCreacion.Year == DateTime.Today.Year).ToList();

            foreach (var documento in resultado)
            {
                Console.WriteLine($"documento CITE: {documento.CITE}; FechaCreacion: {documento.FechaCreacion.ToShortDateString()}");
            }
        }

        static void AdicionarDocumentoSimple()
        {
            var nuevoDocumento = new Documento
            {
                CITE = "Simple",
                DestinatarioId = 1,
                EmisorId = 2,
                RedirigidoId = 3,
                FechaCreacion = new DateTime(2017, 2, 15),
                FechaRecepcion = new DateTime(2017, 2, 15),
                HaSidoRecibido = false,
                RecibidoPor = "",
                Referencia = "",
                RedirigidoFecha = new DateTime(2017, 3, 15)
            };

            var miContexto = new ApplicationContext();
            miContexto.Documentos.Add(nuevoDocumento);

            miContexto.SaveChanges();
        }

        static void AdicionarDocumentoConGraphs()
        {
            var nuevoDocumento = new Documento
            {
                CITE = "Simple",
                Destinatario = new AgendaPersona { Nombre=  "Graphs", Apellido ="Ejemplo"},
                Emisor = new AgendaPersona { Nombre = "Graphs1", Apellido = "Ejemplo1" } ,
                Redirigido =  new AgendaPersona { Nombre = "Graphs2", Apellido = "Ejemplo2" },                
                FechaCreacion = new DateTime(2017, 2, 15),
                FechaRecepcion = new DateTime(2017, 2, 15),
                HaSidoRecibido = false,
                RecibidoPor = "",
                Referencia = "",
                RedirigidoFecha = new DateTime(2017, 3, 15)
            };

            var miContexto = new ApplicationContext();
            miContexto.Documentos.Add(nuevoDocumento);

            miContexto.SaveChanges();
        }
    }
}
