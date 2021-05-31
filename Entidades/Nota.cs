using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Nota
    {
        private int id;
        private int id_evaluacion;
        private int id_estudiante;
        private float valor;

        public int Id { get => id; set => id = value; }
        public int Id_evaluacion { get => id_evaluacion; set => id_evaluacion = value; }
        public int Id_estudiante { get => id_estudiante; set => id_estudiante = value; }
        public float Valor { get => valor; set => valor = value; }
    }
}
