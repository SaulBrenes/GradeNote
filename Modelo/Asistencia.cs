using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    class Asistencia
    {
        private DateTime fecha;
        private Tipo tipo;

        public enum Tipo
        {
            Ausente = 0,
            Presente = 1,
            Justificado =2, 
            Tardio = 3
        }
    }
}
