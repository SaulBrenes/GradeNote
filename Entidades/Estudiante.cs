using System;
using System.Collections.Generic;

namespace Entidades
{
    public class Estudiante
    {
        public Int64 id { get; set; }
        public Int64 id_grupo { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string codigo { get; set; }
        public List<Asistencia> asistencias { get; set; }
        public float pasistencias { get; set; }

        public double promedio { get; set; }
    }
}
