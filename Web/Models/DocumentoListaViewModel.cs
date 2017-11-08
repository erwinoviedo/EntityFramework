using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class DocumentoListaViewModel
    {
        public string Referencia { get; set; }
       // public DocumentoFiltroViewModel Filtro { get; set; }
        public List<Entidades.Documento> Documentos { get; set; }
    }

    public class DocumentoFiltroViewModel
    {
        public string Referencia { get; set; }
    }
}