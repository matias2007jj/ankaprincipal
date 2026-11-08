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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.dtgv_Clientes = new System.Windows.Forms.DataGridView();
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
            this.Editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.QR = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Documentacion = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_Clientes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.Location = new System.Drawing.Point(742, 515);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 14;
            this.btnAgregar.Text = "AGREGAR";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(1, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 38);
            this.label1.TabIndex = 12;
            this.label1.Text = "Clientes";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.DarkRed;
            this.panel1.Location = new System.Drawing.Point(-1, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(845, 1);
            this.panel1.TabIndex = 11;
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.OrangeRed;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnBuscar.Location = new System.Drawing.Point(613, 84);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(182, 28);
            this.btnBuscar.TabIndex = 10;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // txtBuscar
            // 
            this.txtBuscar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(26, 88);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(562, 22);
            this.txtBuscar.TabIndex = 9;
            this.txtBuscar.Text = "Buscar";
            this.txtBuscar.Click += new System.EventHandler(this.txtBuscar_Click);
            // 
            // dtgv_Clientes
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgv_Clientes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgv_Clientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgv_Clientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dtgv_Clientes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dtgv_Clientes.BackgroundColor = System.Drawing.Color.White;
            this.dtgv_Clientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgv_Clientes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dtgv_Clientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.OrangeRed;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgv_Clientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
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
            this.fecha_prueba_hidrostatica,
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
            this.dtgv_Clientes.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtgv_Clientes.EnableHeadersVisualStyles = false;
            this.dtgv_Clientes.Location = new System.Drawing.Point(26, 149);
            this.dtgv_Clientes.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtgv_Clientes.Name = "dtgv_Clientes";
            this.dtgv_Clientes.Size = new System.Drawing.Size(791, 357);
            this.dtgv_Clientes.StandardTab = true;
            this.dtgv_Clientes.TabIndex = 8;
            this.dtgv_Clientes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_Clientes_CellDoubleClick);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Red;
            this.id.DefaultCellStyle = dataGridViewCellStyle3;
            this.id.HeaderText = "ID";
            this.id.MinimumWidth = 9;
            this.id.Name = "id";
            this.id.Width = 43;
            // 
            // nro_serie
            // 
            this.nro_serie.DataPropertyName = "codigo_cliente";
            this.nro_serie.HeaderText = "Código";
            this.nro_serie.Name = "nro_serie";
            this.nro_serie.Width = 69;
            // 
            // nro_interno
            // 
            this.nro_interno.DataPropertyName = "razon_social";
            this.nro_interno.HeaderText = "Razón Social";
            this.nro_interno.Name = "nro_interno";
            this.nro_interno.Width = 105;
            // 
            // sede
            // 
            this.sede.DataPropertyName = "nombre_comercial";
            this.sede.HeaderText = "Nombre Comercial";
            this.sede.Name = "sede";
            this.sede.Width = 132;
            // 
            // tipo
            // 
            this.tipo.DataPropertyName = "ruc";
            this.tipo.HeaderText = "RUC";
            this.tipo.Name = "tipo";
            this.tipo.Width = 56;
            // 
            // capacidad
            // 
            this.capacidad.DataPropertyName = "direccion";
            this.capacidad.HeaderText = "Dirección";
            this.capacidad.Name = "capacidad";
            this.capacidad.Width = 84;
            // 
            // marca
            // 
            this.marca.DataPropertyName = "provincia";
            this.marca.HeaderText = "Provincia";
            this.marca.Name = "marca";
            this.marca.Width = 83;
            // 
            // anio_fabricacion
            // 
            this.anio_fabricacion.DataPropertyName = "contacto";
            this.anio_fabricacion.HeaderText = "Contacto";
            this.anio_fabricacion.Name = "anio_fabricacion";
            this.anio_fabricacion.Width = 81;
            // 
            // eje_servicio
            // 
            this.eje_servicio.DataPropertyName = "cargo";
            this.eje_servicio.HeaderText = "Cargo";
            this.eje_servicio.Name = "eje_servicio";
            this.eje_servicio.Width = 63;
            // 
            // proximo_mantenimiento
            // 
            this.proximo_mantenimiento.DataPropertyName = "correo";
            this.proximo_mantenimiento.HeaderText = "Correo";
            this.proximo_mantenimiento.Name = "proximo_mantenimiento";
            this.proximo_mantenimiento.Width = 67;
            // 
            // telefono
            // 
            this.telefono.DataPropertyName = "telefono";
            this.telefono.HeaderText = "Teléfono";
            this.telefono.Name = "telefono";
            this.telefono.Width = 80;
            // 
            // fecha_prueba_hidrostatica
            // 
            this.fecha_prueba_hidrostatica.DataPropertyName = "estado";
            this.fecha_prueba_hidrostatica.HeaderText = "Estado";
            this.fecha_prueba_hidrostatica.Name = "fecha_prueba_hidrostatica";
            this.fecha_prueba_hidrostatica.Width = 69;
            // 
            // Editar
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Editar.DefaultCellStyle = dataGridViewCellStyle4;
            this.Editar.HeaderText = "           ";
            this.Editar.Name = "Editar";
            this.Editar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Editar.Text = "editar";
            this.Editar.UseColumnTextForButtonValue = true;
            this.Editar.Width = 55;
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "ACCIONES";
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Eliminar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Eliminar.Text = "Eliminar";
            this.Eliminar.UseColumnTextForButtonValue = true;
            this.Eliminar.Width = 92;
            // 
            // QR
            // 
            this.QR.HeaderText = " ";
            this.QR.Name = "QR";
            this.QR.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.QR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.QR.Text = "QR";
            this.QR.UseColumnTextForButtonValue = true;
            this.QR.Width = 34;
            // 
            // Documentacion
            // 
            this.Documentacion.Name = "Documentacion";
            // 
            // P_Clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 546);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.dtgv_Clientes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "P_Clientes";
            this.Text = "P_Clientes";
            this.Load += new System.EventHandler(this.P_Clientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_Clientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        public System.Windows.Forms.DataGridView dtgv_Clientes;
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
        private System.Windows.Forms.DataGridViewLinkColumn Documentacion;
        private System.Windows.Forms.DataGridViewButtonColumn Editar;
        private System.Windows.Forms.DataGridViewButtonColumn Eliminar;
        private System.Windows.Forms.DataGridViewButtonColumn QR;
    }
}