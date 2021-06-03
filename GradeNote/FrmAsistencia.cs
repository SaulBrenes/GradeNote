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
    public partial class FrmAsistencia : Form
    {
        public int id_grupo { get; set; }
        public int[] id_estudiante { get; set; }

        CNAsistencia CNasistencia = new CNAsistencia();
        CNEstudiantes CNestudiante = new CNEstudiantes();

        List<Estudiante> estudiantes = new List<Estudiante>();
        List<Asistencia> asistencias = new List<Asistencia>();

        public FrmAsistencia()
        {
            InitializeComponent();
        }

        private void FrmAsistencia_Load(object sender, EventArgs e)
        {
            estudiantes = CNestudiante.ListaEstudiantes(id_grupo);
            if(estudiantes.Count == 0)
            {
                return;
            }
            int id = (int) estudiantes.ElementAt(0).id; 
            dgvAsistencias.DataSource = CNasistencia.ObtenerFechasAsistencias(id);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"La fecha: {dtpFecha.Text}");
            Asistencia nueva = new Asistencia
            {
                fecha = dtpFecha.Value
            };

            foreach(Estudiante est in estudiantes)
            {
                nueva.id_estudiante = est.id;
                nueva.tipo = TipoAsistencia.Presente;
                CNasistencia.CrearAsistencia(nueva);
            }
            
        }
    }
}
