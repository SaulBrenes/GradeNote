using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class MateriaDB : ConexionDB, Crud<Materia>
    {
        public bool Insertar(Materia nuevoObjeto)
        {
            string sentencia = $"INSERT INTO Materias(id_grupo,nombre) VALUES (\"{nuevoObjeto.id_grupo}\",\"{nuevoObjeto.nombre}\")";
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

        public bool Editar(Materia nuevoObjeto)
        {
            string sentencia = $"UPDATE Materias SET nombre=\"{nuevoObjeto.nombre}\" WHERE id ={nuevoObjeto.id}";
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
            string sentencia = $"DELETE FROM Materias WHERE id ={id}";
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
        public System.Data.DataTable ObtenerMateriaDeGrupo(int id)
        {
            string sentencia = $"SELECT nombre as Nombre FROM Materias WHERE id_grupo ={id}";
            return loadData(sentencia);
        }

        public List<Materia> ObtenerListaDeTodos(int id)
        {
            string sentencia = $"SELECT * FROM Materias WHERE id_grupo ={id}";
            DataTable dt = loadData(sentencia);
            return ConvertirDataTabletoClase<Materia>(dt);
        }

        public List<Materia> ObtenerListaDeTodos()
        {
            throw new NotImplementedException();
        }
    }
}
