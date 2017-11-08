using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using Web.Models;

namespace Web.Controllers
{
    public class DocumentosController : Controller
    {
        // GET: Documentos
        public ActionResult Index()
        {
            var appContext = new ApplicationContext();
            var model = new DocumentoListaViewModel();
            model.Documentos = appContext.Documentos.ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult Filtro(DocumentoListaViewModel filtro)
        {
            var appContext = new ApplicationContext();
            var model = new DocumentoListaViewModel();
            model.Documentos = appContext.Documentos
                .Where(documento=> documento.Referencia.Contains(filtro.Referencia))
                .ToList();
            return View("Index",model);
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
            else
            {
                var appContext = new ApplicationContext();
                model.ListaPersonas = appContext.AgendaPersonas.Select(ap => new SelectListItem
                {
                    Text = ap.Nombre,
                    Value = ap.Id.ToString()
                }).ToList();

                return View(model);
            }
        }

        public ActionResult Editar(int id)
        {
            var applicationContext = new ApplicationContext();
            var documento = applicationContext.Documentos.Where(d => d.Id == id).Single();
            var modelo = new Models.DocumentoViewModel();
            modelo.CITE = documento.CITE;
            modelo.DestinatarioId = documento.DestinatarioId;
            modelo.EmisorId = documento.EmisorId;            
            modelo.FechaCreacion = documento.FechaCreacion;
            modelo.FechaRecepcion = documento.FechaRecepcion;
            modelo.RedirigidoFecha = documento.RedirigidoFecha;
            modelo.RedirigidoId = documento.RedirigidoId;
            modelo.Referencia = documento.Referencia;
            modelo.ListaPersonas = applicationContext.AgendaPersonas.Select(ap => new SelectListItem
            {
                Text = ap.Nombre,
                Value = ap.Id.ToString()
            }).ToList();
            return View(modelo);
        }
        [HttpPost]
        public ActionResult Editar(Models.DocumentoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var applicationContext = new ApplicationContext();
                var documento = applicationContext.Documentos.Where(d => d.Id == model.Id).Single();

                documento.CITE = model.CITE;
                documento.Referencia = model.Referencia;
                documento.DestinatarioId = model.DestinatarioId;
                documento.EmisorId = model.EmisorId;
                documento.FechaCreacion = model.FechaCreacion;
                documento.FechaRecepcion = model.FechaRecepcion;
                documento.RedirigidoFecha = model.RedirigidoFecha;

                applicationContext.SaveChanges();

                //Redireccionar a la vista principal
                return RedirectToAction("Index", "Documentos");
            }
            else
            {
                var appContext = new ApplicationContext();
                model.ListaPersonas = appContext.AgendaPersonas.Select(ap => new SelectListItem
                {
                    Text = ap.Nombre,
                    Value = ap.Id.ToString()
                }).ToList();
                return View(model);
            }
        }
    }
}