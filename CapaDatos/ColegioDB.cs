using Entidades;
using System.Collections.Generic;

namespace CapaDatos
{
    public class ColegioDB: ConexionDB, Crud<Colegio>
    {
        public readonly string select = "SELECT * FROM Colegio";
        public bool Editar(Colegio colegio)
        {
            string solicitud = $"UPDATE Colegio SET nombre=\"{colegio.nombre}\",director = \"{colegio.director}\", municipio= \"{colegio.municipio}\" ,departamento= \"{colegio.departamento}\", nucleoEducativo= \"{colegio.nucleoEducativo}\" , profesor= \"{colegio.profesor}\"  WHERE _rowid_=1";
            try
            {
                this.ExecuteQuery(solicitud);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public List<Colegio> ObtenerListaDeTodos()
        {
            System.Data.DataTable dt = ObtenerDatosTable();
            return ConvertirDataTabletoClase<Colegio>(dt);
        }
        
        public System.Data.DataTable ObtenerDatosTable()
        {
            return loadData(select);
        }


        //No son ocupados en esta clase
        public bool Eliminar(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Insertar(Colegio nuevoObjeto)
        {
            throw new System.NotImplementedException();
        }

    }
}
