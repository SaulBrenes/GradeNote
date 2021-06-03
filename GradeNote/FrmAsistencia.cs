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

            dgvAsistencias.DataSource = CNasistencia.ObtenerFechasAsistencias(id_grupo);
            dgvAsistencias.ClearSelection();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Asistencia nueva = new Asistencia
            {
                fecha = dtpFecha.Value
            };

            foreach (Estudiante est in estudiantes)
            {
                nueva.id_estudiante = est.id;
                nueva.tipo = TipoAsistencia.PRESENTE;
                CNasistencia.CrearAsistencia(nueva, id_grupo);
            }

            //Recargando la vista
            dgvAsistencias.DataSource = CNasistencia.ObtenerFechasAsistencias(id_grupo);
            dgvAsistencias.ClearSelection();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvAsistencias.SelectedRows.Count <= 0)
            {
                return;
            }

            //Obteniendo asistencia(fecha) de la fila seleccionada
            string fecha = (string) dgvAsistencias.SelectedRows[0].Cells[0].Value;
            dgvAsistEst.DataSource = CNasistencia.ObtenerTableAsistenciaEstudiante(fecha, id_grupo);
        }
    }
}
