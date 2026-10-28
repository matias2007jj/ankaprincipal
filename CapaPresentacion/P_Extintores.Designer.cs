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
            this.dtgv_Extintores = new System.Windows.Forms.DataGridView();
            this.Cod_U = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Num_Serie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.N_Interno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sede = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Capacidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AñoFabricacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Eje_ultimoS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prox_Mantenimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F_PruebaH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Venci_PruebaH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Documentacion = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.QR = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_Extintores)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgv_Extintores
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgv_Extintores.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgv_Extintores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgv_Extintores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
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
            this.Cod_U,
            this.Num_Serie,
            this.N_Interno,
            this.Sede,
            this.Tipo,
            this.Capacidad,
            this.Marca,
            this.AñoFabricacion,
            this.Eje_ultimoS,
            this.Prox_Mantenimiento,
            this.F_PruebaH,
            this.Venci_PruebaH,
            this.Estado,
            this.Documentacion,
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
            this.dtgv_Extintores.Location = new System.Drawing.Point(28, 145);
            this.dtgv_Extintores.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtgv_Extintores.Name = "dtgv_Extintores";
            this.dtgv_Extintores.Size = new System.Drawing.Size(791, 357);
            this.dtgv_Extintores.StandardTab = true;
            this.dtgv_Extintores.TabIndex = 0;
            // 
            // Cod_U
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Red;
            this.Cod_U.DefaultCellStyle = dataGridViewCellStyle3;
            this.Cod_U.HeaderText = "Codigo.U";
            this.Cod_U.Name = "Cod_U";
            this.Cod_U.Width = 82;
            // 
            // Num_Serie
            // 
            this.Num_Serie.HeaderText = "Nº Serie";
            this.Num_Serie.Name = "Num_Serie";
            this.Num_Serie.Width = 77;
            // 
            // N_Interno
            // 
            this.N_Interno.HeaderText = "Nº Interno";
            this.N_Interno.Name = "N_Interno";
            this.N_Interno.Width = 88;
            // 
            // Sede
            // 
            this.Sede.HeaderText = "Sede";
            this.Sede.Name = "Sede";
            this.Sede.Width = 59;
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.Width = 55;
            // 
            // Capacidad
            // 
            this.Capacidad.HeaderText = "Capacidad";
            this.Capacidad.Name = "Capacidad";
            this.Capacidad.Width = 90;
            // 
            // Marca
            // 
            this.Marca.HeaderText = "Marca";
            this.Marca.Name = "Marca";
            this.Marca.Width = 65;
            // 
            // AñoFabricacion
            // 
            this.AñoFabricacion.HeaderText = "Año Fabricacion";
            this.AñoFabricacion.Name = "AñoFabricacion";
            this.AñoFabricacion.Width = 122;
            // 
            // Eje_ultimoS
            // 
            this.Eje_ultimoS.HeaderText = "Eje. Del Servicio";
            this.Eje_ultimoS.Name = "Eje_ultimoS";
            this.Eje_ultimoS.Width = 125;
            // 
            // Prox_Mantenimiento
            // 
            this.Prox_Mantenimiento.HeaderText = "Prox. Mantenimiento";
            this.Prox_Mantenimiento.Name = "Prox_Mantenimiento";
            this.Prox_Mantenimiento.Width = 145;
            // 
            // F_PruebaH
            // 
            this.F_PruebaH.HeaderText = "Fecha Prueba H.";
            this.F_PruebaH.Name = "F_PruebaH";
            this.F_PruebaH.Width = 126;
            // 
            // Venci_PruebaH
            // 
            this.Venci_PruebaH.HeaderText = "Venc. Prueba H.";
            this.Venci_PruebaH.Name = "Venci_PruebaH";
            this.Venci_PruebaH.Width = 124;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.Width = 69;
            // 
            // Documentacion
            // 
            this.Documentacion.HeaderText = "Documentacion";
            this.Documentacion.Name = "Documentacion";
            this.Documentacion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Documentacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Documentacion.Width = 118;
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
            // txtBuscar
            // 
            this.txtBuscar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(28, 84);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(562, 22);
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
            this.btnBuscar.Location = new System.Drawing.Point(615, 80);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(182, 28);
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
            this.panel1.Size = new System.Drawing.Size(845, 1);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 38);
            this.label1.TabIndex = 4;
            this.label1.Text = "Extintores";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(778, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.Location = new System.Drawing.Point(744, 511);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 7;
            this.btnAgregar.Text = "AGREGAR";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // P_Extintores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(843, 546);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.dtgv_Extintores);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "P_Extintores";
            this.Text = "P_Extintores";
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_Extintores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dtgv_Extintores;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cod_U;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num_Serie;
        private System.Windows.Forms.DataGridViewTextBoxColumn N_Interno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sede;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Capacidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn AñoFabricacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Eje_ultimoS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prox_Mantenimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn F_PruebaH;
        private System.Windows.Forms.DataGridViewTextBoxColumn Venci_PruebaH;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewLinkColumn Documentacion;
        private System.Windows.Forms.DataGridViewButtonColumn Editar;
        private System.Windows.Forms.DataGridViewButtonColumn Eliminar;
        private System.Windows.Forms.DataGridViewButtonColumn QR;
    }
}