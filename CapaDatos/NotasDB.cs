using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class NotasDB : ConexionDB, Crud<Nota>
    {
        public Int64 idEvaluacion { get; set; }
        public Int64 idEstudiante { get; set; }

        public bool Insertar(Nota nuevoObjeto)
        {
            string sentencia = $"INSERT INTO NotasIP (id_evaluacion, id_estudiante, valor) VALUES(\"{nuevoObjeto.id_evaluacion}\", \"{nuevoObjeto.id_estudiante}\", \"{nuevoObjeto.valor}\")";
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

        public bool Editar(Nota nuevoObjeto)
        {
            string sentencia = $"UPDATE NotasIP SET id_evaluacion=\"{nuevoObjeto.id_evaluacion}\",id_estudiante=\"{nuevoObjeto.id_estudiante}\", valor=\"{nuevoObjeto.valor}\"WHERE id ={nuevoObjeto.id}";
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

        //Revisar al final
        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Nota> ObtenerListaDeTodos()
        {
            throw new NotImplementedException();
        }
    }
}
