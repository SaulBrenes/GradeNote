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

        public void CrearAsistencia(Asistencia asistencia, int idgrupo)
        {
            dbAsistencia.idgrupo = idgrupo;
            dbAsistencia.Insertar(asistencia);
        }

        public System.Data.DataTable ObtenerFechasAsistencias(int idgrupo)
        {
            dbAsistencia.idgrupo = idgrupo;
            return dbAsistencia.ObtenerAsistencias();
        }

        //Obtiene los datos del datagridview del frmAsistencia donde estan los detalles de los estudiantes
        public System.Data.DataTable ObtenerTableAsistenciaEstudiante(string date, int idgrupo)
        {
            string sentencia = $"SELECT apellidos as Apellidos, nombres as Nombres, Asistencias.tipo as Tipo FROM Estudiantes " +
                $"INNER JOIN Asistencias on Asistencias.id_estudiante = Estudiantes.id AND Asistencias.fecha = \"{date}\" AND Estudiantes.id_grupo = {idgrupo} ORDER BY apellidos";
            return dbAsistencia.loadData(sentencia);
        }

        //public List<Asistencia> ObtenterListaAsistencia()
        //{

        //}
    }
}
