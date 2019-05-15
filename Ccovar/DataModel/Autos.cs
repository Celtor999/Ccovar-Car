using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccovar.DataModel
{
    public class Autos
    {
        public Auto[] autos { get; set; }
    }

    public class Auto
    {
        public int? id { get; set; }
        public int? id_marca { get; set; }
        public String modelo { get; set; }
        public String año { get; set; }
        public String color { get; set; }
        public String tipo { get; set; }
        public String capacidad { get; set; }
        public String disponibilidad { get; set; }
        public String razon_disponibilidad { get; set; }
        public String fecha_disponibilidad { get; set; }
        public String kilometraje { get; set; }
        public String folio_segro { get; set; }
        public String observaciones { get; set; }
        public String renta_fija { get; set; }
        public String renta_dia { get; set; }
        public String marca { get; set; }
    }
}
