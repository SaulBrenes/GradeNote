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
    public partial class FrmGrupo : Form
    {
        public Grupo grupo { get; set; }
        bool isMateriaopen, isEstudianteopen, isEstadisticasopen, isAsistenciaopen,isBoletinopen;
        FrmMaterias frmMaterias;
        FrmEstudiantes frmEstudiantes;
        FrmEstadistica frmEstadistica;
        FrmAsistencia frmAsistencia;
        FrmBoletin frmBoletin;

        public FrmGrupo()
        {
            InitializeComponent();
            isMateriaopen = /*isEstudianteopen =*/ isEstadisticasopen = isAsistenciaopen= isBoletinopen= false;
        }

        private void materiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
           frmMaterias = new FrmMaterias();
           frmMaterias.MdiParent = this;
           frmMaterias.Show();
        }

        private void FrmGrupo_Load(object sender, EventArgs e)
        {
            frmEstudiantes = new FrmEstudiantes();
            string nombre = $" del {grupo.nombre}";
            frmEstudiantes.Text += nombre;
            frmEstudiantes.id_grupo = (int)grupo.id;
            frmEstudiantes.MdiParent = this;
            frmEstudiantes.Show();
            isEstudianteopen = true;
        }

        private void estudiantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstudiantes = new FrmEstudiantes();
            string nombre = $" del {grupo.nombre}";
            frmEstudiantes.Text += nombre;
            frmEstudiantes.id_grupo = (int)grupo.id;
            frmEstudiantes.MdiParent = this;
            frmEstudiantes.Show();
            isEstudianteopen = true;
        }

        private void estadisticaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstadistica = new FrmEstadistica();
            frmEstadistica.MdiParent = this;
            frmEstadistica.Show();
        }

        private void asistenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAsistencia = new FrmAsistencia();
            frmAsistencia.MdiParent = this;
            frmAsistencia.Show();
        }

        private void boletinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBoletin = new FrmBoletin();
            frmBoletin.MdiParent = this;
            frmBoletin.Show();
        }
    }
}
