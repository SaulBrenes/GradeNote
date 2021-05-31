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
        private int id;
        private int id_grupo;
        private string nombre;
        private List<Evaluacion> evaluaciones;

        public int Id { get => id; set => id = value; }
        public int Id_grupo { get => id_grupo; set => id_grupo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}
