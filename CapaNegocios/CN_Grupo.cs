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


        public void EditarGrupo(Grupo viejoG)
        {
            grupoDB.Editar(viejoG);
        }

        //Fijarse como se eliminar el grupo y los indices de nuevos grupos
        public bool EliminarGrupo(int indice)
        {
            return grupoDB.Eliminar(indice);
        }

        public System.Data.DataTable ObtenerDataTableGrupos()
        {
            return grupoDB.ObtenerGrupos();
        }

        public List<Grupo> ObtenerListaGrupos()
        {
            return grupoDB.ObtenerListaDeTodos();
        }

        private int ValidarGrupo(string nombre, string turno, string anio)
        {
            if (String.IsNullOrWhiteSpace(nombre) || String.IsNullOrWhiteSpace(turno) || String.IsNullOrWhiteSpace(anio))
            {
                throw new ArgumentException("Llene todos los campos");
            }

            if (!int.TryParse(anio, out int anioconv))
            {
                throw new ArgumentException($"El valor {anio} no es valido");
            }
            return anioconv;
        }
    }
}
