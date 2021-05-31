using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Estudiante
    {
        private int id;
        private int id_grupo;
        private string nombres;
        private string apellidos;
        private string codigo;
        private List<Asistencia> asistencias;

        public int Id { get => id; set => id = value; }
        public int Id_grupo { get => id_grupo; set => id_grupo = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        internal List<Asistencia> Asistencias { get => asistencias; set => asistencias = value; }
    }
}
