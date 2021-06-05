using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace CapaDatos
{
    public class ConexionDB
    {
        //Constructor que inicializa la url a ocupar para las conexiones
        public ConexionDB()
        {
            this.url = CreadorUrl();
        }

        //Elementos necesarios para conectar con la base de datos
        private string inicio = "Data Source=";
        private string fin = "CapaDatos/Archivos/Registros.db";
        private string url;
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;

        // Haciendo conección con la base de datos
        private void SetConnection()
        {
            sql_con = new SQLiteConnection(url);
        }

        //Hace cambios a la base de datos
        public void ExecuteQuery(string txtQuery)
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
        }

        //Método que obtiene informacion en base de datos y lo guarda en DataTable
        public DataTable loadData(string comando)
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            SQLiteDataAdapter DB = new SQLiteDataAdapter(comando, sql_con);
            DataTable DT = new DataTable();
            DB.Fill(DT);
            sql_con.Close();
            return DT;
        }

        public string CreadorUrl()
        {
            //Obteniendo direccion actual del archivo que se esta ejecutando
            string direccion = Directory.GetCurrentDirectory();

            //Separando la direccion
            string[] cortado = direccion.Split("\\");

            //Creando una nueva direccion valida
            string temp = inicio;

            for (int i = 0; i < cortado.Length; i++){
                 temp += $"{cortado[i]}/";
                if (cortado[i].Equals("GradeNote"))
                {
                    break;
                }
            }

            //Retornando direccion valida
            return $"{temp}{fin}";
        }

        //Convierte un DataTable en una List<T>
        public List<T> ConvertirDataTabletoClase<T>(DataTable dt)
        {
            List<T> data = new List<T>();

            foreach(DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }

            return data;
        }

        //Obtener un item de un DataTable
        private static T GetItem<T> (DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach(DataColumn column in dr.Table.Columns)
            {
                foreach(System.Reflection.PropertyInfo pro in temp.GetProperties())
                {
                    if(pro.Name == column.ColumnName)
                    {
                            pro.SetValue(obj, dr[column.ColumnName], null);
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            return obj;
        }
    }
}
