using CapaDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class CNEstudiantes
    {
        EstudianteDB dBEstudiante = new EstudianteDB();

        public void AgregarEstudiante(Estudiante newest)
        {
            dBEstudiante.Insertar(newest);
        }

        public void EditarEstudiante(Estudiante eEditar)
        {
            dBEstudiante.Editar(eEditar);
        }

        public void EliminarEstudiante(int idEst)
        {
            dBEstudiante.Eliminar(idEst);
        }

        public DataTable TablaEstudiantesDelGrupo(int idGrupo)
        {
            dBEstudiante.idGrupo = idGrupo;
            return dBEstudiante.ObtenerEstudiantes();
        }

        public List<Estudiante> ListaEstudiantes(int idGrupo)
        {
            dBEstudiante.idGrupo = idGrupo;
            return dBEstudiante.ObtenerListaDeTodos();
        }

        public DataTable ObtenerNotaEstudiante(int idgrupo)
        {
            string consulta = $"SELECT apellidos as \"Apellidos\", nombres as \"Nombres\", " +
                $"Sum(ifnull(NotasIP.valor, 0)) as \"IP\", Sum(ifnull(NotasIIP.valor, 0)) as \"IIP\", " +
                $"Sum(ifnull(NotasIIIP.valor, 0)) as \"IIIP\", Sum(ifnull(NotasIVP.valor, 0)) as \"IVP\" " +
                $"FROM Estudiantes " +
                $"LEFT JOIN NotasIP ON NotasIP.id_estudiante = Estudiantes.id AND Estudiantes.id_grupo = {idgrupo} " +
                $"LEFT JOIN NotasIIP ON NotasIIP.id_estudiante = Estudiantes.id AND Estudiantes.id_grupo = {idgrupo} " +
                $"LEFT JOIN NotasIIIP ON NotasIIIP.id_estudiante = Estudiantes.id AND Estudiantes.id_grupo = {idgrupo} " +
                $"LEFT JOIN NotasIVP ON NotasIVP.id_estudiante = Estudiantes.id AND Estudiantes.id_grupo = {idgrupo} " +
                $"GROUP BY Estudiantes.apellidos";
            return dBEstudiante.loadData(consulta);
        }
    }
}
