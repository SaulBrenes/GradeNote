using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Evaluacion
    {
        private int id;
        private int id_materia;
        private string nombre;
        private int valor;
        private int numeroParcial;
        private List<Nota> notas;

        public int Id { get => id; set => id = value; }
        public int Id_materia { get => id_materia; set => id_materia = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Valor { get => valor; set => valor = value; }
        public int NumeroParcial { get => numeroParcial; set => numeroParcial = value; }
        public List<Nota> Notas { get => notas; set => notas = value; }
    }
}
