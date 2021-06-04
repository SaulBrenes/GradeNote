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
            dgvAsistEst.DataSource = null;
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
            dtpFecha.Value = CNasistencia.CrearFecha(fecha);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        { 
            if (dgvAsistencias.SelectedRows.Count <= 0)
            {
                return;
            }

            //Obteniendo asistencia(fecha) de la fila seleccionada a eliminar
            string fecha = (string)dgvAsistencias.SelectedRows[0].Cells[0].Value;

            //Eliminando asistencias
            CNasistencia.Elimnar(fecha, id_grupo);

            //Refrescar tablas
            dgvAsistencias.DataSource = CNasistencia.ObtenerFechasAsistencias(id_grupo);
            dgvAsistencias.ClearSelection();
            dgvAsistEst.DataSource = null;
        }

        private void btnPresente_Click(object sender, EventArgs e)
        {
            this.CambiandoAsistenciaFilaSeleccionada(TipoAsistencia.PRESENTE);    
        }

        private void btnAusente_Click(object sender, EventArgs e)
        {
            this.CambiandoAsistenciaFilaSeleccionada(TipoAsistencia.AUSENTE);
        }

        private void btnJustificado_Click(object sender, EventArgs e)
        {
            this.CambiandoAsistenciaFilaSeleccionada(TipoAsistencia.JUSTIFICADO);
        }

        private void CambiandoAsistenciaFilaSeleccionada(TipoAsistencia t)
        {
            if (dgvAsistEst.SelectedRows.Count <= 0)
            {
                return;
            }
            string fecha = (string)dgvAsistencias.SelectedRows[0].Cells[0].Value;
            foreach (DataGridViewRow fila in dgvAsistEst.SelectedRows)
            {
                //Obteniendo id del estudiante a editar asistencia
                int id = (int)estudiantes.ElementAt(fila.Index).id;
                CNasistencia.CambiarAsitencia(t, id, fecha);
            }
            dgvAsistEst.DataSource = CNasistencia.ObtenerTableAsistenciaEstudiante(fecha, id_grupo);
        }
    }
}
