using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccovar.DataModel
{
    public class Clientes
    {
        public Cliente[] clientes { get; set; }
    }

    public class Cliente
    {
        public int? id { get; set; }
        public String nombre { get; set; }
        public String apellido_paterno { get; set; }
        public String apellido_materno { get; set; }
        public String calle { get; set; }
        public String numero { get; set; }
        public String colonia { get; set; }
        public String codigo_postal { get; set; }
        public String ciudad { get; set; }
        public String estado { get; set; }
        public String pais { get; set; }
        public String numero_liciencia { get; set; }
        public String nacionalidad { get; set; }
        public String telefono { get; set; }
    }
}
