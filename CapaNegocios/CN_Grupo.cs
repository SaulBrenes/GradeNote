using CapaDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class CN_Grupo
    {
        GrupoDB grupoDB = new GrupoDB();

        public void AgregarNuevoGrupo(Grupo nuevoGrupo)
        {
            grupoDB.Insertar(nuevoGrupo);
        }

        public System.Data.DataTable ObtenerDataTableGrupos()
        {
            return grupoDB.ObtenerGrupos();
        }

        public List<Grupo> ObtenerListaGrupos()
        {
            return grupoDB.ObtenerListaDeTodos();
        }
    }
}
