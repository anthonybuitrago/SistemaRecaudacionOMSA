namespace SistemaRecaudacionOMSA
{
    partial class FrmRutas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRutas));
            this.dgvRutas = new System.Windows.Forms.DataGridView();
            this.flpAcciones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.tlpChoferes = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblTarifa = new System.Windows.Forms.Label();
            this.lblNombreRuta = new System.Windows.Forms.Label();
            this.lblDistancia = new System.Windows.Forms.Label();
            this.lblTiempo = new System.Windows.Forms.Label();
            this.txtNombreRuta = new System.Windows.Forms.MaskedTextBox();
            this.txtTiempo = new System.Windows.Forms.MaskedTextBox();
            this.txtTarifa = new System.Windows.Forms.MaskedTextBox();
            this.txtDistancia = new System.Windows.Forms.MaskedTextBox();
            this.flpToolbar = new System.Windows.Forms.FlowLayoutPanel();
            this.btnModoEdicion = new System.Windows.Forms.Button();
            this.btnVerTabla = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRutas)).BeginInit();
            this.flpAcciones.SuspendLayout();
            this.tlpChoferes.SuspendLayout();
            this.flpToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRutas
            // 
            this.dgvRutas.AllowUserToAddRows = false;
            this.dgvRutas.AllowUserToResizeColumns = false;
            this.dgvRutas.AllowUserToResizeRows = false;
            this.dgvRutas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRutas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.dgvRutas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRutas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRutas.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRutas.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvRutas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.dgvRutas.Location = new System.Drawing.Point(30, 340);
            this.dgvRutas.Margin = new System.Windows.Forms.Padding(0);
            this.dgvRutas.Name = "dgvRutas";
            this.dgvRutas.ReadOnly = true;
            this.dgvRutas.RowHeadersVisible = false;
            this.dgvRutas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRutas.Size = new System.Drawing.Size(874, 312);
            this.dgvRutas.TabIndex = 14;
            this.dgvRutas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRutas_CellClick);
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
            this.flpAcciones.TabIndex = 13;
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
            this.tlpChoferes.Controls.Add(this.lblTarifa, 1, 1);
            this.tlpChoferes.Controls.Add(this.lblNombreRuta, 0, 1);
            this.tlpChoferes.Controls.Add(this.lblDistancia, 1, 3);
            this.tlpChoferes.Controls.Add(this.lblTiempo, 0, 3);
            this.tlpChoferes.Controls.Add(this.txtNombreRuta, 0, 2);
            this.tlpChoferes.Controls.Add(this.txtTiempo, 0, 4);
            this.tlpChoferes.Controls.Add(this.txtTarifa, 1, 2);
            this.tlpChoferes.Controls.Add(this.txtDistancia, 1, 4);
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
            this.tlpChoferes.TabIndex = 12;
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
            this.lblTitulo.Text = "DATOS DE LA RUTA";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTarifa
            // 
            this.lblTarifa.AutoSize = true;
            this.lblTarifa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTarifa.ForeColor = System.Drawing.Color.White;
            this.lblTarifa.Location = new System.Drawing.Point(440, 73);
            this.lblTarifa.Name = "lblTarifa";
            this.lblTarifa.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.lblTarifa.Size = new System.Drawing.Size(39, 30);
            this.lblTarifa.TabIndex = 1;
            this.lblTarifa.Text = "Tarifa:";
            // 
            // lblNombreRuta
            // 
            this.lblNombreRuta.AutoSize = true;
            this.lblNombreRuta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNombreRuta.ForeColor = System.Drawing.Color.White;
            this.lblNombreRuta.Location = new System.Drawing.Point(33, 73);
            this.lblNombreRuta.Name = "lblNombreRuta";
            this.lblNombreRuta.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.lblNombreRuta.Size = new System.Drawing.Size(97, 30);
            this.lblNombreRuta.TabIndex = 5;
            this.lblNombreRuta.Text = "Nombre de Ruta:";
            // 
            // lblDistancia
            // 
            this.lblDistancia.AutoSize = true;
            this.lblDistancia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDistancia.ForeColor = System.Drawing.Color.White;
            this.lblDistancia.Location = new System.Drawing.Point(440, 129);
            this.lblDistancia.Name = "lblDistancia";
            this.lblDistancia.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.lblDistancia.Size = new System.Drawing.Size(58, 30);
            this.lblDistancia.TabIndex = 7;
            this.lblDistancia.Text = "Distancia:";
            // 
            // lblTiempo
            // 
            this.lblTiempo.AutoSize = true;
            this.lblTiempo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTiempo.Location = new System.Drawing.Point(33, 129);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.lblTiempo.Size = new System.Drawing.Size(51, 30);
            this.lblTiempo.TabIndex = 11;
            this.lblTiempo.Text = "Tiempo:";
            // 
            // txtNombreRuta
            // 
            this.txtNombreRuta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombreRuta.Location = new System.Drawing.Point(33, 106);
            this.txtNombreRuta.Name = "txtNombreRuta";
            this.txtNombreRuta.Size = new System.Drawing.Size(401, 20);
            this.txtNombreRuta.TabIndex = 13;
            this.txtNombreRuta.Click += new System.EventHandler(this.AcomodarCursor_Click);
            // 
            // txtTiempo
            // 
            this.txtTiempo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTiempo.Location = new System.Drawing.Point(33, 162);
            this.txtTiempo.Name = "txtTiempo";
            this.txtTiempo.Size = new System.Drawing.Size(401, 20);
            this.txtTiempo.TabIndex = 14;
            this.txtTiempo.Click += new System.EventHandler(this.AcomodarCursor_Click);
            // 
            // txtTarifa
            // 
            this.txtTarifa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTarifa.Location = new System.Drawing.Point(440, 106);
            this.txtTarifa.Mask = "00.00";
            this.txtTarifa.Name = "txtTarifa";
            this.txtTarifa.Size = new System.Drawing.Size(401, 20);
            this.txtTarifa.TabIndex = 15;
            this.txtTarifa.Click += new System.EventHandler(this.AcomodarCursor_Click);
            // 
            // txtDistancia
            // 
            this.txtDistancia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDistancia.Location = new System.Drawing.Point(440, 162);
            this.txtDistancia.Name = "txtDistancia";
            this.txtDistancia.Size = new System.Drawing.Size(401, 20);
            this.txtDistancia.TabIndex = 16;
            this.txtDistancia.Click += new System.EventHandler(this.AcomodarCursor_Click);
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
            this.flpToolbar.TabIndex = 15;
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
            // FrmRutas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(934, 712);
            this.Controls.Add(this.dgvRutas);
            this.Controls.Add(this.flpAcciones);
            this.Controls.Add(this.tlpChoferes);
            this.Controls.Add(this.flpToolbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRutas";
            this.Padding = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.Text = "FrmRutas";
            this.Load += new System.EventHandler(this.FrmRutas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRutas)).EndInit();
            this.flpAcciones.ResumeLayout(false);
            this.tlpChoferes.ResumeLayout(false);
            this.tlpChoferes.PerformLayout();
            this.flpToolbar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRutas;
        private System.Windows.Forms.FlowLayoutPanel flpAcciones;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.TableLayoutPanel tlpChoferes;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblTarifa;
        private System.Windows.Forms.Label lblNombreRuta;
        private System.Windows.Forms.Label lblDistancia;
        private System.Windows.Forms.Label lblTiempo;
        private System.Windows.Forms.MaskedTextBox txtNombreRuta;
        private System.Windows.Forms.MaskedTextBox txtTiempo;
        private System.Windows.Forms.MaskedTextBox txtTarifa;
        private System.Windows.Forms.MaskedTextBox txtDistancia;
        private System.Windows.Forms.FlowLayoutPanel flpToolbar;
        private System.Windows.Forms.Button btnModoEdicion;
        private System.Windows.Forms.Button btnVerTabla;
    }
}