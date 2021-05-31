using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public interface Crud<T>
    {
        public bool Insertar(T nuevoObjeto);
        public bool Editar(T nuevoObjeto);
        public bool Eliminar(int id);
        public List<T> ObtenerListaDeTodos();


    }
}
