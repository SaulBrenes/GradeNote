using System;
using System.Windows.Forms;
using CapaDatos;
using Entidades;

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
                Colegio colegio = new Colegio(txtNombre.Text, txtDirector.Text, txtMunicipio.Text, txtDepartamento.Text, txtNucleo.Text, txtProfesor.Text);
                ColegioDB cbd = new ColegioDB();
                cbd.ActualizarColegio(colegio);
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
