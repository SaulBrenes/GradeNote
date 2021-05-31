using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Asistencia
    {
        private int id;
        private int id_estudiante;
        private DateTime fecha;
        private TipoAsistencia tipo;

        public int Id { get => id; set => id = value; }
        public int Id_estudiante { get => id_estudiante; set => id_estudiante = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public TipoAsistencia Tipo { get => tipo; set => tipo = value; }
    }
}
