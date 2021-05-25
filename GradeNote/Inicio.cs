using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GradeNote
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (btnEditar.Text.Equals("Editar"))
            {
                edicionDeTxt(!true);
                btnEditar.Text = "Guardar cambios";
                txtNombre.Focus();
            }
            else
            {
                edicionDeTxt(!false);
                btnEditar.Text = "Editar";
                
            }
            
        }

        private void edicionDeTxt(bool bandera)
        {
            txtNombre.ReadOnly = bandera;
            txtNombre.Enabled = !bandera;
            txtMunicipio.ReadOnly = bandera;
            txtMunicipio.Enabled = !bandera;
            txtDepartamento.ReadOnly = bandera;
            txtDepartamento.Enabled = !bandera;
            txtDirector.ReadOnly = bandera;
            txtDirector.Enabled = !bandera;
            txtNucleo.ReadOnly = bandera;
            txtNucleo.Enabled = !bandera;
            txtProfesor.ReadOnly = bandera;
            txtProfesor.Enabled = !bandera;
        }
    }
}
