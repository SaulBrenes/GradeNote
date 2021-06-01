using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class EstudianteDB : ConexionDB, Crud<Estudiante>
    {
        public int idGrupo{get; set;}

        public bool Insertar(Estudiante nuevoObjeto)
        {
            string sentencia = $"INSERT INTO Estudiantes(id_grupo,nombres,apellidos,codigo) VALUES (\"{nuevoObjeto.id_grupo}\",\"{nuevoObjeto.nombres}\",\"{nuevoObjeto.apellidos}\",\"{nuevoObjeto.codigo}\")";
            try
            {
                this.ExecuteQuery(sentencia);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool Editar(Estudiante nuevoObjeto)
        {
            string sentencia = $"UPDATE Estudiantes SET id_grupo=\"{nuevoObjeto.id_grupo}\",nombres=\"{nuevoObjeto.nombres}\", apellidos=\"{nuevoObjeto.apellidos}\", codigo=\"{nuevoObjeto.codigo}\"  WHERE id ={nuevoObjeto.id}";
            try
            {
                this.ExecuteQuery(sentencia);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool Eliminar(int id)
        {
            string sentencia = $"DELETE FROM Estudiantes WHERE id ={id}";
            try
            {
                this.ExecuteQuery(sentencia);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public System.Data.DataTable ObtenerEstudiantes()
        {
            string setencia = $"SELECT apellidos as Apellidos, nombres as Nombres, codigo as codigo FROM Estudiantes WHERE id_grupo = {idGrupo} ORDER BY apellidos";
            return loadData(setencia);
        }


        public List<Estudiante> ObtenerListaDeTodos()
        {
            System.Data.DataTable dt = ObtenerEstudiantes();
            return ConvertirDataTabletoClase<Estudiante>(dt);
        }
    }
}
