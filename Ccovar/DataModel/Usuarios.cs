using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccovar.DataModel
{
    public class Usuarios
    {
        public Usuario[] usuarios { get; set; }
    }

    public class Usuario
    {
        public int? id_usuario { get; set; }
        public String usuario { get; set; }
        public String password { get; set; }
        public String nombres { get; set; }
        public String ap_paterno { get; set; }
        public String ap_materno { get; set; }
        public DateTime? fecha_nacimiento { get; set; }
        public DateTime? fecha_ingreso { get; set; }
        public String telefono { get; set; }
        public String calle { get; set; }
        public String numero_casa { get; set; }
        public String colonia { get; set; }
        public DateTime? fecha_creacion { get; set; }
    }
}
