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
    public partial class FrmBoletin : Form
    {
        public int id_grupo { get; set; }
        private DataTable dt;
        CNEstudiantes cnEst = new CNEstudiantes();
        List<Estudiante> estudiantes = new List<Estudiante>();
        CN_Materia cnMateria = new();
        public List<Materia> materias;
        CN_Colegio cnColegio = new();
        Colegio colegio;

        public FrmBoletin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void FrmBoletin_Load(object sender, EventArgs e)
        {
            dt = cnEst.TablaEstudiantesDelGrupo(id_grupo);
            dgvEstudiantes.DataSource = dt;
            estudiantes = cnEst.ListaEstudiantes(id_grupo);
            materias = cnMateria.ObtenerMateriasDelGrupo(id_grupo);
            colegio = cnColegio.ObtenerDatosActuales();
            if(estudiantes.Count == 0 || materias.Count == 0)
            {
                MessageBox.Show("No hay estudiantes o materias creadas");
                this.Close();
            }
        }
        
        //Vista previa
        private void button1_Click(object sender, EventArgs e)
        {
            if(estudiantes.Count == 0)
            {
                return;
            }

            if(dgvEstudiantes.SelectedRows.Count == 0)
            {
                return;
            }

            if(flowLayoutPanel2.Controls.Count > 0)
            {
                flowLayoutPanel2.Controls.RemoveAt(0);
            }

            Estudiante estudiante = estudiantes.ElementAt(dgvEstudiantes.SelectedRows[0].Index);

            DataTable dt = new DataTable();
            dt.Columns.Add("Materias", typeof(string));
            dt.Columns.Add("IP", typeof(double));
            dt.Columns.Add("IIP", typeof(double));
            dt.Columns.Add("IIIP", typeof(double));
            dt.Columns.Add("IVP", typeof(double));
            dt.Columns.Add("Promedio", typeof(double));

            double promedio = 0;
            double promedioMateria = 0;
            double nota = 0;
            int k = 0;
            foreach (Materia m in materias)
            {
                promedioMateria = 0;

                dt.Rows.Add();
                dt.Rows[k].SetField(0, m.nombre);

                nota = cnMateria.NotaParcialDeEstudiante(estudiante.id, m.id, 1); 
                promedioMateria += nota;
                dt.Rows[k].SetField(1, nota);

                nota = cnMateria.NotaParcialDeEstudiante(estudiante.id, m.id, 2);
                promedioMateria += nota;
                dt.Rows[k].SetField(2, nota);

                nota = cnMateria.NotaParcialDeEstudiante(estudiante.id, m.id, 3);
                promedioMateria += nota;
                dt.Rows[k].SetField(3, nota);

                nota = cnMateria.NotaParcialDeEstudiante(estudiante.id, m.id, 4);
                promedioMateria += nota;
                dt.Rows[k].SetField(4, nota);

                dt.Rows[k].SetField(5, promedioMateria/4);
                promedio += promedioMateria/4;
                k++;
            }
            promedio /= materias.Count;

            flowLayoutPanel2.Controls.Add(new Boletin
            {
                Promedio = $"{promedio}",
                Tabla = dt,
                NombreEstudiante = $"{estudiante.nombres} {estudiante.apellidos}",
                NombreInstitucion = colegio.nombre,
                Departamento = colegio.departamento,
                Municipio = colegio.municipio,
                Director = colegio.director,
                Profesor = colegio.profesor
                
            }
            ) ;
        }
    }
}
