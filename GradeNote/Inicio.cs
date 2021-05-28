using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            int anio = Int32.Parse(txtAnio.Text);
            Grupo g = new Grupo(txtGrado.Text, txtTurno.Text, anio);
            GrupoDB db = new GrupoDB();
            db.CrearGrupo(g);
            ActualizarComboBox();
            //Limpiando seleccion para seleccionar el nuevo grupo creado
            cmbGrupos.SelectedText = "";
            cmbGrupos.SelectedText= g.Nombre;
        }

        //Metodos para actualizar vista
        private void ActualizarComboBox()
        {
            GrupoDB grupoDB = new GrupoDB();
            DataTable DT = grupoDB.ObtenerGrupos();
            
            cmbGrupos.DataSource = DT;
            cmbGrupos.DisplayMember = "nombre";
            cmbGrupos.ValueMember = "id";

            List<Grupo> items = DT.AsEnumerable().Select(row =>
            new Grupo
            {
                Id = (int)row.Field<Int64>("id"),
                Nombre = row.Field<string>("nombre")
            }).ToList();

            string lista = "";
            foreach(Grupo i in items)
            {
                lista+=$"{i.Id}. {i.Nombre} \n";
            }
            MessageBox.Show(lista);
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
