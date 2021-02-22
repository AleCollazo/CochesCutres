using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CochesCutres.Models
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string NIF { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
    }
}