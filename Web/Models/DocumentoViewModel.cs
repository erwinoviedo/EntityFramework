using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Models
{
    public class DocumentoViewModel
    {
        [Required(ErrorMessage = "El codigo CITE es requerido.")]
        [StringLength(5, ErrorMessage = "El codigo CITE no puede contener mas de 5 caracteres")]
        public string CITE { get; set; }

        public string Referencia { get; set; }

        [Display(Name = "Destinatario")]
        public int DestinatarioId { get; set; }

        [Display(Name = "Emisor")]
        public int EmisorId { get; set; }

        [Display(Name = "Redirigido")]
        public int RedirigidoId { get; set; }

        [Display(Name = "Fecha Creacion")]
        public DateTime FechaCreacion { get; set; }

        [Display(Name = "Fecha Recepcion")]
        public DateTime FechaRecepcion { get; set; }

        [Display(Name = "Fecha Redirigido")]
        public DateTime RedirigidoFecha { get; set; }

        public List<SelectListItem> ListaPersonas { get; set; }
    }
}