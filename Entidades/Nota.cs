using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Nota
    {
        public Int64 id { get; set; }
        public Int64 id_evaluacion { get; set; }
        public Int64 id_estudiante { get; set; }
        public float valor { get; set; }
    }
}
