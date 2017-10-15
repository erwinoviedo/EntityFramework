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
    }
}