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
    public partial class Boletin : UserControl
    {
        public Boletin()
        {
            InitializeComponent();
        }

        public string Promedio
        {
            set => lblpromedio.Text = value;
        }

        public DataTable Tabla
        {
            set => dgvBoletin.DataSource = value;
        }

        public string NombreEstudiante
        {
            set => lblnombre.Text = value;
        }

        public string NombreInstitucion
        {
            set => lblNombreEscuela.Text = value;
        }

       

        public string Departamento
        {
            set => lblDepartamento.Text = value;
        }

        public string Municipio
        {
            set => lblMunicipio.Text = value;
        }

        public string Director
        {
            set => lblDirector.Text = value;
        }

        public string Profesor
        {
            set => lblProfesor.Text = value;
        }
    }

    
}
