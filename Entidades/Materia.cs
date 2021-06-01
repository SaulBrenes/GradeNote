using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Materia
    {
        public int id { get; set; }
        public int id_grupo { get; set; }
        public string nombre { get; set; }
        public List<Evaluacion> evaluaciones { get; set; }
    }
}
