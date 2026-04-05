namespace SistemaRecaudacionOMSA
{
    partial class FrmChoferes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChoferes));
            this.dgvChoferes = new System.Windows.Forms.DataGridView();
            this.flpAcciones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.tlpChoferes = new System.Windows.Forms.TableLayoutPanel();
            this.lblCedula = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblLicencia = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.flpToolbar = new System.Windows.Forms.FlowLayoutPanel();
            this.btnModoEdicion = new System.Windows.Forms.Button();
            this.btnVerTabla = new System.Windows.Forms.Button();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.MaskedTextBox();
            this.txtTelefono = new System.Windows.Forms.MaskedTextBox();
            this.txtCedula = new System.Windows.Forms.MaskedTextBox();
            this.txtLicencia = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChoferes)).BeginInit();
            this.flpAcciones.SuspendLayout();
            this.tlpChoferes.SuspendLayout();
            this.flpToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvChoferes
            // 
            this.dgvChoferes.AllowUserToAddRows = false;
            this.dgvChoferes.AllowUserToResizeColumns = false;
            this.dgvChoferes.AllowUserToResizeRows = false;
            this.dgvChoferes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChoferes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.dgvChoferes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvChoferes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChoferes.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvChoferes.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvChoferes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.dgvChoferes.Location = new System.Drawing.Point(30, 340);
            this.dgvChoferes.Margin = new System.Windows.Forms.Padding(0);
            this.dgvChoferes.Name = "dgvChoferes";
            this.dgvChoferes.ReadOnly = true;
            this.dgvChoferes.RowHeadersVisible = false;
            this.dgvChoferes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChoferes.Size = new System.Drawing.Size(874, 312);
            this.dgvChoferes.TabIndex = 6;
            this.dgvChoferes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChoferes_CellClick);
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
            this.flpAcciones.TabIndex = 5;
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
            this.tlpChoferes.Controls.Add(this.lblCedula, 1, 1);
            this.tlpChoferes.Controls.Add(this.lblNombre, 0, 1);
            this.tlpChoferes.Controls.Add(this.lblLicencia, 1, 3);
            this.tlpChoferes.Controls.Add(this.lblTelefono, 0, 3);
            this.tlpChoferes.Controls.Add(this.txtNombre, 0, 2);
            this.tlpChoferes.Controls.Add(this.txtTelefono, 0, 4);
            this.tlpChoferes.Controls.Add(this.txtCedula, 1, 2);
            this.tlpChoferes.Controls.Add(this.txtLicencia, 1, 4);
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
            this.tlpChoferes.TabIndex = 4;
            // 
            // lblCedula
            // 
            this.lblCedula.AutoSize = true;
            this.lblCedula.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCedula.ForeColor = System.Drawing.Color.White;
            this.lblCedula.Location = new System.Drawing.Point(440, 73);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.lblCedula.Size = new System.Drawing.Size(47, 30);
            this.lblCedula.TabIndex = 1;
            this.lblCedula.Text = "Cédula:";
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
            this.lblTitulo.Text = "DATOS DEL CHOFER";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLicencia
            // 
            this.lblLicencia.AutoSize = true;
            this.lblLicencia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLicencia.ForeColor = System.Drawing.Color.White;
            this.lblLicencia.Location = new System.Drawing.Point(440, 129);
            this.lblLicencia.Name = "lblLicencia";
            this.lblLicencia.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.lblLicencia.Size = new System.Drawing.Size(53, 30);
            this.lblLicencia.TabIndex = 7;
            this.lblLicencia.Text = "Licencia:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNombre.ForeColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(33, 73);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.lblNombre.Size = new System.Drawing.Size(54, 30);
            this.lblNombre.TabIndex = 5;
            this.lblNombre.Text = "Nombre:";
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
            this.flpToolbar.TabIndex = 7;
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
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTelefono.Location = new System.Drawing.Point(33, 129);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.lblTelefono.Size = new System.Drawing.Size(53, 30);
            this.lblTelefono.TabIndex = 11;
            this.lblTelefono.Text = "Teléfono";
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.Location = new System.Drawing.Point(33, 106);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(401, 20);
            this.txtNombre.TabIndex = 13;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTelefono.Location = new System.Drawing.Point(33, 162);
            this.txtTelefono.Mask = "(000) 000-0000";
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(401, 20);
            this.txtTelefono.TabIndex = 14;
            this.txtTelefono.Click += new System.EventHandler(this.AcomodarCursor_Click);
            // 
            // txtCedula
            // 
            this.txtCedula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCedula.Location = new System.Drawing.Point(440, 106);
            this.txtCedula.Mask = "000-0000000-0";
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(401, 20);
            this.txtCedula.TabIndex = 15;
            this.txtCedula.Click += new System.EventHandler(this.AcomodarCursor_Click);
            // 
            // txtLicencia
            // 
            this.txtLicencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLicencia.Location = new System.Drawing.Point(440, 162);
            this.txtLicencia.Mask = "000-0000000-0";
            this.txtLicencia.Name = "txtLicencia";
            this.txtLicencia.Size = new System.Drawing.Size(401, 20);
            this.txtLicencia.TabIndex = 16;
            this.txtLicencia.Click += new System.EventHandler(this.AcomodarCursor_Click);
            // 
            // FrmChoferes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(934, 712);
            this.Controls.Add(this.dgvChoferes);
            this.Controls.Add(this.flpAcciones);
            this.Controls.Add(this.tlpChoferes);
            this.Controls.Add(this.flpToolbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmChoferes";
            this.Padding = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.Text = "FrmChoferes";
            this.Load += new System.EventHandler(this.FrmChoferes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChoferes)).EndInit();
            this.flpAcciones.ResumeLayout(false);
            this.tlpChoferes.ResumeLayout(false);
            this.tlpChoferes.PerformLayout();
            this.flpToolbar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvChoferes;
        private System.Windows.Forms.FlowLayoutPanel flpAcciones;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.TableLayoutPanel tlpChoferes;
        private System.Windows.Forms.Label lblCedula;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblLicencia;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.FlowLayoutPanel flpToolbar;
        private System.Windows.Forms.Button btnModoEdicion;
        private System.Windows.Forms.Button btnVerTabla;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.MaskedTextBox txtNombre;
        private System.Windows.Forms.MaskedTextBox txtTelefono;
        private System.Windows.Forms.MaskedTextBox txtCedula;
        private System.Windows.Forms.MaskedTextBox txtLicencia;
    }
}

