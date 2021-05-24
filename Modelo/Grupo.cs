using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    class Grupo
    {
        private int id;
        private int anioElectivo;
        private string grado;
        private string seccion;
        private string turno;
        private List<Materia> materias;
        private List<Estudiante> estudiantes;
    }
}
