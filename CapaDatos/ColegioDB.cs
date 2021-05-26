using Entidades;

namespace CapaDatos
{
    public class ColegioDB: ConexionDB
    {
        public void ActualizarColegio(Colegio colegio)
        {
            string solicitud = $"UPDATE Colegio SET nombre=\"{colegio.nombre}\",director = \"{colegio.director}\", municipio= \"{colegio.municipio}\" ,departamento= \"{colegio.departamento}\", nucleoEducativo= \"{colegio.nucleoEducativo}\" , profesor= \"{colegio.profesor}\"  WHERE _rowid_=1";
            this.ExecuteQuery(solicitud);
        }
    }
}
