﻿using Entidades;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmGrupo : Form
    {
        public Grupo grupo { get; set; }
        FrmMaterias frmMaterias;
        FrmEstudiantes frmEstudiantes;
        FrmEstadistica frmEstadistica;
        FrmAsistencia frmAsistencia;
        FrmBoletin frmBoletin;

        public FrmGrupo()
        {
            InitializeComponent();
        }

        private void materiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
           frmMaterias = new FrmMaterias();
           string nombre = $" del {grupo.nombre}";
           frmMaterias.Text += nombre;
           frmMaterias.id_grupo = (int)grupo.id;
           //frmMaterias.MdiParent = this;
           frmMaterias.ShowDialog();
        }

        private void FrmGrupo_Load(object sender, EventArgs e)
        {
        }

        private void estudiantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstudiantes = new FrmEstudiantes();
            string nombre = $" del {grupo.nombre}";
            frmEstudiantes.Text += nombre;
            frmEstudiantes.id_grupo = (int)grupo.id;
            //frmEstudiantes.MdiParent = this;
            frmEstudiantes.ShowDialog();       
        }

        private void estadisticaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstadistica = new FrmEstadistica();
            string nombre = $" del {grupo.nombre}";
            frmEstadistica.Text += nombre;
            frmEstadistica.id_grupo = (int)grupo.id;
            //frmEstadistica.MdiParent = this;
            frmEstadistica.ShowDialog();
        }

        private void asistenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAsistencia = new FrmAsistencia();
            string nombre = $" del {grupo.nombre}";
            frmAsistencia.Text += nombre;
            frmAsistencia.id_grupo = (int) grupo.id;
            //frmAsistencia.MdiParent = this;
            frmAsistencia.ShowDialog();
        }

        private void boletinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBoletin = new FrmBoletin();
            string nombre = $" del {grupo.nombre}";
            frmBoletin.Text += nombre;
            frmBoletin.id_grupo = (int)grupo.id;
           // frmBoletin.MdiParent = this;
            frmBoletin.ShowDialog();
        }
    }
}
