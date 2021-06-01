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
    public partial class FrmEstudiantes : Form
    {
        public int id_grupo { get; set; }
        CNEstudiantes cnEst = new CNEstudiantes();
        List<Estudiante> estudiantes = new List<Estudiante>();

        public FrmEstudiantes()
        {
            InitializeComponent();
        }

        private void FrmEstudiantes_Load(object sender, EventArgs e)
        {
            DataTable  dt = cnEst.TablaEstudiantesDelGrupo(id_grupo);
            dgvEstudiantes.DataSource = dt;
            estudiantes = cnEst.ListaEstudiantes(id_grupo);
        }

        private void dgvEstudiantes_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("No funciona. :(");
        }
    }
}
