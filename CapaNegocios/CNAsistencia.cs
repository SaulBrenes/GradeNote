using CapaDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    
    public class CNAsistencia
    {
        public AsistenciaDB dbAsistencia = new();

        public void CrearAsistencia(Asistencia asistencia)
        {
            dbAsistencia.Insertar(asistencia);
        }

        public System.Data.DataTable ObtenerFechasAsistencias(int idEstudiante)
        {
            dbAsistencia.idEstudiante = idEstudiante;
            return dbAsistencia.ObtenerAsistencias();
        }
    }
}
