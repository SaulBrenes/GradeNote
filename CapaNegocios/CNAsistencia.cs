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

        public bool ValidarAsistencia(string fecha, int idgrupo)
        {
            if (dbAsistencia.loadData($"SELECT * FROM Asistencias WHERE fecha = \"{fecha}\" AND id_grupo = {idgrupo}").Rows.Count == 0)
            {
                return false;
            }

            return true;
        }

        public System.Data.DataTable ObtenerFechasAsistencias(int idgrupo)
        {
            dbAsistencia.idgrupo = idgrupo;
            return dbAsistencia.ObtenerAsistencias();
        }

        //Obtiene los datos del datagridview del frmAsistencia donde estan los detalles de los estudiantes
        public System.Data.DataTable ObtenerTableAsistenciaEstudiante(string date, int idgrupo)
        {
            string sentencia = $"SELECT codigo as Codigo, apellidos as Apellidos, nombres as Nombres, Asistencias.tipo as Tipo FROM Estudiantes " +
                $"INNER JOIN Asistencias on Asistencias.id_estudiante = Estudiantes.id AND Asistencias.fecha = \"{date}\" AND Estudiantes.id_grupo = {idgrupo} ORDER BY apellidos";
            return dbAsistencia.loadData(sentencia);
        }

        public void Elimnar(string fecha, int idgrupo)
        {
            string sentencia = $"DELETE FROM Asistencias WHERE fecha =\"{fecha}\" AND id_grupo= {idgrupo}";
            dbAsistencia.ExecuteQuery(sentencia);
        }

        public DateTime CrearFecha(string s)
        {
           string[] fecha = s.Split(new char[] { '/', ' '});
            //año, mes y dia
            return new DateTime(Int32.Parse(fecha[2]), Int32.Parse(fecha[1]), Int32.Parse(fecha[0]));
        }

        public void CambiarAsitencia(TipoAsistencia t, int id, string fecha)
        {
            dbAsistencia.CambiarTipoAsistencia(t, id, fecha);
        }

        public float ObtenerPorcentajeAsistenciasDelEstudiante(int id)
        {
            return dbAsistencia.ObtenerAsistenciasEstudiante(id);
        }
    }
}
