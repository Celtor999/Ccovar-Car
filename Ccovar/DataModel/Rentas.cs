using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccovar.DataModel
{
    public class Rentas
    {
        public Renta[] rentas { get; set; }
    }

    public class Renta
    {
        public int? id { get; set; }
        public int? id_cliente { get; set; }
        public int? id_auto { get; set; }
        public double deposito { get; set; }
        public double total { get; set; }
        public string estatus_pago { get; set; }
        public DateTime fecha_recibo { get; set; }
        public DateTime fecha_entrego { get; set; }
        public int? kilometraje_inicial { get; set; }
        public int? kilometraje_final { get; set; }
        public string observaciones { get; set; }



    }
    
}
