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
        public FrmGrupo()
        {
            InitializeComponent();
        }

        private void materiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Materias materias = new Materias();
            materias.MdiParent = this;
            materias.Show();
        }
    }
}
