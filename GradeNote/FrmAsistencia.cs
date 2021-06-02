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
    public partial class FrmAsistencia : Form
    {
        public int id_grupo { get; set; }
        public int id_estudiante { get; set; }
        CNAsistencia CNasistencia = new CNAsistencia();
        List<Asistencia> asistencias = new List<Asistencia>();

        public FrmAsistencia()
        {
            InitializeComponent();
        }

        private void FrmAsistencia_Load(object sender, EventArgs e)
        {

        }
    }
}
