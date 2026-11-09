namespace CapaPresentacion
{
    partial class P_DetalleExtintor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.txtCodigoU = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtNroSerie = new System.Windows.Forms.TextBox();
            this.txtNroInterno = new System.Windows.Forms.TextBox();
            this.txtUbicacion = new System.Windows.Forms.TextBox();
            this.txtAnioFabricacion = new System.Windows.Forms.TextBox();
            this.VencimientoPHCalculado = new System.Windows.Forms.TextBox();
            this.txtRutaArchivoSeleccionado = new System.Windows.Forms.TextBox();
            this.cboCapacidad = new System.Windows.Forms.ComboBox();
            this.cboTipoExtintor = new System.Windows.Forms.ComboBox();
            this.dtpFechaPruebaHidro = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaServicio = new System.Windows.Forms.DateTimePicker();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.ProxMantenimientoCalculado = new System.Windows.Forms.TextBox();
            this.cboTipoDocumento = new System.Windows.Forms.ComboBox();
            this.dtgvDocumentos = new System.Windows.Forms.DataGridView();
            this.cboSede = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cboMarca = new System.Windows.Forms.ComboBox();
            this.txtNroCertificado = new System.Windows.Forms.TextBox();
            this.btnQuitarDocumento = new System.Windows.Forms.Button();
            this.btnAgregarDocumento = new System.Windows.Forms.Button();
            this.btnExaminar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDocumentos)).BeginInit();
            this.SuspendLayout();
            // 
            // cboEstado
            // 
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Items.AddRange(new object[] {
            "--SELECCIONE ESTADO--",
            "Vigente",
            "Vencido",
            "De baja",
            "Prestamo"});
            this.cboEstado.Location = new System.Drawing.Point(476, 30);
            this.cboEstado.Margin = new System.Windows.Forms.Padding(2);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(186, 21);
            this.cboEstado.TabIndex = 0;
            // 
            // txtCodigoU
            // 
            this.txtCodigoU.Location = new System.Drawing.Point(36, 37);
            this.txtCodigoU.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoU.Name = "txtCodigoU";
            this.txtCodigoU.Size = new System.Drawing.Size(182, 20);
            this.txtCodigoU.TabIndex = 1;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(671, 442);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(89, 21);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // txtNroSerie
            // 
            this.txtNroSerie.Location = new System.Drawing.Point(36, 88);
            this.txtNroSerie.Margin = new System.Windows.Forms.Padding(2);
            this.txtNroSerie.Name = "txtNroSerie";
            this.txtNroSerie.Size = new System.Drawing.Size(182, 20);
            this.txtNroSerie.TabIndex = 3;
            // 
            // txtNroInterno
            // 
            this.txtNroInterno.Location = new System.Drawing.Point(36, 133);
            this.txtNroInterno.Margin = new System.Windows.Forms.Padding(2);
            this.txtNroInterno.Name = "txtNroInterno";
            this.txtNroInterno.Size = new System.Drawing.Size(182, 20);
            this.txtNroInterno.TabIndex = 4;
            // 
            // txtUbicacion
            // 
            this.txtUbicacion.Location = new System.Drawing.Point(36, 174);
            this.txtUbicacion.Margin = new System.Windows.Forms.Padding(2);
            this.txtUbicacion.Name = "txtUbicacion";
            this.txtUbicacion.Size = new System.Drawing.Size(182, 20);
            this.txtUbicacion.TabIndex = 6;
            // 
            // txtAnioFabricacion
            // 
            this.txtAnioFabricacion.Location = new System.Drawing.Point(36, 266);
            this.txtAnioFabricacion.Margin = new System.Windows.Forms.Padding(2);
            this.txtAnioFabricacion.Name = "txtAnioFabricacion";
            this.txtAnioFabricacion.Size = new System.Drawing.Size(182, 20);
            this.txtAnioFabricacion.TabIndex = 8;
            // 
            // VencimientoPHCalculado
            // 
            this.VencimientoPHCalculado.Location = new System.Drawing.Point(448, 249);
            this.VencimientoPHCalculado.Margin = new System.Windows.Forms.Padding(2);
            this.VencimientoPHCalculado.Name = "VencimientoPHCalculado";
            this.VencimientoPHCalculado.Size = new System.Drawing.Size(214, 20);
            this.VencimientoPHCalculado.TabIndex = 9;
            // 
            // txtRutaArchivoSeleccionado
            // 
            this.txtRutaArchivoSeleccionado.Location = new System.Drawing.Point(448, 411);
            this.txtRutaArchivoSeleccionado.Margin = new System.Windows.Forms.Padding(2);
            this.txtRutaArchivoSeleccionado.Name = "txtRutaArchivoSeleccionado";
            this.txtRutaArchivoSeleccionado.Size = new System.Drawing.Size(214, 20);
            this.txtRutaArchivoSeleccionado.TabIndex = 10;
            // 
            // cboCapacidad
            // 
            this.cboCapacidad.FormattingEnabled = true;
            this.cboCapacidad.Location = new System.Drawing.Point(476, 100);
            this.cboCapacidad.Margin = new System.Windows.Forms.Padding(2);
            this.cboCapacidad.Name = "cboCapacidad";
            this.cboCapacidad.Size = new System.Drawing.Size(186, 21);
            this.cboCapacidad.TabIndex = 11;
            // 
            // cboTipoExtintor
            // 
            this.cboTipoExtintor.FormattingEnabled = true;
            this.cboTipoExtintor.Location = new System.Drawing.Point(476, 65);
            this.cboTipoExtintor.Margin = new System.Windows.Forms.Padding(2);
            this.cboTipoExtintor.Name = "cboTipoExtintor";
            this.cboTipoExtintor.Size = new System.Drawing.Size(186, 21);
            this.cboTipoExtintor.TabIndex = 12;
            // 
            // dtpFechaPruebaHidro
            // 
            this.dtpFechaPruebaHidro.Location = new System.Drawing.Point(448, 226);
            this.dtpFechaPruebaHidro.Margin = new System.Windows.Forms.Padding(2);
            this.dtpFechaPruebaHidro.Name = "dtpFechaPruebaHidro";
            this.dtpFechaPruebaHidro.Size = new System.Drawing.Size(214, 20);
            this.dtpFechaPruebaHidro.TabIndex = 13;
            // 
            // dtpFechaServicio
            // 
            this.dtpFechaServicio.Location = new System.Drawing.Point(448, 178);
            this.dtpFechaServicio.Margin = new System.Windows.Forms.Padding(2);
            this.dtpFechaServicio.Name = "dtpFechaServicio";
            this.dtpFechaServicio.Size = new System.Drawing.Size(214, 20);
            this.dtpFechaServicio.TabIndex = 13;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(764, 444);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(83, 19);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // ProxMantenimientoCalculado
            // 
            this.ProxMantenimientoCalculado.Location = new System.Drawing.Point(448, 202);
            this.ProxMantenimientoCalculado.Margin = new System.Windows.Forms.Padding(2);
            this.ProxMantenimientoCalculado.Name = "ProxMantenimientoCalculado";
            this.ProxMantenimientoCalculado.Size = new System.Drawing.Size(214, 20);
            this.ProxMantenimientoCalculado.TabIndex = 15;
            // 
            // cboTipoDocumento
            // 
            this.cboTipoDocumento.FormattingEnabled = true;
            this.cboTipoDocumento.Location = new System.Drawing.Point(677, 273);
            this.cboTipoDocumento.Margin = new System.Windows.Forms.Padding(2);
            this.cboTipoDocumento.Name = "cboTipoDocumento";
            this.cboTipoDocumento.Size = new System.Drawing.Size(138, 21);
            this.cboTipoDocumento.TabIndex = 16;
            // 
            // dtgvDocumentos
            // 
            this.dtgvDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvDocumentos.Location = new System.Drawing.Point(448, 273);
            this.dtgvDocumentos.Margin = new System.Windows.Forms.Padding(2);
            this.dtgvDocumentos.Name = "dtgvDocumentos";
            this.dtgvDocumentos.RowTemplate.Height = 24;
            this.dtgvDocumentos.Size = new System.Drawing.Size(214, 122);
            this.dtgvDocumentos.TabIndex = 17;
            // 
            // cboSede
            // 
            this.cboSede.FormattingEnabled = true;
            this.cboSede.Location = new System.Drawing.Point(476, 136);
            this.cboSede.Margin = new System.Windows.Forms.Padding(2);
            this.cboSede.Name = "cboSede";
            this.cboSede.Size = new System.Drawing.Size(186, 21);
            this.cboSede.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Cod. Unico";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Nro.Serie";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Nro Interno";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Ubicación";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Marca";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 251);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Año de Fabricación";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(667, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Estado";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(667, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Tipo";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(667, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Capacidad";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(667, 144);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "Sede";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(673, 178);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(162, 13);
            this.label12.TabIndex = 30;
            this.label12.Text = "Fecha de ejercución del Servicio";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(667, 207);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(103, 13);
            this.label13.TabIndex = 31;
            this.label13.Text = "Prox. Mantenimiento";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(667, 229);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(133, 13);
            this.label14.TabIndex = 32;
            this.label14.Text = "Fecha Prueba Hidrostatica";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(667, 249);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(176, 13);
            this.label15.TabIndex = 33;
            this.label15.Text = "Vencimiento de Prueba Hidrostatica";
            // 
            // cboMarca
            // 
            this.cboMarca.FormattingEnabled = true;
            this.cboMarca.Location = new System.Drawing.Point(36, 223);
            this.cboMarca.Margin = new System.Windows.Forms.Padding(2);
            this.cboMarca.Name = "cboMarca";
            this.cboMarca.Size = new System.Drawing.Size(182, 21);
            this.cboMarca.TabIndex = 34;
            // 
            // txtNroCertificado
            // 
            this.txtNroCertificado.Location = new System.Drawing.Point(677, 331);
            this.txtNroCertificado.Name = "txtNroCertificado";
            this.txtNroCertificado.Size = new System.Drawing.Size(137, 20);
            this.txtNroCertificado.TabIndex = 35;
            // 
            // btnQuitarDocumento
            // 
            this.btnQuitarDocumento.Location = new System.Drawing.Point(341, 331);
            this.btnQuitarDocumento.Name = "btnQuitarDocumento";
            this.btnQuitarDocumento.Size = new System.Drawing.Size(88, 23);
            this.btnQuitarDocumento.TabIndex = 37;
            this.btnQuitarDocumento.Text = "Quitar Doc.";
            this.btnQuitarDocumento.UseVisualStyleBackColor = true;
            // 
            // btnAgregarDocumento
            // 
            this.btnAgregarDocumento.Location = new System.Drawing.Point(341, 302);
            this.btnAgregarDocumento.Name = "btnAgregarDocumento";
            this.btnAgregarDocumento.Size = new System.Drawing.Size(89, 23);
            this.btnAgregarDocumento.TabIndex = 38;
            this.btnAgregarDocumento.Text = "Agregar Doc.";
            this.btnAgregarDocumento.UseVisualStyleBackColor = true;
            // 
            // btnExaminar
            // 
            this.btnExaminar.Location = new System.Drawing.Point(354, 273);
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.Size = new System.Drawing.Size(75, 23);
            this.btnExaminar.TabIndex = 39;
            this.btnExaminar.Text = "Examinar";
            this.btnExaminar.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(668, 312);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "N° de certificado";
            // 
            // P_DetalleExtintor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 508);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnExaminar);
            this.Controls.Add(this.btnAgregarDocumento);
            this.Controls.Add(this.btnQuitarDocumento);
            this.Controls.Add(this.txtNroCertificado);
            this.Controls.Add(this.cboMarca);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboSede);
            this.Controls.Add(this.dtgvDocumentos);
            this.Controls.Add(this.cboTipoDocumento);
            this.Controls.Add(this.ProxMantenimientoCalculado);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.dtpFechaServicio);
            this.Controls.Add(this.dtpFechaPruebaHidro);
            this.Controls.Add(this.cboTipoExtintor);
            this.Controls.Add(this.cboCapacidad);
            this.Controls.Add(this.txtRutaArchivoSeleccionado);
            this.Controls.Add(this.VencimientoPHCalculado);
            this.Controls.Add(this.txtAnioFabricacion);
            this.Controls.Add(this.txtUbicacion);
            this.Controls.Add(this.txtNroInterno);
            this.Controls.Add(this.txtNroSerie);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtCodigoU);
            this.Controls.Add(this.cboEstado);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "P_DetalleExtintor";
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDocumentos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.TextBox txtCodigoU;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtNroSerie;
        private System.Windows.Forms.TextBox txtNroInterno;
        private System.Windows.Forms.TextBox txtUbicacion;
        private System.Windows.Forms.TextBox txtAnioFabricacion;
        private System.Windows.Forms.TextBox VencimientoPHCalculado;
        private System.Windows.Forms.TextBox txtRutaArchivoSeleccionado;
        private System.Windows.Forms.ComboBox cboCapacidad;
        private System.Windows.Forms.ComboBox cboTipoExtintor;
        private System.Windows.Forms.DateTimePicker dtpFechaPruebaHidro;
        private System.Windows.Forms.DateTimePicker dtpFechaServicio;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox ProxMantenimientoCalculado;
        private System.Windows.Forms.ComboBox cboTipoDocumento;
        private System.Windows.Forms.DataGridView dtgvDocumentos;
        private System.Windows.Forms.ComboBox cboSede;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cboMarca;
        private System.Windows.Forms.TextBox txtNroCertificado;
        private System.Windows.Forms.Button btnQuitarDocumento;
        private System.Windows.Forms.Button btnAgregarDocumento;
        private System.Windows.Forms.Button btnExaminar;
        private System.Windows.Forms.Label label5;
    }
}