﻿
namespace CapaPresentacion
{
    partial class Boletin
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lblnombre = new System.Windows.Forms.Label();
            this.dgvBoletin = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblProfesor = new System.Windows.Forms.Label();
            this.lblMunicipio = new System.Windows.Forms.Label();
            this.lblDepartamento = new System.Windows.Forms.Label();
            this.lblDirector = new System.Windows.Forms.Label();
            this.lblNombreEscuela = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblpromedio = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoletin)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Estudiante:";
            // 
            // lblnombre
            // 
            this.lblnombre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblnombre.AutoSize = true;
            this.lblnombre.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblnombre.Location = new System.Drawing.Point(103, 9);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(61, 22);
            this.lblnombre.TabIndex = 1;
            this.lblnombre.Text = "TEXTO";
            // 
            // dgvBoletin
            // 
            this.dgvBoletin.AllowUserToAddRows = false;
            this.dgvBoletin.AllowUserToDeleteRows = false;
            this.dgvBoletin.AllowUserToResizeColumns = false;
            this.dgvBoletin.AllowUserToResizeRows = false;
            this.dgvBoletin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBoletin.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvBoletin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBoletin.Location = new System.Drawing.Point(21, 222);
            this.dgvBoletin.Name = "dgvBoletin";
            this.dgvBoletin.ReadOnly = true;
            this.dgvBoletin.RowTemplate.Height = 25;
            this.dgvBoletin.Size = new System.Drawing.Size(491, 169);
            this.dgvBoletin.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblProfesor);
            this.groupBox1.Controls.Add(this.lblMunicipio);
            this.groupBox1.Controls.Add(this.lblDepartamento);
            this.groupBox1.Controls.Add(this.lblDirector);
            this.groupBox1.Controls.Add(this.lblNombreEscuela);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(21, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(491, 182);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información Institución:";
            // 
            // lblProfesor
            // 
            this.lblProfesor.AutoSize = true;
            this.lblProfesor.Location = new System.Drawing.Point(82, 143);
            this.lblProfesor.Name = "lblProfesor";
            this.lblProfesor.Size = new System.Drawing.Size(61, 22);
            this.lblProfesor.TabIndex = 9;
            this.lblProfesor.Text = "TEXTO";
            // 
            // lblMunicipio
            // 
            this.lblMunicipio.AutoSize = true;
            this.lblMunicipio.Location = new System.Drawing.Point(310, 77);
            this.lblMunicipio.Name = "lblMunicipio";
            this.lblMunicipio.Size = new System.Drawing.Size(61, 22);
            this.lblMunicipio.TabIndex = 7;
            this.lblMunicipio.Text = "TEXTO";
            // 
            // lblDepartamento
            // 
            this.lblDepartamento.AutoSize = true;
            this.lblDepartamento.Location = new System.Drawing.Point(119, 111);
            this.lblDepartamento.Name = "lblDepartamento";
            this.lblDepartamento.Size = new System.Drawing.Size(61, 22);
            this.lblDepartamento.TabIndex = 8;
            this.lblDepartamento.Text = "TEXTO";
            // 
            // lblDirector
            // 
            this.lblDirector.AutoSize = true;
            this.lblDirector.Location = new System.Drawing.Point(97, 77);
            this.lblDirector.Name = "lblDirector";
            this.lblDirector.Size = new System.Drawing.Size(61, 22);
            this.lblDirector.TabIndex = 7;
            this.lblDirector.Text = "TEXTO";
            // 
            // lblNombreEscuela
            // 
            this.lblNombreEscuela.AutoSize = true;
            this.lblNombreEscuela.Location = new System.Drawing.Point(82, 38);
            this.lblNombreEscuela.Name = "lblNombreEscuela";
            this.lblNombreEscuela.Size = new System.Drawing.Size(61, 22);
            this.lblNombreEscuela.TabIndex = 6;
            this.lblNombreEscuela.Text = "TEXTO";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(221, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 22);
            this.label8.TabIndex = 5;
            this.label8.Text = "Municipio:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 22);
            this.label7.TabIndex = 4;
            this.label7.Text = "Departamento:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 22);
            this.label6.TabIndex = 3;
            this.label6.Text = "Profesor:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 22);
            this.label4.TabIndex = 1;
            this.label4.Text = "Director:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(10, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nombre:";
            // 
            // lblpromedio
            // 
            this.lblpromedio.AutoSize = true;
            this.lblpromedio.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblpromedio.Location = new System.Drawing.Point(103, 394);
            this.lblpromedio.Name = "lblpromedio";
            this.lblpromedio.Size = new System.Drawing.Size(61, 22);
            this.lblpromedio.TabIndex = 11;
            this.lblpromedio.Text = "TEXTO";
            this.lblpromedio.Click += new System.EventHandler(this.lblpromedio_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(21, 394);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 22);
            this.label9.TabIndex = 10;
            this.label9.Text = "Promedio:";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // Boletin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblpromedio);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dgvBoletin);
            this.Controls.Add(this.lblnombre);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Boletin";
            this.Size = new System.Drawing.Size(547, 726);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoletin)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblnombre;
        private System.Windows.Forms.DataGridView dgvBoletin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblProfesor;
        private System.Windows.Forms.Label lblMunicipio;
        private System.Windows.Forms.Label lblDepartamento;
        private System.Windows.Forms.Label lblDirector;
        private System.Windows.Forms.Label lblNombreEscuela;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblpromedio;
        private System.Windows.Forms.Label label9;
    }
}
