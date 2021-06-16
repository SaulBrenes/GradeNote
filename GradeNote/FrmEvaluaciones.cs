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
    public partial class FrmEvaluaciones : Form
    {
        public Materia materia { get; set; }
        CNEstudiantes CNestudiante = new CNEstudiantes();
        CNEvaluacion CNevaluacion = new();
        CNNota CNnotas = new();
        List<Estudiante> estudiantes = new List<Estudiante>();
        List<Evaluacion> evaluaciones = new List<Evaluacion>();
        bool SeAgrega;

        public FrmEvaluaciones()
        {
            InitializeComponent();
        }

        private void FrmEvaluaciones_Load(object sender, EventArgs e)
        {
            //Cargando estudiantes del grupo y validando que exista registro de al menos uno
            estudiantes = CNestudiante.ListaEstudiantes((int)materia.id_grupo);
            if (estudiantes.Count == 0)
            {
                MessageBox.Show("Registre estudiantes.", "No se pueden crear evaluaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            //Obteniendo evaluaciones de la materia
            CargandoEvaluaciones();
        }
       
        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (btnAgregar.Text.Equals("AGREGAR"))
            {
                //Habilitando o desabilitando botones necesarios
                btnCancelar.Enabled = true;
                btnEliminar.Enabled = false;
                btnDarNota.Enabled = false;
                btnSeleccionar.Enabled = false;
                //Cambiando propiedades para un nuevo ingreso
                btnAgregar.Text = "GUARDAR";
                txtNombre.ReadOnly = false;
                nudParcial.Enabled = true;
                nudValor.Enabled = true; nudValor.Value = 1;
                txtNombre.Focus(); txtNombre.Text = "";
                ValidarCampoValorEvaluacion();
                return;
            }

            if (!SeAgrega)
            {
                MessageBox.Show("No se pueden agregar más evaluaciones. Alcanzo el 100%");
                return;
            }
            //*****Al agregar que el valor no sea cero
            Evaluacion nueva = new Evaluacion
            {
                id_materia = materia.id,
                nombre = txtNombre.Text,
                valor = Int64.Parse(nudValor.Value.ToString()),
                numeroParcial = Int64.Parse(nudParcial.Value.ToString())
            };
            CNevaluacion.CrearEvaluacion(nueva);

            //Obtener las nuevas evaluaciones
            CargandoEvaluaciones();
            int idEvaluacion = (int)evaluaciones.ElementAt(evaluaciones.Count - 1).id;
            //Creando notas de  esa evaluacion a cada estudiante
            Nota n = new Nota
            {
                id_evaluacion = idEvaluacion,
                valor = 0
            };
            foreach(Estudiante est in estudiantes)
            {
                n.id_estudiante = est.id;
                CNnotas.CrearNota(n, nueva.numeroParcial, materia.id);
            }

            btnCancelar.Enabled = false;
            btnEliminar.Enabled = true;
            btnDarNota.Enabled = true;
            btnSeleccionar.Enabled = true;
            btnAgregar.Text = "AGREGAR";
            txtNombre.ReadOnly = true;
            nudParcial.Enabled = false;
            nudValor.Enabled = false;
            SeleccionarFila(dgvEvaluaciones.Rows.Count - 1);
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvEvaluaciones.SelectedRows.Count <= 0)
            {
                return;
            }
            
            //Indice de la primera fila seleccionada
            int index = dgvEvaluaciones.SelectedRows[0].Index;
            //Obteniendo evaluacion seleccionada y notas de la evaluacion seleccionada
            Evaluacion seleccinada = evaluaciones.ElementAt(index);
            dgvEstudiantes.DataSource = CNnotas.ObtenerNotasEvaluacion((int)seleccinada.id, seleccinada.numeroParcial);
            txtNombre.Text = seleccinada.nombre;
            nudParcial.Value = seleccinada.numeroParcial;
            nudValor.Maximum = 100;
            nudValor.Value = seleccinada.valor;
            nudNotaEstudiante.Maximum = seleccinada.valor;
            btnDarNota.Enabled = true;
        }

        private void btnDarNota_Click_1(object sender, EventArgs e)
        {   
            long nota = (long)nudNotaEstudiante.Value;
            int indexEst = dgvEstudiantes.SelectedRows[0].Index;
            int indexEva = dgvEvaluaciones.SelectedRows[0].Index;
            Nota notaEdit = new Nota
            {
                id_estudiante = estudiantes.ElementAt(indexEst).id,
                id_evaluacion = evaluaciones.ElementAt(indexEva).id,
                valor = nota
            };

            CNnotas.EditarNotaAEstudiante(notaEdit, evaluaciones.ElementAt(indexEva).numeroParcial);
            dgvEstudiantes.DataSource = null;
            dgvEstudiantes.DataSource = CNnotas.ObtenerNotasEvaluacion(indexEva, evaluaciones.ElementAt(indexEva).numeroParcial);
            nudNotaEstudiante.Value = 0;
        }

        private void nudParcial_ValueChanged(object sender, EventArgs e)
        {
            ValidarCampoValorEvaluacion();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
           if(dgvEvaluaciones.RowCount <= 0)
           {
                return;
           }

            if (dgvEvaluaciones.SelectedRows.Count == 0)
            {
                return;
            }

            //Indice de la primera fila seleccionada
            int index = dgvEvaluaciones.SelectedRows[0].Index;
            //Obteniendo evaluacion seleccionada y notas de la evaluacion seleccionada
            Evaluacion seleccinada = evaluaciones.ElementAt(index);
            CNnotas.EliminarNotas(seleccinada.numeroParcial, seleccinada.id);
            CNevaluacion.EliminarEvaluacion(seleccinada.id);
            CargandoEvaluaciones();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (btnAgregar.Text.Equals("GUARDAR"))
            {
                btnCancelar.Enabled = false;
                btnEliminar.Enabled = true;
                btnDarNota.Enabled = true;
                btnSeleccionar.Enabled = true;
                btnAgregar.Text = "AGREGAR";
                txtNombre.ReadOnly = true; txtNombre.Text = "";
                nudParcial.Enabled = false;
                nudValor.Enabled = false;

                if (dgvEvaluaciones.Rows.Count == 0)
                {
                    return;
                }

                int index = dgvEvaluaciones.Rows[0].Index;
                Evaluacion seleccinada = evaluaciones.ElementAt(index);
                dgvEstudiantes.DataSource = CNnotas.ObtenerNotasEvaluacion((int)seleccinada.id, seleccinada.numeroParcial);
                txtNombre.Text = seleccinada.nombre;
                nudParcial.Value = seleccinada.numeroParcial;
                nudValor.Value = seleccinada.valor;
                nudNotaEstudiante.Maximum = seleccinada.valor;
            }
        }

        private void ValidarCampoValorEvaluacion()
        {
            int parcial = (int)nudParcial.Value;
            long valorAcumulado = 0;
            SeAgrega = true;
            switch (parcial)
            {
                case 1:
                    if (materia.evaluacionesIParcial == null)
                    {
                        return;
                    }
                    valorAcumulado = (long)materia.evaluacionesIParcial.Sum(eva => eva.valor);
                    break;
                case 2:
                    if (materia.evaluacionesIIParcial == null)
                    {
                        return;
                    }
                    valorAcumulado = (long)materia.evaluacionesIIParcial.Sum(eva => eva.valor);
                    break;
                case 3:
                    if (materia.evaluacionesIIIParcial == null)
                    {
                        return;
                    }
                    valorAcumulado = (long)materia.evaluacionesIIIParcial.Sum(eva => eva.valor);
                    break;
                case 4:
                    if (materia.evaluacionesIVParcial == null)
                    {
                        return;
                    }
                    valorAcumulado = (long)materia.evaluacionesIVParcial.Sum(eva => eva.valor);
                    break;
            }
            nudValor.Maximum = 100 - valorAcumulado;
            if (nudValor.Maximum == 0)
            {
                nudValor.Maximum = 100;
                nudValor.Value = 0;
                SeAgrega = false;
            }
            else
            {
                SeAgrega = true;
            }
        }

        private void CargandoEvaluaciones()
        {
            //MessageBox.Show($"ID de {materia.nombre} :{materia.id}");
            dgvEvaluaciones.DataSource = CNevaluacion.ObtenerEvaluacionesDeMateria((int)materia.id);
            dgvEvaluaciones.ClearSelection();
            evaluaciones = CNevaluacion.ObetenerListaDeEvaluaciones((int)materia.id);
            if (evaluaciones.Count == 0)
            {
                return;
            }
            materia.evaluacionesIParcial = evaluaciones.Where(evaluacion => evaluacion.numeroParcial == 1).ToList();
            materia.evaluacionesIIParcial = evaluaciones.Where(evaluacion => evaluacion.numeroParcial == 2).ToList();
            materia.evaluacionesIIIParcial = evaluaciones.Where(evaluacion => evaluacion.numeroParcial == 3).ToList();
            materia.evaluacionesIVParcial = evaluaciones.Where(evaluacion => evaluacion.numeroParcial == 4).ToList();
        }

        private void SeleccionarFila(int index)
        {
            //Obteniendo evaluacion seleccionada y notas de la evaluacion seleccionada
            Evaluacion seleccinada = evaluaciones.ElementAt(index);
            dgvEvaluaciones.Rows[index].Selected = true;
            dgvEstudiantes.DataSource = CNnotas.ObtenerNotasEvaluacion((int)seleccinada.id, seleccinada.numeroParcial);
            txtNombre.Text = seleccinada.nombre;
            nudParcial.Value = seleccinada.numeroParcial;
            nudValor.Value = seleccinada.valor;
            nudNotaEstudiante.Value = 0;
            nudNotaEstudiante.Maximum = seleccinada.valor;

        }
    }
}
