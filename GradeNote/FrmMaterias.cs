using CapaNegocios;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmMaterias : Form
    {
        public int id_grupo { get; set;}

        CN_Materia cnMateria = new();

        public List<Materia> materias;

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

        //Esta lo hace para todas las materias y no una, se debe añadir a las tablas de notas el atributo id_materia
        private void ActualizarTablaEstudiantes()
        {
            CNEstudiantes cnestudiantes = new();
            if (materias == null)
            {
                return;
            }
            int index = cmbMateria.SelectedIndex;
            if (index == -1 || materias.Count == 0)
            {
                return;
            }
            List<Estudiante> estudiantes =  cnestudiantes.ListaEstudiantes(id_grupo);
            if(estudiantes == null)
            {
                return;
            }

            if (estudiantes.Count == 0 )
            {
                return;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("Apellido", typeof(string));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("IP", typeof(double));
            dt.Columns.Add("IIP", typeof(double));
            dt.Columns.Add("IIIP", typeof(double));
            dt.Columns.Add("IVP", typeof(double));
           
            int k = 0;
            foreach(Estudiante est in estudiantes)
            {
                dt.Rows.Add();
                dt.Rows[k].SetField(0, est.apellidos);
                dt.Rows[k].SetField(1, est.nombres);
                dt.Rows[k].SetField(2, cnMateria.NotaParcialDeEstudiante(est.id, materias.ElementAt(index).id, 1));
                dt.Rows[k].SetField(3, cnMateria.NotaParcialDeEstudiante(est.id, materias.ElementAt(index).id, 2));
                dt.Rows[k].SetField(4, cnMateria.NotaParcialDeEstudiante(est.id, materias.ElementAt(index).id, 3));
                dt.Rows[k].SetField(5, cnMateria.NotaParcialDeEstudiante(est.id, materias.ElementAt(index).id, 4));
                k++;
            }
            dgvEstudiantes.DataSource = dt;
            //dgvEstudiantes.DataSource = cnestudiantes.ObtenerNotaEstudiante(id_grupo, (int)materias.ElementAt(index).id);
        }

        private void cmbMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(materias == null)
            {
                return;
            }
            int index = cmbMateria.SelectedIndex;
            if (index == -1 || materias.Count == 0)
            {
                return;
            }
            textBox1.Text = materias.ElementAt(index).nombre;
            ActualizarTablaEstudiantes();
        }
        private void ValidarMaterias(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre de la materia es requerido");
            }

        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
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
                ValidarMaterias(textBox1.Text);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Box Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
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
        }

        private void FrmMaterias_Shown(object sender, EventArgs e)
        {
            ActualizarComboBoxMaterias();
            ActualizarTablaEstudiantes();
            if(materias.Count > 0)
            {
                cmbMateria.SelectedIndex = -1;
                cmbMateria.SelectedIndex = 0;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (materias.Count <= 0)
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
                ValidarMaterias(textBox1.Text);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Box Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            frmEvaluaciones.materia = materias.ElementAt(index);
            frmEvaluaciones.Text += $" de la materia {materias.ElementAt(index).nombre}";
            frmEvaluaciones.FormClosed += CerrandoMateria;
            frmEvaluaciones.ShowDialog();
        }

        private void CerrandoMateria(object sender, EventArgs e)
        {
            ActualizarTablaEstudiantes();
        }
    }
}
