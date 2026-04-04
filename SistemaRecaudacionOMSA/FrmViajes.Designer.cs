namespace SistemaRecaudacionOMSA
{
    partial class FrmViajes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmViajes));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpViaje = new System.Windows.Forms.TableLayoutPanel();
            this.lblChofer = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.cmbChofer = new System.Windows.Forms.ComboBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.cmbRuta = new System.Windows.Forms.ComboBox();
            this.lblRuta = new System.Windows.Forms.Label();
            this.lblVehiculo = new System.Windows.Forms.Label();
            this.cmbVehiculo = new System.Windows.Forms.ComboBox();
            this.flpAcciones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.dgvViajes = new System.Windows.Forms.DataGridView();
            this.flpToolbar = new System.Windows.Forms.FlowLayoutPanel();
            this.btnModoEdicion = new System.Windows.Forms.Button();
            this.btnVerTabla = new System.Windows.Forms.Button();
            this.tlpViaje.SuspendLayout();
            this.flpAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViajes)).BeginInit();
            this.flpToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpViaje
            // 
            this.tlpViaje.ColumnCount = 2;
            this.tlpViaje.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpViaje.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpViaje.Controls.Add(this.lblChofer, 0, 1);
            this.tlpViaje.Controls.Add(this.lblTitulo, 0, 0);
            this.tlpViaje.Controls.Add(this.cmbChofer, 0, 2);
            this.tlpViaje.Controls.Add(this.lblVehiculo, 0, 3);
            this.tlpViaje.Controls.Add(this.cmbVehiculo, 0, 4);
            this.tlpViaje.Controls.Add(this.lblRuta, 1, 1);
            this.tlpViaje.Controls.Add(this.lblFecha, 1, 3);
            this.tlpViaje.Controls.Add(this.dtpFecha, 1, 4);
            this.tlpViaje.Controls.Add(this.cmbRuta, 1, 2);
            this.tlpViaje.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpViaje.ForeColor = System.Drawing.Color.White;
            this.tlpViaje.Location = new System.Drawing.Point(30, 55);
            this.tlpViaje.Margin = new System.Windows.Forms.Padding(0);
            this.tlpViaje.Name = "tlpViaje";
            this.tlpViaje.Padding = new System.Windows.Forms.Padding(30);
            this.tlpViaje.RowCount = 6;
            this.tlpViaje.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpViaje.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpViaje.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpViaje.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpViaje.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpViaje.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpViaje.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpViaje.Size = new System.Drawing.Size(874, 275);
            this.tlpViaje.TabIndex = 0;
            this.tlpViaje.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // lblChofer
            // 
            this.lblChofer.AutoSize = true;
            this.lblChofer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblChofer.ForeColor = System.Drawing.Color.White;
            this.lblChofer.Location = new System.Drawing.Point(33, 73);
            this.lblChofer.Name = "lblChofer";
            this.lblChofer.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.lblChofer.Size = new System.Drawing.Size(109, 30);
            this.lblChofer.TabIndex = 1;
            this.lblChofer.Text = "Seleccionar Chofer:";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpViaje.SetColumnSpan(this.lblTitulo, 2);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitulo.Location = new System.Drawing.Point(33, 30);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(3, 0, 3, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(808, 23);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "DESPACHAR VIAJES";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbChofer
            // 
            this.cmbChofer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbChofer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChofer.Enabled = false;
            this.cmbChofer.FormattingEnabled = true;
            this.cmbChofer.Location = new System.Drawing.Point(33, 106);
            this.cmbChofer.Name = "cmbChofer";
            this.cmbChofer.Size = new System.Drawing.Size(401, 21);
            this.cmbChofer.TabIndex = 2;
            this.cmbChofer.SelectedIndexChanged += new System.EventHandler(this.VerificarSiHayCambios);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFecha.ForeColor = System.Drawing.Color.White;
            this.lblFecha.Location = new System.Drawing.Point(440, 130);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.lblFecha.Size = new System.Drawing.Size(88, 30);
            this.lblFecha.TabIndex = 3;
            this.lblFecha.Text = "Fecha del Viaje:";
            this.lblFecha.Click += new System.EventHandler(this.lblFecha_Click);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(440, 163);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(401, 20);
            this.dtpFecha.TabIndex = 4;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.VerificarSiHayCambios);
            // 
            // cmbRuta
            // 
            this.cmbRuta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRuta.Enabled = false;
            this.cmbRuta.FormattingEnabled = true;
            this.cmbRuta.Location = new System.Drawing.Point(440, 106);
            this.cmbRuta.Name = "cmbRuta";
            this.cmbRuta.Size = new System.Drawing.Size(401, 21);
            this.cmbRuta.TabIndex = 6;
            this.cmbRuta.SelectedIndexChanged += new System.EventHandler(this.VerificarSiHayCambios);
            // 
            // lblRuta
            // 
            this.lblRuta.AutoSize = true;
            this.lblRuta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRuta.ForeColor = System.Drawing.Color.White;
            this.lblRuta.Location = new System.Drawing.Point(440, 73);
            this.lblRuta.Name = "lblRuta";
            this.lblRuta.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.lblRuta.Size = new System.Drawing.Size(97, 30);
            this.lblRuta.TabIndex = 5;
            this.lblRuta.Text = "Seleccionar Ruta:";
            // 
            // lblVehiculo
            // 
            this.lblVehiculo.AutoSize = true;
            this.lblVehiculo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVehiculo.ForeColor = System.Drawing.Color.White;
            this.lblVehiculo.Location = new System.Drawing.Point(33, 130);
            this.lblVehiculo.Name = "lblVehiculo";
            this.lblVehiculo.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.lblVehiculo.Size = new System.Drawing.Size(118, 30);
            this.lblVehiculo.TabIndex = 7;
            this.lblVehiculo.Text = "Seleccionar Vehículo:";
            // 
            // cmbVehiculo
            // 
            this.cmbVehiculo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVehiculo.Enabled = false;
            this.cmbVehiculo.FormattingEnabled = true;
            this.cmbVehiculo.Location = new System.Drawing.Point(33, 163);
            this.cmbVehiculo.Name = "cmbVehiculo";
            this.cmbVehiculo.Size = new System.Drawing.Size(401, 21);
            this.cmbVehiculo.TabIndex = 8;
            this.cmbVehiculo.SelectedIndexChanged += new System.EventHandler(this.VerificarSiHayCambios);
            // 
            // flpAcciones
            // 
            this.flpAcciones.Controls.Add(this.btnGuardar);
            this.flpAcciones.Controls.Add(this.btnActualizar);
            this.flpAcciones.Controls.Add(this.btnCancelar);
            this.flpAcciones.Controls.Add(this.btnLimpiar);
            this.flpAcciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpAcciones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpAcciones.Location = new System.Drawing.Point(30, 330);
            this.flpAcciones.Name = "flpAcciones";
            this.flpAcciones.Padding = new System.Windows.Forms.Padding(0, 10, 30, 0);
            this.flpAcciones.Size = new System.Drawing.Size(874, 60);
            this.flpAcciones.TabIndex = 1;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(741, 13);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 32);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.Khaki;
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizar.Location = new System.Drawing.Point(620, 13);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(115, 32);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(511, 13);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(103, 32);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.Location = new System.Drawing.Point(410, 13);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(95, 32);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // dgvViajes
            // 
            this.dgvViajes.AllowUserToAddRows = false;
            this.dgvViajes.AllowUserToResizeColumns = false;
            this.dgvViajes.AllowUserToResizeRows = false;
            this.dgvViajes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvViajes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.dgvViajes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvViajes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvViajes.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvViajes.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvViajes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.dgvViajes.Location = new System.Drawing.Point(30, 390);
            this.dgvViajes.Margin = new System.Windows.Forms.Padding(0);
            this.dgvViajes.Name = "dgvViajes";
            this.dgvViajes.ReadOnly = true;
            this.dgvViajes.RowHeadersVisible = false;
            this.dgvViajes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvViajes.Size = new System.Drawing.Size(874, 312);
            this.dgvViajes.TabIndex = 2;
            this.dgvViajes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvViajes_CellClick);
            this.dgvViajes.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvViajes_CellFormatting);
            // 
            // flpToolbar
            // 
            this.flpToolbar.Controls.Add(this.btnModoEdicion);
            this.flpToolbar.Controls.Add(this.btnVerTabla);
            this.flpToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpToolbar.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpToolbar.Location = new System.Drawing.Point(30, 10);
            this.flpToolbar.Name = "flpToolbar";
            this.flpToolbar.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.flpToolbar.Size = new System.Drawing.Size(874, 45);
            this.flpToolbar.TabIndex = 3;
            // 
            // btnModoEdicion
            // 
            this.btnModoEdicion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModoEdicion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnModoEdicion.ForeColor = System.Drawing.Color.White;
            this.btnModoEdicion.Image = ((System.Drawing.Image)(resources.GetObject("btnModoEdicion.Image")));
            this.btnModoEdicion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModoEdicion.Location = new System.Drawing.Point(728, 3);
            this.btnModoEdicion.Name = "btnModoEdicion";
            this.btnModoEdicion.Size = new System.Drawing.Size(113, 36);
            this.btnModoEdicion.TabIndex = 0;
            this.btnModoEdicion.Text = "Editar";
            this.btnModoEdicion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModoEdicion.UseVisualStyleBackColor = true;
            this.btnModoEdicion.Click += new System.EventHandler(this.btnModoEdicion_Click);
            // 
            // btnVerTabla
            // 
            this.btnVerTabla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerTabla.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnVerTabla.ForeColor = System.Drawing.Color.White;
            this.btnVerTabla.Image = ((System.Drawing.Image)(resources.GetObject("btnVerTabla.Image")));
            this.btnVerTabla.Location = new System.Drawing.Point(606, 3);
            this.btnVerTabla.Name = "btnVerTabla";
            this.btnVerTabla.Size = new System.Drawing.Size(116, 36);
            this.btnVerTabla.TabIndex = 1;
            this.btnVerTabla.Text = "Ver Tabla";
            this.btnVerTabla.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVerTabla.UseVisualStyleBackColor = true;
            this.btnVerTabla.Click += new System.EventHandler(this.btnVerTabla_Click);
            // 
            // FrmViajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(934, 712);
            this.Controls.Add(this.dgvViajes);
            this.Controls.Add(this.flpAcciones);
            this.Controls.Add(this.tlpViaje);
            this.Controls.Add(this.flpToolbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmViajes";
            this.Padding = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.Text = "FrmRutas";
            this.Load += new System.EventHandler(this.FrmViajes_Load);
            this.tlpViaje.ResumeLayout(false);
            this.tlpViaje.PerformLayout();
            this.flpAcciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvViajes)).EndInit();
            this.flpToolbar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpViaje;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblChofer;
        private System.Windows.Forms.ComboBox cmbChofer;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblRuta;
        private System.Windows.Forms.ComboBox cmbRuta;
        private System.Windows.Forms.Label lblVehiculo;
        private System.Windows.Forms.ComboBox cmbVehiculo;
        private System.Windows.Forms.FlowLayoutPanel flpAcciones;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridView dgvViajes;
        private System.Windows.Forms.FlowLayoutPanel flpToolbar;
        private System.Windows.Forms.Button btnModoEdicion;
        private System.Windows.Forms.Button btnVerTabla;
    }
}