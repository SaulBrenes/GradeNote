using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Asistencia
    {
        public Int64 id {get; set;}
        public Int64 id_estudiante { get; set; }
        public DateTime fecha { get; set; }
        public TipoAsistencia tipo { get; set; }
    }
}
