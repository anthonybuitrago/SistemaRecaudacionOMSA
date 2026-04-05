namespace SistemaRecaudacionOMSA
{
    partial class FrmTickets
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTickets));
            this.dgvTickets = new System.Windows.Forms.DataGridView();
            this.flpAcciones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.tlpViaje = new System.Windows.Forms.TableLayoutPanel();
            this.lblViaje = new System.Windows.Forms.Label();
            this.lblTickets = new System.Windows.Forms.Label();
            this.cmbViaje = new System.Windows.Forms.ComboBox();
            this.lblTarifa = new System.Windows.Forms.Label();
            this.lblCantidadTickets = new System.Windows.Forms.Label();
            this.lblTotalPagar = new System.Windows.Forms.Label();
            this.cmbCantidadTickets = new System.Windows.Forms.ComboBox();
            this.txtTotalPagar = new System.Windows.Forms.MaskedTextBox();
            this.txtTarifa = new System.Windows.Forms.MaskedTextBox();
            this.flpToolbar = new System.Windows.Forms.FlowLayoutPanel();
            this.btnModoEdicion = new System.Windows.Forms.Button();
            this.btnVerTabla = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTickets)).BeginInit();
            this.flpAcciones.SuspendLayout();
            this.tlpViaje.SuspendLayout();
            this.flpToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTickets
            // 
            this.dgvTickets.AllowUserToAddRows = false;
            this.dgvTickets.AllowUserToResizeColumns = false;
            this.dgvTickets.AllowUserToResizeRows = false;
            this.dgvTickets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTickets.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.dgvTickets.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTickets.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTickets.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvTickets.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.dgvTickets.Location = new System.Drawing.Point(30, 345);
            this.dgvTickets.Margin = new System.Windows.Forms.Padding(0);
            this.dgvTickets.Name = "dgvTickets";
            this.dgvTickets.ReadOnly = true;
            this.dgvTickets.RowHeadersVisible = false;
            this.dgvTickets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTickets.Size = new System.Drawing.Size(874, 312);
            this.dgvTickets.TabIndex = 6;
            this.dgvTickets.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTickets_CellClick);
            // 
            // flpAcciones
            // 
            this.flpAcciones.Controls.Add(this.btnGuardar);
            this.flpAcciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpAcciones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpAcciones.Location = new System.Drawing.Point(30, 285);
            this.flpAcciones.Name = "flpAcciones";
            this.flpAcciones.Padding = new System.Windows.Forms.Padding(0, 10, 30, 0);
            this.flpAcciones.Size = new System.Drawing.Size(874, 60);
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
            // tlpViaje
            // 
            this.tlpViaje.ColumnCount = 2;
            this.tlpViaje.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpViaje.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpViaje.Controls.Add(this.lblViaje, 0, 1);
            this.tlpViaje.Controls.Add(this.lblTickets, 0, 0);
            this.tlpViaje.Controls.Add(this.cmbViaje, 0, 2);
            this.tlpViaje.Controls.Add(this.lblTarifa, 0, 3);
            this.tlpViaje.Controls.Add(this.lblCantidadTickets, 1, 1);
            this.tlpViaje.Controls.Add(this.lblTotalPagar, 1, 3);
            this.tlpViaje.Controls.Add(this.cmbCantidadTickets, 1, 2);
            this.tlpViaje.Controls.Add(this.txtTotalPagar, 1, 4);
            this.tlpViaje.Controls.Add(this.txtTarifa, 0, 4);
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
            this.tlpViaje.Size = new System.Drawing.Size(874, 230);
            this.tlpViaje.TabIndex = 4;
            // 
            // lblViaje
            // 
            this.lblViaje.AutoSize = true;
            this.lblViaje.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblViaje.ForeColor = System.Drawing.Color.White;
            this.lblViaje.Location = new System.Drawing.Point(33, 73);
            this.lblViaje.Name = "lblViaje";
            this.lblViaje.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.lblViaje.Size = new System.Drawing.Size(98, 30);
            this.lblViaje.TabIndex = 1;
            this.lblViaje.Text = "Seleccionar Viaje:";
            // 
            // lblTickets
            // 
            this.lblTickets.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpViaje.SetColumnSpan(this.lblTickets, 2);
            this.lblTickets.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTickets.ForeColor = System.Drawing.Color.White;
            this.lblTickets.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTickets.Location = new System.Drawing.Point(33, 30);
            this.lblTickets.Margin = new System.Windows.Forms.Padding(3, 0, 3, 20);
            this.lblTickets.Name = "lblTickets";
            this.lblTickets.Size = new System.Drawing.Size(808, 23);
            this.lblTickets.TabIndex = 0;
            this.lblTickets.Text = "VENDER TICKETS";
            this.lblTickets.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbViaje
            // 
            this.cmbViaje.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbViaje.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbViaje.Enabled = false;
            this.cmbViaje.FormattingEnabled = true;
            this.cmbViaje.Location = new System.Drawing.Point(33, 106);
            this.cmbViaje.Name = "cmbViaje";
            this.cmbViaje.Size = new System.Drawing.Size(401, 21);
            this.cmbViaje.TabIndex = 2;
            this.cmbViaje.SelectedIndexChanged += new System.EventHandler(this.cmbViaje_SelectedIndexChanged);
            // 
            // lblTarifa
            // 
            this.lblTarifa.AutoSize = true;
            this.lblTarifa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTarifa.ForeColor = System.Drawing.Color.White;
            this.lblTarifa.Location = new System.Drawing.Point(33, 130);
            this.lblTarifa.Name = "lblTarifa";
            this.lblTarifa.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.lblTarifa.Size = new System.Drawing.Size(39, 30);
            this.lblTarifa.TabIndex = 7;
            this.lblTarifa.Text = "Tarífa:";
            // 
            // lblCantidadTickets
            // 
            this.lblCantidadTickets.AutoSize = true;
            this.lblCantidadTickets.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCantidadTickets.ForeColor = System.Drawing.Color.White;
            this.lblCantidadTickets.Location = new System.Drawing.Point(440, 73);
            this.lblCantidadTickets.Name = "lblCantidadTickets";
            this.lblCantidadTickets.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.lblCantidadTickets.Size = new System.Drawing.Size(114, 30);
            this.lblCantidadTickets.TabIndex = 5;
            this.lblCantidadTickets.Text = "Cantidad de Tickets:";
            // 
            // lblTotalPagar
            // 
            this.lblTotalPagar.AutoSize = true;
            this.lblTotalPagar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalPagar.ForeColor = System.Drawing.Color.White;
            this.lblTotalPagar.Location = new System.Drawing.Point(440, 130);
            this.lblTotalPagar.Name = "lblTotalPagar";
            this.lblTotalPagar.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.lblTotalPagar.Size = new System.Drawing.Size(78, 30);
            this.lblTotalPagar.TabIndex = 3;
            this.lblTotalPagar.Text = "Total a Pagar:";
            // 
            // cmbCantidadTickets
            // 
            this.cmbCantidadTickets.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCantidadTickets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCantidadTickets.Enabled = false;
            this.cmbCantidadTickets.FormattingEnabled = true;
            this.cmbCantidadTickets.Location = new System.Drawing.Point(440, 106);
            this.cmbCantidadTickets.Name = "cmbCantidadTickets";
            this.cmbCantidadTickets.Size = new System.Drawing.Size(401, 21);
            this.cmbCantidadTickets.TabIndex = 6;
            this.cmbCantidadTickets.SelectedIndexChanged += new System.EventHandler(this.cmbCantidadTickets_SelectedIndexChanged);
            // 
            // txtTotalPagar
            // 
            this.txtTotalPagar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalPagar.Location = new System.Drawing.Point(440, 163);
            this.txtTotalPagar.Name = "txtTotalPagar";
            this.txtTotalPagar.Size = new System.Drawing.Size(401, 20);
            this.txtTotalPagar.TabIndex = 9;
            // 
            // txtTarifa
            // 
            this.txtTarifa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTarifa.Location = new System.Drawing.Point(33, 163);
            this.txtTarifa.Name = "txtTarifa";
            this.txtTarifa.Size = new System.Drawing.Size(401, 20);
            this.txtTarifa.TabIndex = 10;
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
            this.btnModoEdicion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnVerTabla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerTabla.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnVerTabla.ForeColor = System.Drawing.Color.White;
            this.btnVerTabla.Image = ((System.Drawing.Image)(resources.GetObject("btnVerTabla.Image")));
            this.btnVerTabla.Location = new System.Drawing.Point(520, 3);
            this.btnVerTabla.Name = "btnVerTabla";
            this.btnVerTabla.Size = new System.Drawing.Size(153, 36);
            this.btnVerTabla.TabIndex = 1;
            this.btnVerTabla.Text = "Ver Tabla";
            this.btnVerTabla.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVerTabla.UseVisualStyleBackColor = true;
            this.btnVerTabla.Click += new System.EventHandler(this.btnVerTabla_Click);
            // 
            // FrmTickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(934, 712);
            this.Controls.Add(this.dgvTickets);
            this.Controls.Add(this.flpAcciones);
            this.Controls.Add(this.tlpViaje);
            this.Controls.Add(this.flpToolbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTickets";
            this.Padding = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.Text = "FrmRutas";
            this.Load += new System.EventHandler(this.FrmTickets_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTickets)).EndInit();
            this.flpAcciones.ResumeLayout(false);
            this.tlpViaje.ResumeLayout(false);
            this.tlpViaje.PerformLayout();
            this.flpToolbar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTickets;
        private System.Windows.Forms.FlowLayoutPanel flpAcciones;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TableLayoutPanel tlpViaje;
        private System.Windows.Forms.Label lblViaje;
        private System.Windows.Forms.Label lblTickets;
        private System.Windows.Forms.ComboBox cmbViaje;
        private System.Windows.Forms.Label lblTarifa;
        private System.Windows.Forms.Label lblCantidadTickets;
        private System.Windows.Forms.Label lblTotalPagar;
        private System.Windows.Forms.ComboBox cmbCantidadTickets;
        private System.Windows.Forms.FlowLayoutPanel flpToolbar;
        private System.Windows.Forms.Button btnModoEdicion;
        private System.Windows.Forms.Button btnVerTabla;
        private System.Windows.Forms.MaskedTextBox txtTotalPagar;
        private System.Windows.Forms.MaskedTextBox txtTarifa;
    }
}