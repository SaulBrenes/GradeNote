using System;
using System.Data;
using System.Data.SQLite;
namespace CapaDatos
{
    public class Class1
    {
        private string url = "Data Source=C:/Users/Laptop2/source/repos/GradeNote/GradeNote/bin/Debug/registro.db";
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private DataSet DS = new DataSet();

        // Haciendo conección
        private void SetConnection()
        {
            sql_con = new SQLiteConnection(url);
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

        public void loadData()
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            string comando = "SELECT * FROM colegio";
            SQLiteDataAdapter DB = new SQLiteDataAdapter(comando, sql_con);
            DataTable DT = new DataTable();
            DB.Fill(DT);
            Console.Write($"La lista: {DT}");
            sql_con.Close();
        }
    }
}
