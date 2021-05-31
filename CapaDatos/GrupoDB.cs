using Entidades;
using System.Collections.Generic;

namespace CapaDatos
{
    public class GrupoDB : ConexionDB, Crud<Grupo>
    {
        public void CrearGrupo(Grupo nuevoObjeto)
        {
           
        }

        public bool Editar(Grupo nuevoObjeto)
        {
            string sentencia = $"UPDATE Grupos SET nombre=\"{nuevoObjeto.nombre}\",turno=\"{nuevoObjeto.turno}\", anio={nuevoObjeto.anio}  WHERE id ={nuevoObjeto.id}";
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
            string sentencia = $"DELETE FROM Grupos WHERE id ={id} ";
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

        public bool Insertar(Grupo nuevoObjeto)
        {
            string sentencia = $"INSERT INTO Grupos(nombre,turno,anio) VALUES (\"{nuevoObjeto.nombre}\",\"{nuevoObjeto.turno}\",\"{nuevoObjeto.anio}\")";
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

        public System.Data.DataTable ObtenerGrupos()
        {
            string setencia = "SELECT * FROM Grupos";

            return loadData(setencia);
        }

        public List<Grupo> ObtenerListaDeTodos()
        {
            System.Data.DataTable dt = ObtenerGrupos();
            return this.ConvertirDataTabletoClase<Grupo>(dt);
        }
    }
}
