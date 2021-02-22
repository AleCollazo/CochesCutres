using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CochesCutres.Models
{
    public class OperacionCompraVenta
    {
        public int IdOperacion { get; set; }
        public DateTime Fecha { get; set; }
        public Tipo TipoOperacion { get; set; }
        public int IdEmpleado { get; set; }
        public int IdCliente { get; set; }
        public int IdVehiculo { get; set; }
        public float Precio { get; set; }


        public enum Tipo {Compra, Venta }
    }
}