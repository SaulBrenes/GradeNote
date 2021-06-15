using System;

namespace Entidades
{
    public class Asistencia
    {
        public Int64 id {get; set;}
        public Int64 id_estudiante { get; set; }
        public string fecha { get; set; }
        public TipoAsistencia tipo { get; set; }
    }
}
