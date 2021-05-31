using CapaDatos;
using Entidades;
using System.Linq;

namespace CapaNegocios
{
    public class CN_Colegio
    {
        private ColegioDB colegioDB = new ColegioDB();

        public void EditarDatosColegio(Entidades.Colegio c)
        {
            colegioDB.Editar(c);
        }

        public Colegio ObtenerDatosActuales()
        {
            return colegioDB.ObtenerListaDeTodos().ElementAt(0);
        }
    }
}
