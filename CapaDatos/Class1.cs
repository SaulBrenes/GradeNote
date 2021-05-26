using System.Data;
using System.Data.SQLite;
namespace CapaDatos
{
    public class Class1
    {
        private string url = "Data Source=C:/Users/HP 14/source/repos/GradeNote/GradeNote/bin/Debug/Registros.db";
        private string url2 = "Data Source=C:/Users/HP 14/source/repos/GradeNote/CapaDatos/Archivos/Registros.db"; 
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private DataSet DS = new DataSet();

        // Haciendo conección
        private void SetConnection()
        {
            sql_con = new SQLiteConnection(url2);
        }

        //Haciendo solicitud a la base de datos
        private void ExecuteQuery(string txtQuery)
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
        }

        public string loadData()
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            string comando = "SELECT * FROM Colegio";
            SQLiteDataAdapter DB = new SQLiteDataAdapter(comando, sql_con);
            DataTable DT = new DataTable();
            DB.Fill(DT);
            string mensaje = $"La lista: {DT.Columns.Count}";
            sql_con.Close();
            return mensaje;
        }
    }
}
