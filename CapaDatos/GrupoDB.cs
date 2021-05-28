using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class GrupoDB : ConexionDB
    {
        public void CrearGrupo(Grupo grupo)
        {
            string sentencia = $"INSERT INTO Grupos(nombre,turno,anio) VALUES (\"{grupo.Nombre}\",\"{grupo.Turno}\",\"{grupo.AnioElectivo}\")";
            this.ExecuteQuery(sentencia);
        }

        public System.Data.DataTable ObtenerGrupos()
        {
            string setencia = "SELECT * FROM Grupos";

            return loadData(setencia);
        }
    }
}
