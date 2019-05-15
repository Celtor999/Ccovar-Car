using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccovar.DataModel
{
    public class Marcas
    {
        public Marca[] marcas { get; set; }
    }

    public class Marca
    {
        public int? id { get; set; }
        public String marca { get; set; }
        public String nacionalidad { get; set; }
    }
}
