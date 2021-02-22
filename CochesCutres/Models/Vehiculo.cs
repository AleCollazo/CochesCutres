using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace CochesCutres.Models
{
    public class Vehiculo
    {
        public int IdVehiculo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int NumPuertas { get; set; }
        public string Color { get; set; }
        public float Kilometros { get; set; }
        public Tipo TipoVehiculo { get; set; }
        public int MesesGarantia { get; set; }
        public bool EstaStock { get; set; }
        public Image Foto { get; set; }
        


        public enum Tipo { Utilitario, coupé, familiar, SUV, industrial}
    }
}