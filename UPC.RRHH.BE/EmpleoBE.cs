using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.RRHH.BE
{
    public class EmpleoBE
    {
        public int codigo { get; set; } = 0;
        public string nombre { get; set; }
        public decimal salario_minimo { get; set; }
        public decimal salario_maximo { get; set; }
    }
}
