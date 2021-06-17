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
        List<Estudiante> estudiantes;
        CN_Materia cnMateria = new();
        public List<Materia> materias;
        List<double> promedios = new List<double>();

        public FrmEstadistica()
        {
            InitializeComponent();
        }

        private void FrmEstadistica_Load(object sender, EventArgs e)
        {
            estudiantes = cnEstudiantes.ListaEstudiantes(id_grupo);
            materias = cnMateria.ObtenerMateriasDelGrupo(id_grupo);
            if (estudiantes.Count == 0 || materias.Count == 0)
            {
                MessageBox.Show("No hay estudiantes o materias creadas");
                this.Close();
            }
            CargarDGVAsitencias();
            CargarDGVPromedio();
        }

        private void CargarDGVAsitencias()
        {
           
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

        private void CargarDGVPromedio()
        {
            if (estudiantes.Count == 0)
            {
                return;
            }

            double promedio = 0;
            double promedioMateria = 0;
            double nota = 0;
            foreach (Estudiante est in estudiantes)
            {
                promedio = 0;
                foreach (Materia m in materias)
                {
                    promedioMateria = 0;

                    nota = cnMateria.NotaParcialDeEstudiante(est.id, m.id, 1);
                    promedioMateria += nota;

                    nota = cnMateria.NotaParcialDeEstudiante(est.id, m.id, 2);
                    promedioMateria += nota;

                    nota = cnMateria.NotaParcialDeEstudiante(est.id, m.id, 3);
                    promedioMateria += nota;

                    nota = cnMateria.NotaParcialDeEstudiante(est.id, m.id, 4);
                    promedioMateria += nota;

                    promedio = promedio + (promedioMateria / 4);

                }
                 promedio /= materias.Count;
                est.promedio = promedio;
            }

            //Ordenando de forma descendente
            estudiantes.Sort(delegate (Estudiante x, Estudiante y)
            {
                if (x.promedio == 0 && y.promedio == 0) return -1;
                else if (x.promedio == 0) return 1;
                else if (y.promedio == 0) return -1;
                else return (-1) * x.promedio.CompareTo(y.promedio);
            });

            CreandoTablaPromedio(estudiantes);
        }

        private void CreandoTablaPromedio(List<Estudiante> estudiantes)
        {
            //Creando columnas
            dataGridView1.Columns.Add("column0", "Codigo");
            dataGridView1.Columns.Add("column1", "Apellido");
            dataGridView1.Columns.Add("column2", "Nombre");
            dataGridView1.Columns.Add("column3", "Promedio");

            for(int k= 0; k < estudiantes.Count; k++)
            {
                if (k == 10)
                {
                    break;
                }
                dataGridView1.Rows.Add();
                dataGridView1.Rows[k].Cells[0].Value = estudiantes.ElementAt(k).codigo;
                dataGridView1.Rows[k].Cells[1].Value = estudiantes.ElementAt(k).apellidos;
                dataGridView1.Rows[k].Cells[2].Value = estudiantes.ElementAt(k).nombres;
                dataGridView1.Rows[k].Cells[3].Value = $"{Math.Round(estudiantes.ElementAt(k).promedio, 2)}%";
                
            }
        }
    }
}
