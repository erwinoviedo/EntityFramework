using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class DocumentoViewModel
    {
        [Required(ErrorMessage = "El codigo CITE es requerido.")]
        [StringLength(5, ErrorMessage = "El codigo CITE no puede contener mas de 5 caracteres")]
        public string CITE { get; set; }

        public string Referencia { get; set; }
    }
}