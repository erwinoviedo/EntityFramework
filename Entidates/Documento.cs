using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Table("Documentos")]
    public class Documento
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250)]
        public string Referencia { get; set; }
        public DateTime FechaRecepcion { get; set; }
        [Column(Order = 2)]
        public string CITE { get; set; }

        public int? EmisorId { get; set; }
        public virtual AgendaPersona Emisor { get; set; }

        public int DestinatarioId { get; set; }
        public virtual AgendaPersona Destinatario { get; set; }

        public int RedirigidoId { get; set; }
        public virtual AgendaPersona Redirigido { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime RedirigidoFecha { get; set; }
        public string RecibidoPor { get; set; }
        public bool HaSidoRecibido { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime FechaCreacion { get; set; }
    }
}
