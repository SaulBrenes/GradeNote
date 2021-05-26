using System.Data;
using System.Data.SQLite;
using System.IO;

namespace CapaDatos
{
    public class ConexionDB
    {
        private string url = "Data Source=Registros.db";
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;

        // Haciendo conección con la base de datos
        private void SetConnection()
        {
            sql_con = new SQLiteConnection(url);
        }

        //Hace cambios a la base de datos
        //Devuelve las cantidad de filas afectadas
        public void ExecuteQuery(string txtQuery)
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
        }

        //Método que carga la base de datos
        public string loadData()
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            string comando = "SELECT * FROM Colegio";
            SQLiteDataAdapter DB = new SQLiteDataAdapter(comando, sql_con);
            DataTable DT = new DataTable();
            DB.Fill(DT);
            string mensaje = $"La lista: {DT.Columns.Count}" + "   ";
            sql_con.Close();
            return mensaje;
        }
    }
}
