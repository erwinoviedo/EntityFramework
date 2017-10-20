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
            return View();
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
                //Valores por defecto (para que permita el guardado)
                nuevoDocumento.DestinatarioId = 1;
                nuevoDocumento.EmisorId = 2;
                nuevoDocumento.FechaCreacion = DateTime.Today;
                nuevoDocumento.FechaRecepcion = DateTime.Today;
                nuevoDocumento.RedirigidoFecha = DateTime.Today;
                nuevoDocumento.RedirigidoId = 3;
                
                appContext.Documentos.Add(nuevoDocumento);
                appContext.SaveChanges();
                //Redireccionar a la vista principal
                return RedirectToAction("Index", "Documentos");
            }
            return View(model);
        }
    }
}