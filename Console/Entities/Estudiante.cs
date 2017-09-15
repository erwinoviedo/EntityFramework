using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console.Entities
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Pais PaisNacimiento { get; set; }
        public List<Contacto> Contactos { get; set; }
    }

    public class Pais
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    public class Contacto {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
    }
}
