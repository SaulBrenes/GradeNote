﻿using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class AsistenciaDB : ConexionDB, Crud<Asistencia>
    {
        public int idEstudiante { get; set; }
        public int idgrupo{ get; set; }

        public bool Insertar(Asistencia nuevoObjeto)
        {
            string sentencia = $"INSERT INTO Asistencias(id_grupo, id_estudiante,fecha,tipo) VALUES (\"{idgrupo}\", \"{nuevoObjeto.id_estudiante}\",\'{nuevoObjeto.fecha}\',\"{(Int64)nuevoObjeto.tipo}\")";
            try
            {
                this.ExecuteQuery(sentencia);
            }
            catch
            {
                return false;
            }
            return true;
            throw new NotImplementedException();
        }

        public bool Editar(Asistencia nuevoObjeto)
        {
            string sentencia = $"UPDATE Asistencias SET id_estudiante=\"{nuevoObjeto.id_estudiante}\",fecha=\'{nuevoObjeto.fecha}\', tipo=\"{(Int64)nuevoObjeto.tipo}\"  WHERE id ={nuevoObjeto.id}";
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

        public bool Eliminar(int id)
        {
            string sentencia = $"DELETE FROM Asistencias WHERE id ={id}";
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

        public System.Data.DataTable ObtenerAsistencias()
        {
            string setencia = $"SELECT fecha FROM Asistencias WHERE id_grupo={idgrupo} GROUP BY fecha";
            return loadData(setencia);
        }

        public List<Asistencia> ObtenerListaDeTodos()
        {
            System.Data.DataTable dt = ObtenerAsistencias();
            return ConvertirDataTabletoClase<Asistencia>(dt);
        }
    }
}
