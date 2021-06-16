using CapaDatos;
using Entidades;

namespace CapaNegocios
{
    public class CNNota
    {
        NotasDB notasDB = new();

        public void CrearNota(Nota n, long parcial, long idmateria)
        {
            notasDB.numeroParcial = parcial;
            notasDB.idmateria = idmateria;
            notasDB.Insertar(n);
        }

        public System.Data.DataTable ObtenerNotasEvaluacion(int idEvaluacion, long parcial)
        {
            notasDB.numeroParcial = parcial;
            return notasDB.ObtenerNotasDeEvluacion(idEvaluacion);
        }

        public void EditarNotaAEstudiante(Nota n, long parcial)
        {
            notasDB.numeroParcial = parcial;
            notasDB.Editar(n);
        }

        public void EliminarNotas(long parcial, long id_evaluacion)
        {
            notasDB.idEvaluacion = id_evaluacion;
            notasDB.numeroParcial = parcial;
            notasDB.Eliminar(0);
        }
    }
}
