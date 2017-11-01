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
        public int Id { get; set; }

        [Required(ErrorMessage = "El codigo CITE es requerido.")]
        [StringLength(5, ErrorMessage = "El codigo CITE no puede contener mas de 5 caracteres")]
        public string CITE { get; set; }

        public string Referencia { get; set; }

        [Display(Name = "Destinatario")]
        public int DestinatarioId { get; set; }

        [Display(Name = "Emisor")]
        public int? EmisorId { get; set; }

        [Display(Name = "Redirigido")]
        public int RedirigidoId { get; set; }

        [Required(ErrorMessage = "El campo Fecha Creacion es requerido")]
        [Display(Name = "Fecha Creacion")]
        public DateTime FechaCreacion { get; set; }

        [Required(ErrorMessage = "El campo Fecha Recepcion es requerido")]
        [Display(Name = "Fecha Recepcion")]
        public DateTime FechaRecepcion { get; set; }

        [Required(ErrorMessage = "El campo Fecha Redirigido es requerido")]
        [Display(Name = "Fecha Redirigido")]
        public DateTime RedirigidoFecha { get; set; }

        public List<SelectListItem> ListaPersonas { get; set; }
    }
}