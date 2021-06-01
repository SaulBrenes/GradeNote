using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class EvaluacionDB : ConexionDB, Crud<Evaluacion>
    {
        int idMateria { get; set; }

        public bool Insertar(Evaluacion nuevoObjeto)
        {
            string sentencia = $"INSERT INTO Evaluaciones(id_materia, nombre, valor, numeroParcial) VALUES(\"{nuevoObjeto.id_materia}\", \"{nuevoObjeto.nombre}\", \"{nuevoObjeto.valor}\", \"{nuevoObjeto.numeroParcial}\")";
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

        public bool Editar(Evaluacion nuevoObjeto)
        {
                string sentencia = $"UPDATE Evaluaciones SET id_materia=\"{nuevoObjeto.id_materia}\",nombre=\"{nuevoObjeto.nombre}\", valor=\"{nuevoObjeto.valor}\", numeroParcial=\"{nuevoObjeto.numeroParcial}\" WHERE id ={nuevoObjeto.id}";
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
            string sentencia = $"DELETE FROM Evaluaciones WHERE id ={id}";
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

        public System.Data.DataTable ObtenerEvaluaciones()
        {
            string setencia = $"SELECT * FROM Evaluaciones WHERE id_materia={idMateria}";
            return loadData(setencia);
        }

        public List<Evaluacion> ObtenerListaDeTodos()
        {
            System.Data.DataTable dt = ObtenerEvaluaciones();
            return ConvertirDataTabletoClase<Evaluacion>(dt);
        }
    }
}
