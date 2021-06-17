using GradeNote;
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
    public partial class FrmWelcome : Form
    {
        public FrmWelcome()
        {
            InitializeComponent();
        }

        private void FormLogin(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBarWelcome.Increment(3);
            lblPorcentaje.Text = progressBarWelcome.Value.ToString() + "%";
            Opacity -= 0.01;
            if (progressBarWelcome.Value == progressBarWelcome.Maximum)
            {
                timer1.Stop();
                this.Hide();
                FrmInicio frmInicio = new FrmInicio();
                frmInicio.ShowDialog();
            }
        }

    }
}
