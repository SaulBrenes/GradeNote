using CapaDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class CNEstudiantes
    {
        EstudianteDB dBEstudiante = new EstudianteDB();

        public void AgregarEstudiante(Estudiante newest)
        {
            dBEstudiante.Insertar(newest);
        }

        public DataTable TablaEstudiantesDelGrupo(int idGrupo)
        {
            dBEstudiante.idGrupo = idGrupo;
            return dBEstudiante.ObtenerEstudiantes();
        }

        public List<Estudiante> ListaEstudiantes(int idGrupo)
        {
            dBEstudiante.idGrupo = idGrupo;
            return dBEstudiante.ObtenerListaDeTodos();
        }
    }
}
