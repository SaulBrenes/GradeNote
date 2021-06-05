using CapaDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class CNNota
    {
        NotasDB notasDB = new();

        public void CrearNota(Nota n)
        {
            notasDB.Insertar(n);
        }
    }
}
