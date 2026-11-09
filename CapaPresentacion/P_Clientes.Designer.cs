namespace CapaPresentacion
{
    partial class P_Clientes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.dtgv_Clientes = new System.Windows.Forms.DataGridView();
            this.Documentacion = new System.Windows.Forms.DataGridViewLinkColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nro_serie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nro_interno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sede = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.capacidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anio_fabricacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eje_servicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proximo_mantenimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_prueba_hidrostatica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_Cliente = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_Clientes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(1, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 48);
            this.label1.TabIndex = 12;
            this.label1.Text = "Clientes";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.DarkRed;
            this.panel1.Location = new System.Drawing.Point(-1, 60);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1127, 1);
            this.panel1.TabIndex = 11;
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.OrangeRed;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnBuscar.Location = new System.Drawing.Point(817, 103);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(243, 34);
            this.btnBuscar.TabIndex = 10;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(35, 108);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(749, 27);
            this.txtBuscar.TabIndex = 9;
            this.txtBuscar.Text = "Buscar";
            this.txtBuscar.Click += new System.EventHandler(this.txtBuscar_Click);
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            this.txtBuscar.Enter += new System.EventHandler(this.txtBuscar_Enter);
            this.txtBuscar.Leave += new System.EventHandler(this.txtBuscar_Leave);
            // 
            // dtgv_Clientes
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgv_Clientes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dtgv_Clientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgv_Clientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dtgv_Clientes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dtgv_Clientes.BackgroundColor = System.Drawing.Color.White;
            this.dtgv_Clientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgv_Clientes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dtgv_Clientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.OrangeRed;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgv_Clientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dtgv_Clientes.ColumnHeadersHeight = 25;
            this.dtgv_Clientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nro_serie,
            this.nro_interno,
            this.sede,
            this.tipo,
            this.capacidad,
            this.marca,
            this.anio_fabricacion,
            this.eje_servicio,
            this.proximo_mantenimiento,
            this.telefono,
            this.fecha_prueba_hidrostatica});
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgv_Clientes.DefaultCellStyle = dataGridViewCellStyle16;
            this.dtgv_Clientes.EnableHeadersVisualStyles = false;
            this.dtgv_Clientes.Location = new System.Drawing.Point(35, 183);
            this.dtgv_Clientes.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dtgv_Clientes.Name = "dtgv_Clientes";
            this.dtgv_Clientes.RowHeadersWidth = 51;
            this.dtgv_Clientes.Size = new System.Drawing.Size(1055, 439);
            this.dtgv_Clientes.StandardTab = true;
            this.dtgv_Clientes.TabIndex = 8;
            this.dtgv_Clientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_Clientes_CellContentClick);
            this.dtgv_Clientes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_Clientes_CellDoubleClick);
            // 
            // Documentacion
            // 
            this.Documentacion.MinimumWidth = 6;
            this.Documentacion.Name = "Documentacion";
            this.Documentacion.Width = 125;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.Red;
            this.id.DefaultCellStyle = dataGridViewCellStyle15;
            this.id.HeaderText = "ID";
            this.id.MinimumWidth = 9;
            this.id.Name = "id";
            this.id.Width = 50;
            // 
            // nro_serie
            // 
            this.nro_serie.DataPropertyName = "codigo_cliente";
            this.nro_serie.HeaderText = "Código";
            this.nro_serie.MinimumWidth = 6;
            this.nro_serie.Name = "nro_serie";
            this.nro_serie.Width = 85;
            // 
            // nro_interno
            // 
            this.nro_interno.DataPropertyName = "razon_social";
            this.nro_interno.HeaderText = "Razón Social";
            this.nro_interno.MinimumWidth = 6;
            this.nro_interno.Name = "nro_interno";
            this.nro_interno.Width = 130;
            // 
            // sede
            // 
            this.sede.DataPropertyName = "nombre_comercial";
            this.sede.HeaderText = "Nombre Comercial";
            this.sede.MinimumWidth = 6;
            this.sede.Name = "sede";
            this.sede.Width = 167;
            // 
            // tipo
            // 
            this.tipo.DataPropertyName = "ruc";
            this.tipo.HeaderText = "RUC";
            this.tipo.MinimumWidth = 6;
            this.tipo.Name = "tipo";
            this.tipo.Width = 67;
            // 
            // capacidad
            // 
            this.capacidad.DataPropertyName = "direccion";
            this.capacidad.HeaderText = "Dirección";
            this.capacidad.MinimumWidth = 6;
            this.capacidad.Name = "capacidad";
            this.capacidad.Width = 103;
            // 
            // marca
            // 
            this.marca.DataPropertyName = "provincia";
            this.marca.HeaderText = "Provincia";
            this.marca.MinimumWidth = 6;
            this.marca.Name = "marca";
            this.marca.Width = 102;
            // 
            // anio_fabricacion
            // 
            this.anio_fabricacion.DataPropertyName = "contacto";
            this.anio_fabricacion.HeaderText = "Contacto";
            this.anio_fabricacion.MinimumWidth = 6;
            this.anio_fabricacion.Name = "anio_fabricacion";
            this.anio_fabricacion.Width = 99;
            // 
            // eje_servicio
            // 
            this.eje_servicio.DataPropertyName = "cargo";
            this.eje_servicio.HeaderText = "Cargo";
            this.eje_servicio.MinimumWidth = 6;
            this.eje_servicio.Name = "eje_servicio";
            this.eje_servicio.Width = 78;
            // 
            // proximo_mantenimiento
            // 
            this.proximo_mantenimiento.DataPropertyName = "correo";
            this.proximo_mantenimiento.HeaderText = "Correo";
            this.proximo_mantenimiento.MinimumWidth = 6;
            this.proximo_mantenimiento.Name = "proximo_mantenimiento";
            this.proximo_mantenimiento.Width = 84;
            // 
            // telefono
            // 
            this.telefono.DataPropertyName = "telefono";
            this.telefono.HeaderText = "Teléfono";
            this.telefono.MinimumWidth = 6;
            this.telefono.Name = "telefono";
            this.telefono.Width = 99;
            // 
            // fecha_prueba_hidrostatica
            // 
            this.fecha_prueba_hidrostatica.DataPropertyName = "estado";
            this.fecha_prueba_hidrostatica.HeaderText = "Estado";
            this.fecha_prueba_hidrostatica.MinimumWidth = 6;
            this.fecha_prueba_hidrostatica.Name = "fecha_prueba_hidrostatica";
            this.fecha_prueba_hidrostatica.Width = 85;
            // 
            // lbl_Cliente
            // 
            this.lbl_Cliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Cliente.AutoSize = true;
            this.lbl_Cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Cliente.Location = new System.Drawing.Point(947, 32);
            this.lbl_Cliente.Name = "lbl_Cliente";
            this.lbl_Cliente.Size = new System.Drawing.Size(23, 18);
            this.lbl_Cliente.TabIndex = 13;
            this.lbl_Cliente.Text = "...";
            // 
            // P_Clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 672);
            this.Controls.Add(this.lbl_Cliente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.dtgv_Clientes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "P_Clientes";
            this.Text = "P_Clientes";
            this.Load += new System.EventHandler(this.P_Clientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_Clientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        public System.Windows.Forms.DataGridView dtgv_Clientes;
        private System.Windows.Forms.DataGridViewLinkColumn Documentacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nro_serie;
        private System.Windows.Forms.DataGridViewTextBoxColumn nro_interno;
        private System.Windows.Forms.DataGridViewTextBoxColumn sede;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn capacidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn anio_fabricacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn eje_servicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn proximo_mantenimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_prueba_hidrostatica;
        private System.Windows.Forms.Label lbl_Cliente;
    }
}