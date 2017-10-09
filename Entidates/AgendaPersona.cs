using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class AgendaPersona : ObjectIdentificable
    {
        [MaxLength(50)]
        [Required]
        public string Nombre { get; set; }

        [MaxLength(100)]
        [Required]
        public string Apellido { get; set; }
    }
}
