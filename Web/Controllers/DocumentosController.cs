using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
namespace Web.Controllers
{
    public class DocumentosController : Controller
    {
        // GET: Documentos
        public ActionResult Index()
        {
            var appContext = new ApplicationContext();
            List<Entidades.Documento> listaDocumentos = appContext.Documentos.ToList();
            return View(listaDocumentos);
        }

        public ActionResult Nuevo()
        {
            var appContext = new ApplicationContext();
            var agendaPersonas = new List<SelectListItem>();
            var model = new Models.DocumentoViewModel();
            //Cargar de la BD la lista y pasarla al modelo
            agendaPersonas = appContext.AgendaPersonas.Select(ap=> new SelectListItem {
                Text = ap.Nombre ,
                Value = ap.Id.ToString()
            }).ToList();
            model.ListaPersonas = agendaPersonas;
            return View(model);
        }
        [HttpPost]
        public ActionResult Nuevo(Models.DocumentoViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Escribir codigo para guardar a la BD.
                var appContext = new ApplicationContext();
                //Pasar los datos del modelo a la entidad Documento
                var nuevoDocumento = new Entidades.Documento();

                nuevoDocumento.CITE = model.CITE;
                nuevoDocumento.Referencia = model.Referencia;
                nuevoDocumento.DestinatarioId = model.DestinatarioId;
                nuevoDocumento.EmisorId = model.EmisorId;
                nuevoDocumento.RedirigidoId = model.RedirigidoId;
                nuevoDocumento.FechaCreacion = model.FechaCreacion;
                //Valores por defecto (para que permita el guardado)

                nuevoDocumento.FechaRecepcion = model.FechaRecepcion;
                nuevoDocumento.RedirigidoFecha = model.RedirigidoFecha;
                
                appContext.Documentos.Add(nuevoDocumento);
                appContext.SaveChanges();
                //Redireccionar a la vista principal
                return RedirectToAction("Index", "Documentos");
            }
            return View(model);
        }
    }
}