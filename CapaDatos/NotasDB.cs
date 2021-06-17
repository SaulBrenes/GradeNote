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

        public long numeroParcial { get; set; }

        public long idmateria{ get; set; }

        public bool Insertar(Nota nuevoObjeto)
        {
            string sentencia = "";
            switch (numeroParcial)
            {
                case 1:
                    sentencia = $"INSERT INTO NotasIP (id_evaluacion, id_estudiante, valor, idmateria) VALUES(\"{nuevoObjeto.id_evaluacion}\", \"{nuevoObjeto.id_estudiante}\", \"{nuevoObjeto.valor}\", \"{idmateria}\")";
                    break;
                case 2:
                    sentencia = $"INSERT INTO NotasIIP (id_evaluacion, id_estudiante, valor, idmateria) VALUES(\"{nuevoObjeto.id_evaluacion}\", \"{nuevoObjeto.id_estudiante}\", \"{nuevoObjeto.valor}\", \"{idmateria}\")";
                    break;
                case 3:
                    sentencia = $"INSERT INTO NotasIIIP (id_evaluacion, id_estudiante, valor, idmateria) VALUES(\"{nuevoObjeto.id_evaluacion}\", \"{nuevoObjeto.id_estudiante}\", \"{nuevoObjeto.valor}\", \"{idmateria}\")";
                    break;
                case 4:
                    sentencia = $"INSERT INTO NotasIVP (id_evaluacion, id_estudiante, valor, idmateria) VALUES(\"{nuevoObjeto.id_evaluacion}\", \"{nuevoObjeto.id_estudiante}\", \"{nuevoObjeto.valor}\", \"{idmateria}\")";
                    break;
            }
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
            string sentencia = "";
            switch (numeroParcial)
            {
                case 1:
                    sentencia = $"UPDATE NotasIP SET  valor=\"{nuevoObjeto.valor}\" WHERE id_estudiante ={nuevoObjeto.id_estudiante} AND id_evaluacion ={nuevoObjeto.id_evaluacion}";
                    break;
                case 2:
                    sentencia = $"UPDATE NotasIIP SET  valor=\"{nuevoObjeto.valor}\" WHERE id_estudiante ={nuevoObjeto.id_estudiante} AND id_evaluacion ={nuevoObjeto.id_evaluacion}";
                    break;
                case 3:
                    sentencia = $"UPDATE NotasIIIP SET  valor=\"{nuevoObjeto.valor}\" WHERE id_estudiante ={nuevoObjeto.id_estudiante} AND id_evaluacion ={nuevoObjeto.id_evaluacion}";
                    break;
                case 4:
                    sentencia = $"UPDATE NotasIVP SET  valor=\"{nuevoObjeto.valor}\" WHERE id_estudiante ={nuevoObjeto.id_estudiante} AND id_evaluacion ={nuevoObjeto.id_evaluacion}";
                    break;
            }

           // string sentencia = $"UPDATE NotasIP SET  valor=\"{nuevoObjeto.valor}\" WHERE id_estudiante ={nuevoObjeto.id_estudiante} AND id_evaluacion ={nuevoObjeto.id_evaluacion}";
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
            string sentencia = "";
            switch (numeroParcial)
            {
                case 1:
                    sentencia = $"DELETE FROM NotasIP WHERE id_evaluacion = {idEvaluacion}";
                    break;
                case 2:
                    sentencia = $"DELETE FROM NotasIIP WHERE id_evaluacion = {idEvaluacion}";
                    break;
                case 3:
                    sentencia = $"DELETE FROM NotasIIIP WHERE id_evaluacion = {idEvaluacion}";
                    break;
                case 4:
                    sentencia = $"DELETE FROM NotasIVP WHERE id_evaluacion = {idEvaluacion}";
                    break;
            }
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

        public List<Nota> ObtenerListaDeTodos()
        {
            throw new NotImplementedException();
        }

        public List<Nota> ObtenerListaDeNotasDelEMP()
        {
            try { 
                string sentencia = "";
                switch (numeroParcial)
            {
                case 1:
                    sentencia = $"SELECT * FROM NotasIP Where NotasIP.id_estudiante = {idEstudiante} AND NotasIP.idmateria = {idmateria}";
                    break;
                case 2:
                    sentencia = $"SELECT * FROM NotasIIP Where NotasIIP.id_estudiante = {idEstudiante} AND NotasIIP.idmateria = {idmateria}";
                    break;
                case 3:
                    sentencia = $"SELECT * FROM NotasIIIP Where NotasIIIP.id_estudiante = {idEstudiante} AND NotasIIIP.idmateria = {idmateria}";
                    break;
                case 4:
                    sentencia = $"SELECT * FROM NotasIVP Where NotasIVP.id_estudiante = {idEstudiante} AND NotasIVP.idmateria = {idmateria}";
                    break;
            }            
               return ConvertirDataTabletoClase<Nota>(loadData(sentencia));
            }
            catch
            {
                return null;
            }
        }

       public System.Data.DataTable ObtenerNotasDeEvluacion(int idEvaluacion)
        {
            string sentencia = "";
            switch (numeroParcial)
            {
                case 1:
                    sentencia = $"SELECT apellidos, nombres, NotasIP.valor FROM Estudiantes INNER JOIN NotasIP ON NotasIP.id_estudiante = Estudiantes.id AND NotasIP.id_evaluacion = {idEvaluacion}";
                    break;
                case 2:
                    sentencia = $"SELECT apellidos, nombres, NotasIIP.valor FROM Estudiantes INNER JOIN NotasIIP ON NotasIIP.id_estudiante = Estudiantes.id AND NotasIIP.id_evaluacion = {idEvaluacion}";
                    break;
                case 3:
                    sentencia = $"SELECT apellidos, nombres, NotasIIIP.valor FROM Estudiantes INNER JOIN NotasIIIP ON NotasIIIP.id_estudiante = Estudiantes.id AND NotasIIIP.id_evaluacion = {idEvaluacion}";
                    break;
                case 4:
                    sentencia = $"SELECT apellidos, nombres, NotasIVP.valor FROM Estudiantes INNER JOIN NotasIVP ON NotasIVP.id_estudiante = Estudiantes.id AND NotasIVP.id_evaluacion = {idEvaluacion}";
                    break;
            }
            //string sentencia = $"SELECT apellidos, nombres, NotasIP.valor FROM Estudiantes INNER JOIN NotasIP ON NotasIP.id_estudiante = Estudiantes.id AND NotasIP.id_evaluacion = {idEvaluacion}";
            return loadData(sentencia);
        } 
    }
}
