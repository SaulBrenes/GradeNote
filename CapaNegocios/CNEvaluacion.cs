using CapaDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class CNEvaluacion
    {
        EvaluacionDB evaluacionDB = new();

        public System.Data.DataTable ObtenerEvaluacionesDeMateria(int idMateria)
        {
            evaluacionDB.idMateria = idMateria;
            return evaluacionDB.ObtenerEvaluaciones();
        }

        public List<Evaluacion> ObetenerListaDeEvaluaciones(int idMateria)
        {
            evaluacionDB.idMateria = idMateria;
            return evaluacionDB.ObtenerListaDeTodos();
        }

        public void CrearEvaluacion(Evaluacion e)
        {
            evaluacionDB.Insertar(e);
        }

        public void EliminarEvaluacion(long idEvaluacion)
        {
            evaluacionDB.Eliminar((int)idEvaluacion);
        }
    }
}
