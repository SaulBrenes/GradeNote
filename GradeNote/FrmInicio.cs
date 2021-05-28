using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CapaDatos;
using CapaPresentacion;
using Entidades;

namespace GradeNote
{
    public partial class FrmInicio : Form
    {
        private Colegio colegio = new Colegio();
        private List<Grupo> items;
        public FrmInicio()
        {
            InitializeComponent();
            ActualizarComboBox();
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
        
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (btnAgregar.Text.Equals("Agregar"))
            {
                LimpiarTxtGrupo();
                btnAgregar.Text = "Guardar";
                return;
            }
            
            int anio = Int32.Parse(txtAnio.Text);
            Grupo g = new Grupo(txtGrado.Text, txtTurno.Text, anio);
            GrupoDB db = new GrupoDB();
            db.CrearGrupo(g);
            ActualizarComboBox();
            //Limpiando seleccion para seleccionar el nuevo grupo creado
            cmbGrupos.SelectedText = "";
            cmbGrupos.SelectedText= g.Nombre;
            btnAgregar.Text=  "Agregar";
        }

        //Metodos para actualizar vista
        private void ActualizarComboBox()
        {
            GrupoDB grupoDB = new GrupoDB();
            DataTable DT = grupoDB.ObtenerGrupos();
            cmbGrupos.DataSource = DT;
            cmbGrupos.DisplayMember = "nombre";
            cmbGrupos.ValueMember = "id";

            items = DT.AsEnumerable().Select(row =>
            new Grupo
            {
                Id = (int)row.Field<Int64>("id"),
                Nombre = row.Field<string>("nombre")
            }).ToList();
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


        private void LimpiarTxtGrupo()
        {
            txtGrado.Text = "";
            txtTurno.Text = "";
            txtAnio.Text = "";
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            FrmGrupo frmGrupo = new FrmGrupo();
            int grupoAbierto = cmbGrupos.SelectedIndex;
            frmGrupo.Text += $" {items.ElementAt(grupoAbierto).Nombre}.";
            frmGrupo.Show();
        }
    }
}
