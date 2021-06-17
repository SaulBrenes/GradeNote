using CapaDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class CN_Materia
    {
        MateriaDB materiaDB = new();
        CNNota cnNota = new();
        public System.Data.DataTable ObtenerDataTableMaterias(int idgrupo)
        {
            return materiaDB.ObtenerMateriaDeGrupo(idgrupo);
        }

        public List<Materia> ObtenerMateriasDelGrupo(int idgrupo)
        {
            return materiaDB.ObtenerListaDeTodos(idgrupo);
        }

        public void CrearMateria(Materia m)
        {
            materiaDB.Insertar(m);
        }

        public void EditarMateria(Materia m)
        {
            materiaDB.Editar(m);
        }

        public void EliminarMateria(int idMateria)
        {
            materiaDB.Eliminar(idMateria);
        }
        
        public double NotaParcialDeEstudiante(long idEstudiante, long idMateria, long parcial)
        {
            return cnNota.ObtenerNotaDe(idEstudiante, idMateria, parcial);
        }
       
    }
}
