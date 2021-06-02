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
            if (dgvEstudiantes.SelectedRows.Count <= 0)
            {
                return;
            }

            int index = dgvEstudiantes.SelectedRows[0].Index;
            //Validando que se selecciono una fila correcta
            if (index == -1) {
                return;
            }
            //Pasando datos
            txtNombres.Text = estudiantes.ElementAt(index).nombres;
            txtApellidos.Text = estudiantes.ElementAt(index).apellidos;
            txtCodigo.Text = estudiantes.ElementAt(index).codigo;
        }

        //Agregar un nuevo estudiante
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (btnAgregar.Text.Equals("Agregar"))
            {
                //Limpiando campos y selecciones
                txtNombres.Text = ""; txtNombres.ReadOnly = false; txtNombres.Focus();
                txtApellidos.Text = ""; txtApellidos.ReadOnly = false;
                txtCodigo.Text = ""; txtCodigo.ReadOnly = false;
                dgvEstudiantes.ClearSelection();

                //Inabilitando botones
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
                btnCancelar.Enabled = true;
                btnAgregar.Text = "Guardar";
                return;
            }

            //Creando nuevo estudiante con los datos ingresados
            Estudiante nuevoEst = new Estudiante
            {
                id_grupo = id_grupo,
                nombres = txtNombres.Text,
                apellidos = txtApellidos.Text,
                codigo = txtCodigo.Text
            };
            cnEst.AgregarEstudiante(nuevoEst);

            //Obteniendo nuevos datos de la DB sqlite,actualizando lista y seleccion de la tabla
            dgvEstudiantes.DataSource = cnEst.TablaEstudiantesDelGrupo(id_grupo);
            estudiantes = cnEst.ListaEstudiantes(id_grupo);
            dgvEstudiantes.ClearSelection();
            dgvEstudiantes.Rows[estudiantes.Count - 1].Selected= true;

            //Deshabilitando escritura
            txtNombres.ReadOnly = true;
            txtApellidos.ReadOnly = true;
            txtCodigo.ReadOnly = true;

            //Habilitando botones
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            btnCancelar.Enabled = false;
            btnAgregar.Text = "Agregar";
        }
    }
}
