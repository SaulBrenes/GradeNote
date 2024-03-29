﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
        //Objetos que guardan información
        private Colegio datoscolegio = new Colegio();
        private List<Grupo> grupos;
        //Objetos de la capa negocios
        private CN_Colegio Ncolegio = new CN_Colegio();
        private CN_Grupo n_Grupo = new CN_Grupo();
        //Variables auxiliares
        bool hayOperacion = false;


        public FrmInicio()
        {
            InitializeComponent();
        }

        //Metodo que se corre cuando se ve el formulario por primera vez
        private void FrmInicio_Shown(object sender, EventArgs e)
        {
            grupos = n_Grupo.ObtenerListaGrupos();
            actualizarColegio();
            ActualizarComboBox();
            this.cmbGrupos.Focus();
        }

                              //Acciones de los botones u otros componentes
        
        //Editar datos del colegio
        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnEditar.Text.Equals("Editar"))
                {
                    edicionDeTxt(!true, 0);
                    btnEditar.Text = "Guardar cambios";
                    txtNombre.Focus();
                }
                else
                {
                    ValidarGrado(txtGrado.Text, txtTurno.Text, out Int64 ano);
                    //Colegio colegio = new Colegio(txtNombre.Text, txtDirector.Text, txtMunicipio.Text, txtDepartamento.Text, txtNucleo.Text, txtProfesor.Text);
                    Colegio colegio = new Colegio
                    {
                        nombre = txtNombre.Text,
                        director = txtDirector.Text,
                        municipio = txtMunicipio.Text,
                        departamento = txtDepartamento.Text,
                        profesor = txtProfesor.Text,
                        nucleoEducativo = txtNucleo.Text
                    };
                    Ncolegio.EditarDatosColegio(colegio);
                    actualizarColegio();
                    edicionDeTxt(!false, 0);
                    btnEditar.Text = "Editar";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Box Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Metodo para validar campos de texto
        private void ValidarGrado(string grado, string turno,out Int64 anio )
        {
            if (string.IsNullOrWhiteSpace(grado))
            {
                throw new ArgumentException("El Grado es requerido");
            }
            if (string.IsNullOrWhiteSpace(turno))
            {
                throw new ArgumentException("El Turno es requerido");
            }
            if (!Int64.TryParse(txtAnio.Text, out Int64 ano))
            {
                throw new ArgumentException($"El valor del año lectivo no es valido");
            }
            anio = ano;
            if (anio < 0)
            {
                throw new ArgumentException($"No se admiten valores negativos");
            }

        }

        //Metodo para agregar un grupo
        private void btnAgregar_Click(object sender, EventArgs e)
        {

            try
            {
//<<<<<<< HEAD
                if (btnAgregar.Text.Equals("Agregar"))
                {
                    edicionDeTxt(!true, 1);
                    LimpiarTxtGrupo();
                    btnAgregar.Text = "Guardar";
                    txtGrado.Focus();
                    hayOperacion = true;
                    btnEditGroup.Enabled = false;
                    btnEliminar.Enabled = false;
                    return;
                }

                //Guardando nuevo grupo y actulizando objetos datos
                Int64 anio = Int64.Parse(txtAnio.Text);
                Grupo g = new Grupo(txtGrado.Text, txtTurno.Text, anio);
                n_Grupo.AgregarNuevoGrupo(g);
                grupos = n_Grupo.ObtenerListaGrupos();
                ActualizarComboBox();

                //Limpiando seleccion para seleccionar el nuevo grupo creado
                cmbGrupos.SelectedIndex = grupos.Count - 1;
                btnAgregar.Text = "Agregar";
                edicionDeTxt(!false, 1);
                btnEditGroup.Enabled = true;
                btnEliminar.Enabled = true;
                hayOperacion = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Box Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Método para ingresar al formulario grupo
        //VALIDAR: CUANDO NO HAY NINGUN GRUPO 
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if(grupos.Count == 0)
            {
                return;
            }
            FrmGrupo frmGrupo = new FrmGrupo();
            int grupoAbierto = cmbGrupos.SelectedIndex;
            frmGrupo.grupo = grupos.ElementAt(grupoAbierto);
            frmGrupo.Text += $" {grupos.ElementAt(grupoAbierto).nombre}.";
            frmGrupo.Show();
        }

        //Cambia los valores de los texbox cuando se cambie el item del combobox
        private void cmbGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmbGrupos.SelectedIndex;
            if(index == -1)
            {
                return;
            }
            txtGrado.Text = grupos.ElementAt(index).nombre;
            txtTurno.Text = grupos.ElementAt(index).turno;
            txtAnio.Text = $"{grupos.ElementAt(index).anio}";
        }


                          //Metodos para actualizar formulario

        //Actualizar items de combobox
        private void ActualizarComboBox()
        {
            GrupoDB grupoDB = new GrupoDB();
            DataTable DT = n_Grupo.ObtenerDataTableGrupos();
            cmbGrupos.DataSource = DT;
            cmbGrupos.DisplayMember = "nombre";
            cmbGrupos.ValueMember = "id";

        }

        //Actualiza datos de los textbox de propiedades de colegio
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

        //Permite que los texbox se puedan editar el texto dependiendo del booleano
        //i= 0 es para texbox colegio
        // i = 1 es para texbox grupo
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

        //Limpia textbox de caracteristicas grupo
        private void LimpiarTxtGrupo()
        {
            txtGrado.Text = "";
            txtTurno.Text = "";
            txtAnio.Text = "";
        }
        
        //VALIDAR: entrada de datos y cuando no hay grupos creados
        private void btnEditGroup_Click(object sender, EventArgs e)
        {
            try
            {
                if (grupos.Count == 0)
                {
                    LimpiarTxtGrupo();
                    return;
                }

                if (btnEditGroup.Text.Equals("Editar"))
                {
                    edicionDeTxt(!true, 1);
                    btnEditGroup.Text = "Guardar";
                    txtGrado.Focus();
                    hayOperacion = true;
                    btnAgregar.Enabled = false;
                    btnEliminar.Enabled = false;
                    return;
                }

                //Guardando nuevo grupo y actulizando objetos datos
                ValidarGrado(txtGrado.Text, txtTurno.Text, out Int64 ano);
                int index = cmbGrupos.SelectedIndex;
                Int64 anio = Int64.Parse(txtAnio.Text);
                Grupo g = new Grupo(grupos.ElementAt(index).id, txtGrado.Text, txtTurno.Text, anio);
                n_Grupo.EditarGrupo(g);
                grupos = n_Grupo.ObtenerListaGrupos();
                ActualizarComboBox();

                //Limpiando seleccion para seleccionar el nuevo grupo editado
                cmbGrupos.SelectedIndex = -1;
                cmbGrupos.SelectedIndex = index;
                btnEditGroup.Text = "Editar";
                edicionDeTxt(!false, 1);
                btnAgregar.Enabled = true;
                btnEliminar.Enabled = true;
                hayOperacion = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Box Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            if(hayOperacion == false )
            {
                return;
            }

            if (btnAgregar.Text.Equals("Guardar"))
            {
                btnAgregar.Text = "Agregar";
                edicionDeTxt(!false, 1);
                int index = cmbGrupos.SelectedIndex;
                LimpiarTxtGrupo();
                cmbGrupos.SelectedIndex = -1;
                cmbGrupos.SelectedIndex = index;
                btnEditGroup.Enabled = true;
                btnEliminar.Enabled = true;
                hayOperacion = false;

            }
            else if(btnEditGroup.Text.Equals("Guardar"))
            {
                btnEditGroup.Text = "Editar";
                edicionDeTxt(!false, 1);
                int index = cmbGrupos.SelectedIndex;
                cmbGrupos.SelectedIndex = -1;
                cmbGrupos.SelectedIndex = index;
                btnAgregar.Enabled = true;
                btnEliminar.Enabled = true;
                hayOperacion = false;
            }
            hayOperacion = false;
        }

        //Fijarse como se eliminar el grupo y los indices de nuevos grupos
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int index = cmbGrupos.SelectedIndex;
            if (index < 0)
            {
                return;
            }
            bool esborrado = n_Grupo.EliminarGrupo((int)grupos.ElementAt(index).id);
            grupos = n_Grupo.ObtenerListaGrupos();
            ActualizarComboBox();
            if (grupos.Count == 0)
            {
                LimpiarTxtGrupo();
                return;
            }
            cmbGrupos.SelectedIndex = grupos.Count - 1;
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
