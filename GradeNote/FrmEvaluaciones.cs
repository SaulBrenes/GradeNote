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

        public FrmEvaluaciones()
        {
            InitializeComponent();
        }

        private void FrmEvaluaciones_Load(object sender, EventArgs e)
        {
            estudiantes = CNestudiante.ListaEstudiantes((int)materia.id_grupo);
            if (estudiantes.Count == 0)
            {
                return;
            }
            //Obteniendo evaluaciones de la materia
            dgvEvaluaciones.DataSource = CNevaluacion.ObtenerEvaluacionesDeMateria((int)materia.id);
            dgvEvaluaciones.ClearSelection();
            evaluaciones = CNevaluacion.ObetenerListaDeEvaluaciones((int)materia.id);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (btnAgregar.Text.Equals("AGREGAR"))
            {
                btnCancelar.Enabled = true;
                btnEliminar.Enabled = false;
                btnAgregar.Text = "GUARDAR";
                txtNombre.ReadOnly = false;
                txtValor.ReadOnly = false;
                txtNombre.Text = "";
                txtNota.Text = "";
                txtNombre.Focus();
                return;
            }

            Evaluacion nueva = new Evaluacion
            {
                id_materia = materia.id,
                nombre = txtNombre.Text,
                valor = Int64.Parse(txtValor.Text.ToString()),
                numeroParcial = 1
            };
            CNevaluacion.CrearEvaluacion(nueva);

            //Obtener las nuevas evaluaciones
            dgvEvaluaciones.DataSource = CNevaluacion.ObtenerEvaluacionesDeMateria((int)materia.id);
            dgvEvaluaciones.ClearSelection();
            evaluaciones = CNevaluacion.ObetenerListaDeEvaluaciones((int)materia.id);
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
                CNnotas.CrearNota(n);
            }

            btnCancelar.Enabled = false;
            btnEliminar.Enabled = true;
            btnAgregar.Text = "AGREGAR";
            txtNombre.ReadOnly = true;
            txtValor.ReadOnly = true;

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {

        }
    }
}
