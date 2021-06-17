using CapaDatos;
using Entidades;
using System.Collections.Generic;
using System.Linq;

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

        public double ObtenerNotaDe(long idEstudiante, long idMateria, long parcial)
        {
            notasDB.idEstudiante = idEstudiante;
            notasDB.idmateria = idMateria;
            notasDB.numeroParcial = parcial;
            List<Nota> notas = notasDB.ObtenerListaDeNotasDelEMP();
            if(notas == null)
            {
                return 0;
            }
            if(notas.Count == 0)
            {
                return 0;
            }

            return notasDB.ObtenerListaDeNotasDelEMP().Sum(n => n.valor);
        }
    }
}
