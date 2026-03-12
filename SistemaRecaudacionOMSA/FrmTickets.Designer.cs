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
            this.dgvTickets = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbViaje = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnVender = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTickets)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTickets
            // 
            this.dgvTickets.AllowUserToAddRows = false;
            this.dgvTickets.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvTickets.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTickets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTickets.Location = new System.Drawing.Point(280, 0);
            this.dgvTickets.Name = "dgvTickets";
            this.dgvTickets.ReadOnly = true;
            this.dgvTickets.RowHeadersVisible = false;
            this.dgvTickets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTickets.Size = new System.Drawing.Size(520, 450);
            this.dgvTickets.TabIndex = 9;
            this.dgvTickets.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTickets_CellClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.cmbViaje);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnLimpiar);
            this.panel1.Controls.Add(this.txtMonto);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnVender);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 450);
            this.panel1.TabIndex = 10;
            // 
            // cmbViaje
            // 
            this.cmbViaje.FormattingEnabled = true;
            this.cmbViaje.Location = new System.Drawing.Point(54, 95);
            this.cmbViaje.Name = "cmbViaje";
            this.cmbViaje.Size = new System.Drawing.Size(180, 21);
            this.cmbViaje.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(0, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(280, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "VENDER TICKETS";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(54, 301);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(180, 31);
            this.btnLimpiar.TabIndex = 8;
            this.btnLimpiar.Text = "Limpiar Campos";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(54, 154);
            this.txtMonto.MaxLength = 11;
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(180, 20);
            this.txtMonto.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.Location = new System.Drawing.Point(50, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Monto a Pagar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.Location = new System.Drawing.Point(50, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Seleccionar Viaje";
            // 
            // btnVender
            // 
            this.btnVender.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(132)))), ((int)(((byte)(61)))));
            this.btnVender.FlatAppearance.BorderSize = 0;
            this.btnVender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVender.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnVender.ForeColor = System.Drawing.Color.White;
            this.btnVender.Location = new System.Drawing.Point(54, 264);
            this.btnVender.Name = "btnVender";
            this.btnVender.Size = new System.Drawing.Size(180, 31);
            this.btnVender.TabIndex = 6;
            this.btnVender.Text = "Registrar Venta";
            this.btnVender.UseVisualStyleBackColor = false;
            this.btnVender.Click += new System.EventHandler(this.btnVender_Click);
            // 
            // FrmTickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvTickets);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTickets";
            this.Text = "FrmRutas";
            this.Load += new System.EventHandler(this.FrmTickets_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTickets)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTickets;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnVender;
        private System.Windows.Forms.ComboBox cmbViaje;
    }
}