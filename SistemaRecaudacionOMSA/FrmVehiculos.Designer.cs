namespace SistemaRecaudacionOMSA
{
    partial class FrmVehiculos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVehiculos));
            this.dgvVehiculos = new System.Windows.Forms.DataGridView();
            this.flpAcciones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.tlpChoferes = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblPlaca = new System.Windows.Forms.Label();
            this.lblFicha = new System.Windows.Forms.Label();
            this.lblCapacidad = new System.Windows.Forms.Label();
            this.lblModelo = new System.Windows.Forms.Label();
            this.txtFicha = new System.Windows.Forms.MaskedTextBox();
            this.txtModelo = new System.Windows.Forms.MaskedTextBox();
            this.txtPlaca = new System.Windows.Forms.MaskedTextBox();
            this.txtCapacidad = new System.Windows.Forms.MaskedTextBox();
            this.flpToolbar = new System.Windows.Forms.FlowLayoutPanel();
            this.btnModoEdicion = new System.Windows.Forms.Button();
            this.btnVerTabla = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehiculos)).BeginInit();
            this.flpAcciones.SuspendLayout();
            this.tlpChoferes.SuspendLayout();
            this.flpToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvVehiculos
            // 
            this.dgvVehiculos.AllowUserToAddRows = false;
            this.dgvVehiculos.AllowUserToResizeColumns = false;
            this.dgvVehiculos.AllowUserToResizeRows = false;
            this.dgvVehiculos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVehiculos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.dgvVehiculos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVehiculos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVehiculos.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVehiculos.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvVehiculos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.dgvVehiculos.Location = new System.Drawing.Point(30, 340);
            this.dgvVehiculos.Margin = new System.Windows.Forms.Padding(0);
            this.dgvVehiculos.Name = "dgvVehiculos";
            this.dgvVehiculos.ReadOnly = true;
            this.dgvVehiculos.RowHeadersVisible = false;
            this.dgvVehiculos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVehiculos.Size = new System.Drawing.Size(874, 312);
            this.dgvVehiculos.TabIndex = 10;
            this.dgvVehiculos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVehiculos_CellClick);
            // 
            // flpAcciones
            // 
            this.flpAcciones.Controls.Add(this.btnGuardar);
            this.flpAcciones.Controls.Add(this.btnActualizar);
            this.flpAcciones.Controls.Add(this.btnEliminar);
            this.flpAcciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpAcciones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpAcciones.Location = new System.Drawing.Point(30, 283);
            this.flpAcciones.Name = "flpAcciones";
            this.flpAcciones.Padding = new System.Windows.Forms.Padding(0, 10, 30, 0);
            this.flpAcciones.Size = new System.Drawing.Size(874, 57);
            this.flpAcciones.TabIndex = 9;
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
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(511, 13);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(103, 32);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // tlpChoferes
            // 
            this.tlpChoferes.ColumnCount = 2;
            this.tlpChoferes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpChoferes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpChoferes.Controls.Add(this.lblTitulo, 0, 0);
            this.tlpChoferes.Controls.Add(this.lblPlaca, 1, 1);
            this.tlpChoferes.Controls.Add(this.lblFicha, 0, 1);
            this.tlpChoferes.Controls.Add(this.lblCapacidad, 1, 3);
            this.tlpChoferes.Controls.Add(this.lblModelo, 0, 3);
            this.tlpChoferes.Controls.Add(this.txtFicha, 0, 2);
            this.tlpChoferes.Controls.Add(this.txtModelo, 0, 4);
            this.tlpChoferes.Controls.Add(this.txtPlaca, 1, 2);
            this.tlpChoferes.Controls.Add(this.txtCapacidad, 1, 4);
            this.tlpChoferes.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpChoferes.ForeColor = System.Drawing.Color.White;
            this.tlpChoferes.Location = new System.Drawing.Point(30, 55);
            this.tlpChoferes.Margin = new System.Windows.Forms.Padding(0);
            this.tlpChoferes.Name = "tlpChoferes";
            this.tlpChoferes.Padding = new System.Windows.Forms.Padding(30);
            this.tlpChoferes.RowCount = 6;
            this.tlpChoferes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpChoferes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpChoferes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpChoferes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpChoferes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpChoferes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpChoferes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpChoferes.Size = new System.Drawing.Size(874, 228);
            this.tlpChoferes.TabIndex = 8;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpChoferes.SetColumnSpan(this.lblTitulo, 2);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitulo.Location = new System.Drawing.Point(33, 30);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(3, 0, 3, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(808, 23);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "DATOS DEL VEHÍCULO";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPlaca
            // 
            this.lblPlaca.AutoSize = true;
            this.lblPlaca.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPlaca.ForeColor = System.Drawing.Color.White;
            this.lblPlaca.Location = new System.Drawing.Point(440, 73);
            this.lblPlaca.Name = "lblPlaca";
            this.lblPlaca.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.lblPlaca.Size = new System.Drawing.Size(38, 30);
            this.lblPlaca.TabIndex = 1;
            this.lblPlaca.Text = "Placa:";
            // 
            // lblFicha
            // 
            this.lblFicha.AutoSize = true;
            this.lblFicha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFicha.ForeColor = System.Drawing.Color.White;
            this.lblFicha.Location = new System.Drawing.Point(33, 73);
            this.lblFicha.Name = "lblFicha";
            this.lblFicha.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.lblFicha.Size = new System.Drawing.Size(38, 30);
            this.lblFicha.TabIndex = 5;
            this.lblFicha.Text = "Ficha:";
            // 
            // lblCapacidad
            // 
            this.lblCapacidad.AutoSize = true;
            this.lblCapacidad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCapacidad.ForeColor = System.Drawing.Color.White;
            this.lblCapacidad.Location = new System.Drawing.Point(440, 129);
            this.lblCapacidad.Name = "lblCapacidad";
            this.lblCapacidad.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.lblCapacidad.Size = new System.Drawing.Size(66, 30);
            this.lblCapacidad.TabIndex = 7;
            this.lblCapacidad.Text = "Capacidad:";
            // 
            // lblModelo
            // 
            this.lblModelo.AutoSize = true;
            this.lblModelo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblModelo.Location = new System.Drawing.Point(33, 129);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.lblModelo.Size = new System.Drawing.Size(51, 30);
            this.lblModelo.TabIndex = 11;
            this.lblModelo.Text = "Modelo:";
            // 
            // txtFicha
            // 
            this.txtFicha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFicha.Location = new System.Drawing.Point(33, 106);
            this.txtFicha.Mask = "00-000";
            this.txtFicha.Name = "txtFicha";
            this.txtFicha.Size = new System.Drawing.Size(401, 20);
            this.txtFicha.TabIndex = 13;
            this.txtFicha.Click += new System.EventHandler(this.AcomodarCursor_Click);
            // 
            // txtModelo
            // 
            this.txtModelo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtModelo.Location = new System.Drawing.Point(33, 162);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(401, 20);
            this.txtModelo.TabIndex = 14;
            this.txtModelo.Click += new System.EventHandler(this.AcomodarCursor_Click);
            // 
            // txtPlaca
            // 
            this.txtPlaca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlaca.Location = new System.Drawing.Point(440, 106);
            this.txtPlaca.Mask = "L000000";
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(401, 20);
            this.txtPlaca.TabIndex = 15;
            this.txtPlaca.Click += new System.EventHandler(this.AcomodarCursor_Click);
            // 
            // txtCapacidad
            // 
            this.txtCapacidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCapacidad.Location = new System.Drawing.Point(440, 162);
            this.txtCapacidad.Mask = "000";
            this.txtCapacidad.Name = "txtCapacidad";
            this.txtCapacidad.Size = new System.Drawing.Size(401, 20);
            this.txtCapacidad.TabIndex = 16;
            this.txtCapacidad.Click += new System.EventHandler(this.AcomodarCursor_Click);
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
            this.flpToolbar.TabIndex = 11;
            // 
            // btnModoEdicion
            // 
            this.btnModoEdicion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModoEdicion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModoEdicion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnModoEdicion.ForeColor = System.Drawing.Color.White;
            this.btnModoEdicion.Image = ((System.Drawing.Image)(resources.GetObject("btnModoEdicion.Image")));
            this.btnModoEdicion.Location = new System.Drawing.Point(679, 3);
            this.btnModoEdicion.Name = "btnModoEdicion";
            this.btnModoEdicion.Size = new System.Drawing.Size(162, 36);
            this.btnModoEdicion.TabIndex = 0;
            this.btnModoEdicion.Text = "Editar";
            this.btnModoEdicion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModoEdicion.UseVisualStyleBackColor = true;
            this.btnModoEdicion.Click += new System.EventHandler(this.btnModoEdicion_Click);
            // 
            // btnVerTabla
            // 
            this.btnVerTabla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerTabla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerTabla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerTabla.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnVerTabla.ForeColor = System.Drawing.Color.White;
            this.btnVerTabla.Image = ((System.Drawing.Image)(resources.GetObject("btnVerTabla.Image")));
            this.btnVerTabla.Location = new System.Drawing.Point(508, 3);
            this.btnVerTabla.Name = "btnVerTabla";
            this.btnVerTabla.Size = new System.Drawing.Size(165, 36);
            this.btnVerTabla.TabIndex = 1;
            this.btnVerTabla.Text = "Ver Tabla";
            this.btnVerTabla.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVerTabla.UseVisualStyleBackColor = true;
            this.btnVerTabla.Click += new System.EventHandler(this.btnVerTabla_Click);
            // 
            // FrmVehiculos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(934, 712);
            this.Controls.Add(this.dgvVehiculos);
            this.Controls.Add(this.flpAcciones);
            this.Controls.Add(this.tlpChoferes);
            this.Controls.Add(this.flpToolbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmVehiculos";
            this.Padding = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.Text = "FrmRutas";
            this.Load += new System.EventHandler(this.FrmVehiculos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehiculos)).EndInit();
            this.flpAcciones.ResumeLayout(false);
            this.tlpChoferes.ResumeLayout(false);
            this.tlpChoferes.PerformLayout();
            this.flpToolbar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVehiculos;
        private System.Windows.Forms.FlowLayoutPanel flpAcciones;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.TableLayoutPanel tlpChoferes;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblPlaca;
        private System.Windows.Forms.Label lblFicha;
        private System.Windows.Forms.Label lblCapacidad;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.MaskedTextBox txtFicha;
        private System.Windows.Forms.MaskedTextBox txtModelo;
        private System.Windows.Forms.MaskedTextBox txtPlaca;
        private System.Windows.Forms.MaskedTextBox txtCapacidad;
        private System.Windows.Forms.FlowLayoutPanel flpToolbar;
        private System.Windows.Forms.Button btnModoEdicion;
        private System.Windows.Forms.Button btnVerTabla;
    }
}