using System;
using System.Collections.Generic;

namespace Entidades
{
    public class Evaluacion
    {
        public Int64 id { get; set; }
        public Int64 id_materia { get; set; }
        public string nombre { get; set; }
        public Int64 valor { get; set; }
        public Int64 numeroParcial { get; set; }
        public List<Nota> notas { get; set; }
    }
}
