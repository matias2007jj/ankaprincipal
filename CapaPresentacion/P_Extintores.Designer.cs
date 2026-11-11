namespace CapaPresentacion
{
    partial class P_Extintores
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P_Extintores));
            this.dtgv_Extintores = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nro_serie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nro_interno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sede = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ubicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.capacidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anio_fabricacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eje_servicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proximo_mantenimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_prueba_hidrostatica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vencimiento_ph = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.QR = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_Extintores = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btn_ImportarExcel = new System.Windows.Forms.Button();
            this.btn_ExportarExcel = new System.Windows.Forms.Button();
            this.lbl_Cliente = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_Extintores)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgv_Extintores
            // 
            this.dtgv_Extintores.AllowUserToAddRows = false;
            this.dtgv_Extintores.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgv_Extintores.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgv_Extintores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgv_Extintores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgv_Extintores.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dtgv_Extintores.BackgroundColor = System.Drawing.Color.White;
            this.dtgv_Extintores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgv_Extintores.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dtgv_Extintores.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.OrangeRed;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgv_Extintores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgv_Extintores.ColumnHeadersHeight = 25;
            this.dtgv_Extintores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nro_serie,
            this.nro_interno,
            this.sede,
            this.ubicacion,
            this.tipo,
            this.capacidad,
            this.marca,
            this.anio_fabricacion,
            this.eje_servicio,
            this.proximo_mantenimiento,
            this.fecha_prueba_hidrostatica,
            this.vencimiento_ph,
            this.estado,
            this.Editar,
            this.Eliminar,
            this.QR});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgv_Extintores.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtgv_Extintores.EnableHeadersVisualStyles = false;
            this.dtgv_Extintores.Location = new System.Drawing.Point(28, 210);
            this.dtgv_Extintores.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtgv_Extintores.Name = "dtgv_Extintores";
            this.dtgv_Extintores.ReadOnly = true;
            this.dtgv_Extintores.RowHeadersVisible = false;
            this.dtgv_Extintores.RowHeadersWidth = 51;
            this.dtgv_Extintores.Size = new System.Drawing.Size(1083, 438);
            this.dtgv_Extintores.StandardTab = true;
            this.dtgv_Extintores.TabIndex = 0;
            // 
            // id
            // 
            this.id.DataPropertyName = "codigo_u";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Red;
            this.id.DefaultCellStyle = dataGridViewCellStyle3;
            this.id.HeaderText = "Codigo.U";
            this.id.MinimumWidth = 9;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 101;
            // 
            // nro_serie
            // 
            this.nro_serie.DataPropertyName = "nro_serie";
            this.nro_serie.HeaderText = "Nº Serie";
            this.nro_serie.MinimumWidth = 6;
            this.nro_serie.Name = "nro_serie";
            this.nro_serie.ReadOnly = true;
            this.nro_serie.Width = 95;
            // 
            // nro_interno
            // 
            this.nro_interno.DataPropertyName = "nro_interno";
            this.nro_interno.HeaderText = "Nº Interno";
            this.nro_interno.MinimumWidth = 6;
            this.nro_interno.Name = "nro_interno";
            this.nro_interno.ReadOnly = true;
            this.nro_interno.Width = 108;
            // 
            // sede
            // 
            this.sede.DataPropertyName = "sede";
            this.sede.HeaderText = "Sede";
            this.sede.MinimumWidth = 6;
            this.sede.Name = "sede";
            this.sede.ReadOnly = true;
            this.sede.Width = 72;
            // 
            // ubicacion
            // 
            this.ubicacion.DataPropertyName = "ubicacion";
            this.ubicacion.HeaderText = "Ubicacion";
            this.ubicacion.MinimumWidth = 6;
            this.ubicacion.Name = "ubicacion";
            this.ubicacion.ReadOnly = true;
            this.ubicacion.Width = 106;
            // 
            // tipo
            // 
            this.tipo.DataPropertyName = "tipo";
            this.tipo.HeaderText = "Tipo";
            this.tipo.MinimumWidth = 6;
            this.tipo.Name = "tipo";
            this.tipo.ReadOnly = true;
            this.tipo.Width = 67;
            // 
            // capacidad
            // 
            this.capacidad.DataPropertyName = "capacidad";
            this.capacidad.HeaderText = "Capacidad";
            this.capacidad.MinimumWidth = 6;
            this.capacidad.Name = "capacidad";
            this.capacidad.ReadOnly = true;
            this.capacidad.Width = 111;
            // 
            // marca
            // 
            this.marca.DataPropertyName = "marca";
            this.marca.HeaderText = "Marca";
            this.marca.MinimumWidth = 6;
            this.marca.Name = "marca";
            this.marca.ReadOnly = true;
            this.marca.Width = 79;
            // 
            // anio_fabricacion
            // 
            this.anio_fabricacion.DataPropertyName = "anio_fabricacion";
            this.anio_fabricacion.HeaderText = "Año Fabricacion";
            this.anio_fabricacion.MinimumWidth = 6;
            this.anio_fabricacion.Name = "anio_fabricacion";
            this.anio_fabricacion.ReadOnly = true;
            this.anio_fabricacion.Width = 152;
            // 
            // eje_servicio
            // 
            this.eje_servicio.DataPropertyName = "eje_servicio";
            this.eje_servicio.HeaderText = "Eje. Del Servicio";
            this.eje_servicio.MinimumWidth = 6;
            this.eje_servicio.Name = "eje_servicio";
            this.eje_servicio.ReadOnly = true;
            this.eje_servicio.Width = 155;
            // 
            // proximo_mantenimiento
            // 
            this.proximo_mantenimiento.DataPropertyName = "proximo_mantenimiento";
            this.proximo_mantenimiento.HeaderText = "Prox. Mantenimiento";
            this.proximo_mantenimiento.MinimumWidth = 6;
            this.proximo_mantenimiento.Name = "proximo_mantenimiento";
            this.proximo_mantenimiento.ReadOnly = true;
            this.proximo_mantenimiento.Width = 182;
            // 
            // fecha_prueba_hidrostatica
            // 
            this.fecha_prueba_hidrostatica.DataPropertyName = "fecha_prueba_hidrostatica";
            this.fecha_prueba_hidrostatica.HeaderText = "Fecha Prueba H.";
            this.fecha_prueba_hidrostatica.MinimumWidth = 6;
            this.fecha_prueba_hidrostatica.Name = "fecha_prueba_hidrostatica";
            this.fecha_prueba_hidrostatica.ReadOnly = true;
            this.fecha_prueba_hidrostatica.Width = 157;
            // 
            // vencimiento_ph
            // 
            this.vencimiento_ph.DataPropertyName = "vencimiento_ph";
            this.vencimiento_ph.HeaderText = "Venc. Prueba H.";
            this.vencimiento_ph.MinimumWidth = 6;
            this.vencimiento_ph.Name = "vencimiento_ph";
            this.vencimiento_ph.ReadOnly = true;
            this.vencimiento_ph.Width = 154;
            // 
            // estado
            // 
            this.estado.DataPropertyName = "estado";
            this.estado.HeaderText = "Estado";
            this.estado.MinimumWidth = 6;
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            this.estado.Width = 85;
            // 
            // Editar
            // 
            this.Editar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Editar.DefaultCellStyle = dataGridViewCellStyle4;
            this.Editar.HeaderText = "           ";
            this.Editar.MinimumWidth = 6;
            this.Editar.Name = "Editar";
            this.Editar.ReadOnly = true;
            this.Editar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Editar.Text = "editar";
            this.Editar.UseColumnTextForButtonValue = true;
            this.Editar.Width = 67;
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "ACCIONES";
            this.Eliminar.MinimumWidth = 6;
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.ReadOnly = true;
            this.Eliminar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Eliminar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Eliminar.Text = "Eliminar";
            this.Eliminar.UseColumnTextForButtonValue = true;
            this.Eliminar.Width = 112;
            // 
            // QR
            // 
            this.QR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.QR.HeaderText = " ";
            this.QR.MinimumWidth = 6;
            this.QR.Name = "QR";
            this.QR.ReadOnly = true;
            this.QR.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.QR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.QR.Text = "QR";
            this.QR.UseColumnTextForButtonValue = true;
            this.QR.Width = 40;
            // 
            // txtBuscar
            // 
            this.txtBuscar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(28, 84);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(504, 27);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.Text = "Buscar por NºSerie, Codigo.U, Marca, Sede o Tipo";
            this.txtBuscar.Click += new System.EventHandler(this.txtBuscar_Click);
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            this.txtBuscar.Enter += new System.EventHandler(this.txtBuscar_Enter);
            this.txtBuscar.Leave += new System.EventHandler(this.txtBuscar_Leave);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.OrangeRed;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnBuscar.Location = new System.Drawing.Point(552, 80);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(182, 35);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.DarkRed;
            this.panel1.Location = new System.Drawing.Point(1, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1126, 1);
            this.panel1.TabIndex = 3;
            // 
            // lbl_Extintores
            // 
            this.lbl_Extintores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Extintores.AutoSize = true;
            this.lbl_Extintores.Location = new System.Drawing.Point(969, 18);
            this.lbl_Extintores.Name = "lbl_Extintores";
            this.lbl_Extintores.Size = new System.Drawing.Size(23, 17);
            this.lbl_Extintores.TabIndex = 6;
            this.lbl_Extintores.Text = "...";
            this.lbl_Extintores.Click += new System.EventHandler(this.lbl_Extintores_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(28, 149);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(106, 42);
            this.btnAgregar.TabIndex = 7;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btn_ImportarExcel
            // 
            this.btn_ImportarExcel.Image = ((System.Drawing.Image)(resources.GetObject("btn_ImportarExcel.Image")));
            this.btn_ImportarExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ImportarExcel.Location = new System.Drawing.Point(322, 149);
            this.btn_ImportarExcel.Name = "btn_ImportarExcel";
            this.btn_ImportarExcel.Size = new System.Drawing.Size(116, 42);
            this.btn_ImportarExcel.TabIndex = 8;
            this.btn_ImportarExcel.Text = "Importar";
            this.btn_ImportarExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_ImportarExcel.UseVisualStyleBackColor = true;
            this.btn_ImportarExcel.Click += new System.EventHandler(this.btn_ImportarExcel_Click);
            // 
            // btn_ExportarExcel
            // 
            this.btn_ExportarExcel.Image = ((System.Drawing.Image)(resources.GetObject("btn_ExportarExcel.Image")));
            this.btn_ExportarExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ExportarExcel.Location = new System.Drawing.Point(166, 149);
            this.btn_ExportarExcel.Name = "btn_ExportarExcel";
            this.btn_ExportarExcel.Size = new System.Drawing.Size(115, 42);
            this.btn_ExportarExcel.TabIndex = 9;
            this.btn_ExportarExcel.Text = "Exportar";
            this.btn_ExportarExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_ExportarExcel.UseVisualStyleBackColor = true;
            this.btn_ExportarExcel.Click += new System.EventHandler(this.btn_ExportarExcel_Click);
            // 
            // lbl_Cliente
            // 
            this.lbl_Cliente.AutoSize = true;
            this.lbl_Cliente.Font = new System.Drawing.Font("Microsoft YaHei UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Cliente.ForeColor = System.Drawing.Color.OrangeRed;
            this.lbl_Cliente.Location = new System.Drawing.Point(6, 6);
            this.lbl_Cliente.Name = "lbl_Cliente";
            this.lbl_Cliente.Size = new System.Drawing.Size(43, 43);
            this.lbl_Cliente.TabIndex = 10;
            this.lbl_Cliente.Text = "...";
            // 
            // P_Extintores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1124, 672);
            this.Controls.Add(this.lbl_Cliente);
            this.Controls.Add(this.btn_ExportarExcel);
            this.Controls.Add(this.btn_ImportarExcel);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.lbl_Extintores);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.dtgv_Extintores);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "P_Extintores";
            this.Text = " ";
            this.Load += new System.EventHandler(this.P_Extintores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_Extintores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_Extintores;
        private System.Windows.Forms.Button btnAgregar;
        public System.Windows.Forms.DataGridView dtgv_Extintores;
        private System.Windows.Forms.Button btn_ImportarExcel;
        private System.Windows.Forms.Button btn_ExportarExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nro_serie;
        private System.Windows.Forms.DataGridViewTextBoxColumn nro_interno;
        private System.Windows.Forms.DataGridViewTextBoxColumn sede;
        private System.Windows.Forms.DataGridViewTextBoxColumn ubicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn capacidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn anio_fabricacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn eje_servicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn proximo_mantenimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_prueba_hidrostatica;
        private System.Windows.Forms.DataGridViewTextBoxColumn vencimiento_ph;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.DataGridViewButtonColumn Editar;
        private System.Windows.Forms.DataGridViewButtonColumn Eliminar;
        private System.Windows.Forms.DataGridViewButtonColumn QR;
        private System.Windows.Forms.Label lbl_Cliente;
    }
}