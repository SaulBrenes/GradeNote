using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CapaDatos;
using CapaNegocios;
using CapaPresentacion;
using Entidades;

namespace GradeNote
{
    public partial class FrmInicio : Form
    {
        private List<Grupo> grupos;
        private CN_Colegio Ncolegio = new CN_Colegio();
        private CN_Grupo n_Grupo = new CN_Grupo();
        private Colegio datoscolegio = new Colegio();

        public FrmInicio()
        {
            InitializeComponent();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (btnEditar.Text.Equals("Editar"))
            {
                edicionDeTxt(!true, 0);
                btnEditar.Text = "Guardar cambios";
                txtNombre.Focus();
            }
            else
            {
                Colegio colegio = new Colegio(txtNombre.Text, txtDirector.Text, txtMunicipio.Text, txtDepartamento.Text, txtNucleo.Text, txtProfesor.Text);
                Ncolegio.EditarDatosColegio(colegio);
                actualizarColegio();
                edicionDeTxt(!false, 0);
                btnEditar.Text = "Editar";  
            }  
        }
        
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (btnAgregar.Text.Equals("Agregar"))
            {
                edicionDeTxt(!true, 1);
                LimpiarTxtGrupo();
                btnAgregar.Text = "Guardar";
                return;
            }
            
            Int64 anio = Int64.Parse(txtAnio.Text);
            Grupo g = new Grupo(txtGrado.Text, txtTurno.Text, anio);
            n_Grupo.AgregarNuevoGrupo(g);
            grupos = n_Grupo.ObtenerListaGrupos();
            ActualizarComboBox();
            //Limpiando seleccion para seleccionar el nuevo grupo creado
            cmbGrupos.SelectedIndex = grupos.Count - 1;
            btnAgregar.Text=  "Agregar";
            edicionDeTxt(!false, 1);
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            FrmGrupo frmGrupo = new FrmGrupo();
            int grupoAbierto = cmbGrupos.SelectedIndex;
            frmGrupo.Text += $" {grupos.ElementAt(grupoAbierto).nombre}.";
            frmGrupo.Show();
        }

        //Metodos para actualizar vista
        private void ActualizarComboBox()
        {
            GrupoDB grupoDB = new GrupoDB();
            DataTable DT = n_Grupo.ObtenerDataTableGrupos();
            cmbGrupos.DataSource = DT;
            cmbGrupos.DisplayMember = "nombre";
            cmbGrupos.ValueMember = "id";

            //items = DT.AsEnumerable().Select(row =>
            //new Grupo
            //{
            //    Id = (int)row.Field<Int64>("id"),
            //    Nombre = row.Field<string>("nombre")
            //}).ToList();
        }

        private void actualizarColegio()
        {
            datoscolegio = Ncolegio.ObtenerDatosActuales();
            txtNombre.Text = datoscolegio.nombre;
            txtMunicipio.Text = datoscolegio.municipio;
            txtDepartamento.Text = datoscolegio.departamento;
            txtDirector.Text = datoscolegio.director;
            txtNucleo.Text = datoscolegio.nucleoEducativo;
            txtProfesor.Text = datoscolegio.profesor;
        }

        private void edicionDeTxt(bool bandera, int i)
        {
            switch (i)
            {
                case 0:
                    txtNombre.ReadOnly = bandera;
                    txtMunicipio.ReadOnly = bandera;
                    txtDepartamento.ReadOnly = bandera;
                    txtDirector.ReadOnly = bandera;
                    txtNucleo.ReadOnly = bandera;
                    txtProfesor.ReadOnly = bandera;
                    break;
                case 1:
                    txtGrado.ReadOnly = bandera;
                    txtTurno.ReadOnly = bandera;
                    txtAnio.ReadOnly = bandera;
                    break;
            }
           
        }

        private void LimpiarTxtGrupo()
        {
            txtGrado.Text = "";
            txtTurno.Text = "";
            txtAnio.Text = "";
        }

        private void cmbGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmbGrupos.SelectedIndex;
            txtGrado.Text = grupos.ElementAt(index).nombre;
            txtTurno.Text = grupos.ElementAt(index).turno;
            txtAnio.Text = $"{grupos.ElementAt(index).anio}";
        }

        private void FrmInicio_Shown(object sender, EventArgs e)
        {
            grupos = n_Grupo.ObtenerListaGrupos();
            actualizarColegio();
            ActualizarComboBox();
            this.cmbGrupos.Focus();
        }

        private void btnEditGroup_Click(object sender, EventArgs e)
        {

        }
    }
}
