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
    public partial class FrmMaterias : Form
    {
        public int id_grupo { get; set;}

        CN_Materia cnMateria = new();

        private List<Materia> materias = new();

        public FrmMaterias()
        {
            InitializeComponent();
        }

        private void ActualizarComboBoxMaterias()
        {
            DataTable dt = cnMateria.ObtenerDataTableMaterias(id_grupo);
            cmbMateria.DataSource = dt;
            cmbMateria.DisplayMember = "Nombre";
            materias = cnMateria.ObtenerMateriasDelGrupo(id_grupo);
        }

        private void ActualizarTablaEstudiantes()
        {

        }

        private void cmbMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmbMateria.SelectedIndex;
            if (index == -1 || materias.Count == 0 || materias == null)
            {
                return;
            }
            textBox1.Text = materias.ElementAt(index).nombre;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (btnAgregar.Text.Equals("AGREGAR"))
            {
                textBox1.ReadOnly = false;
                textBox1.Text = "";
                textBox1.Focus();
                btnEditar.Enabled = false;
                btnIngresar.Enabled = false;
                btnEliminar.Enabled = false;
                btnCancelar.Enabled = true;
                btnAgregar.Text = "GUARDAR";
                return;
            }

            Materia nuevo = new Materia
            {
                id_grupo = id_grupo,
                nombre = textBox1.Text
            };
            cnMateria.CrearMateria(nuevo);

            textBox1.ReadOnly = true;
            btnEditar.Enabled = true;
            btnIngresar.Enabled = true;
            btnEliminar.Enabled = true;
            btnCancelar.Enabled = false;
            btnAgregar.Text = "AGREGAR";

            ActualizarComboBoxMaterias();
            cmbMateria.SelectedIndex = materias.Count - 1;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (btnAgregar.Text.Equals("GUARDAR"))
            {
                textBox1.ReadOnly = true;
                btnEditar.Enabled = true;
                btnIngresar.Enabled = true;
                btnEliminar.Enabled = true;
                btnCancelar.Enabled = false;
                btnAgregar.Text = "AGREGAR";
                int i = cmbMateria.SelectedIndex;
                cmbMateria.SelectedIndex = -1;
                cmbMateria.SelectedIndex = i;
            }

            if (btnEditar.Text.Equals("GUARDAR"))
            {
                textBox1.ReadOnly = true;
                btnAgregar.Enabled = true;
                btnIngresar.Enabled = true;
                btnEliminar.Enabled = true;
                btnCancelar.Enabled = false;
                btnEditar.Text = "EDITAR";
                int i = cmbMateria.SelectedIndex;
                cmbMateria.SelectedIndex = -1;
                cmbMateria.SelectedIndex = i;
            }
        }

        private void FrmMaterias_Shown(object sender, EventArgs e)
        {
            ActualizarComboBoxMaterias();
            ActualizarTablaEstudiantes();
            if(materias.Count > 0)
            {
                cmbMateria.SelectedIndex = 0;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(materias.Count <= 0)
            {
                return;
            }

            if (btnEditar.Text.Equals("EDITAR"))
            {
                textBox1.ReadOnly = false;
                textBox1.Focus();
                btnAgregar.Enabled = false;
                btnIngresar.Enabled = false;
                btnEliminar.Enabled = false;
                btnCancelar.Enabled = true;
                btnEditar.Text = "GUARDAR";
                return;
            }

            int index = cmbMateria.SelectedIndex;
            materias.ElementAt(index).nombre = textBox1.Text;
            cnMateria.EditarMateria(materias.ElementAt(index));

            textBox1.ReadOnly = true;
            btnAgregar.Enabled = true;
            btnIngresar.Enabled = true;
            btnEliminar.Enabled = true;
            btnCancelar.Enabled = false;
            btnEditar.Text = "EDITAR";

            ActualizarComboBoxMaterias();
            cmbMateria.SelectedIndex = -1;
            cmbMateria.SelectedIndex = index;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int index = cmbMateria.SelectedIndex;
            if(index < 0)
            {
                return;
            }
            cnMateria.EliminarMateria((int)materias.ElementAt(index).id);
            ActualizarComboBoxMaterias();
            if(materias.Count > 0)
            {
                cmbMateria.SelectedIndex = 0;
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if(materias.Count == 0)
            {
                return;
            }

            int index = cmbMateria.SelectedIndex;

            FrmEvaluaciones frmEvaluaciones = new FrmEvaluaciones();
            frmEvaluaciones.Text += $" de la materia {materias.ElementAt(index).nombre}";
            frmEvaluaciones.Show();
        }
    }
}
