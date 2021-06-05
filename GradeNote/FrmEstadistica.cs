using CapaNegocios;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmEstadistica : Form
    {
        public int id_grupo { get; set; }
        CNEstudiantes cnEstudiantes = new ();
        CNAsistencia cnAsitencia = new ();

        public FrmEstadistica()
        {
            InitializeComponent();
        }

        private void FrmEstadistica_Load(object sender, EventArgs e)
        {
            CargarDGVAsitencias();
        }

        private void CargarDGVAsitencias()
        {
            List<Estudiante> estudiantes = cnEstudiantes.ListaEstudiantes(id_grupo);
            int cantidaEstudiantes = estudiantes.Count;
            if(cantidaEstudiantes == 0)
            {
                return;
            }
            
            //Obteniendo porcentaje de asistencia de cada alumno
            foreach (Estudiante est in estudiantes)
            {
                est.pasistencias = cnAsitencia.ObtenerPorcentajeAsistenciasDelEstudiante((int)est.id);
            }

            //Ordenando de forma descendente
            estudiantes.Sort(delegate(Estudiante x, Estudiante y)
            {
                if (x.pasistencias == 0 && y.pasistencias == 0) return -1;
                else if (x.pasistencias == 0) return 1;
                else if (y.pasistencias == 0) return -1;
                else return (-1) * x.pasistencias.CompareTo(y.pasistencias);
            });

            //Mostrando en la tabla
            CreandoTablaAsistencia(estudiantes);
        }

        private void CreandoTablaAsistencia(List<Estudiante> estudiantes)
        {
            //Creando columnas
            dgvAsistencias.Columns.Add("column0", "Codigo");
            dgvAsistencias.Columns.Add("column1", "Apellido");
            dgvAsistencias.Columns.Add("column2", "Nombre");
            dgvAsistencias.Columns.Add("column3", "Asistencia(%)");

            int k = 0;
            foreach (Estudiante est in estudiantes)
            {
                dgvAsistencias.Rows.Add();
                dgvAsistencias.Rows[k].Cells[0].Value = est.codigo;
                dgvAsistencias.Rows[k].Cells[1].Value = est.apellidos;
                dgvAsistencias.Rows[k].Cells[2].Value = est.nombres;
                dgvAsistencias.Rows[k].Cells[3].Value = $"{Math.Round(est.pasistencias, 2)}%";
                k++;  
            }
           

        }
    }
}
