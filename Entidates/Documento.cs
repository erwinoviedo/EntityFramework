using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidates
{
    [Table("Documentos")]
    public class Documento
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Referencia { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public string CITE { get; set; }
        public string Emisor { get; set; }
        public string Destinatario { get; set; }
        public string Redirigido { get; set; }
        public DateTime RedirigidoFecha { get; set; }
        public string RecibidoPor { get; set; }

    }
}
