using System;
using System.Collections.Generic;

namespace Entidades
{
    public class Materia
    {
        public Int64 id { get; set; }
        public Int64 id_grupo { get; set; }
        public string nombre { get; set; }
        public List<Evaluacion> evaluacionesIParcial { get; set; }
        public List<Evaluacion> evaluacionesIIParcial { get; set; }
        public List<Evaluacion> evaluacionesIIIParcial { get; set; }
        public List<Evaluacion> evaluacionesIVParcial { get; set; }
    }
}
