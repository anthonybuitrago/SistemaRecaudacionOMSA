namespace SistemaRecaudacionOMSA
{
    partial class FrmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlSubMenuSistema = new System.Windows.Forms.Panel();
            this.btnAcercaDe = new System.Windows.Forms.Button();
            this.btnMenuSistema = new System.Windows.Forms.Button();
            this.pnlSubMenuConsulta = new System.Windows.Forms.Panel();
            this.btnConsultaReportes = new System.Windows.Forms.Button();
            this.btnConsultaViajes = new System.Windows.Forms.Button();
            this.btnConsultaVehiculos = new System.Windows.Forms.Button();
            this.btnConsultaRutas = new System.Windows.Forms.Button();
            this.btnConsultaChoferes = new System.Windows.Forms.Button();
            this.btnMenuConsulta = new System.Windows.Forms.Button();
            this.pnlSubMenuEntrada = new System.Windows.Forms.Panel();
            this.btnEntradaViajes = new System.Windows.Forms.Button();
            this.btnEntradaTickets = new System.Windows.Forms.Button();
            this.btnEntradaVehiculos = new System.Windows.Forms.Button();
            this.btnEntradaRutas = new System.Windows.Forms.Button();
            this.btnEntradaChoferes = new System.Windows.Forms.Button();
            this.btnMenuEntrada = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.pnlSidebar.SuspendLayout();
            this.pnlSubMenuSistema.SuspendLayout();
            this.pnlSubMenuConsulta.SuspendLayout();
            this.pnlSubMenuEntrada.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnlSidebar.Controls.Add(this.pnlSubMenuSistema);
            this.pnlSidebar.Controls.Add(this.btnMenuSistema);
            this.pnlSidebar.Controls.Add(this.pnlSubMenuConsulta);
            this.pnlSidebar.Controls.Add(this.btnMenuConsulta);
            this.pnlSidebar.Controls.Add(this.pnlSubMenuEntrada);
            this.pnlSidebar.Controls.Add(this.btnMenuEntrada);
            this.pnlSidebar.Controls.Add(this.pictureBox1);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(250, 741);
            this.pnlSidebar.TabIndex = 7;
            // 
            // pnlSubMenuSistema
            // 
            this.pnlSubMenuSistema.Controls.Add(this.btnAcercaDe);
            this.pnlSubMenuSistema.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSubMenuSistema.Location = new System.Drawing.Point(0, 882);
            this.pnlSubMenuSistema.Name = "pnlSubMenuSistema";
            this.pnlSubMenuSistema.Size = new System.Drawing.Size(250, 59);
            this.pnlSubMenuSistema.TabIndex = 14;
            // 
            // btnAcercaDe
            // 
            this.btnAcercaDe.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAcercaDe.FlatAppearance.BorderSize = 0;
            this.btnAcercaDe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcercaDe.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnAcercaDe.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAcercaDe.Location = new System.Drawing.Point(0, 0);
            this.btnAcercaDe.Name = "btnAcercaDe";
            this.btnAcercaDe.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnAcercaDe.Size = new System.Drawing.Size(250, 49);
            this.btnAcercaDe.TabIndex = 9;
            this.btnAcercaDe.Text = "Acerca del Sistema";
            this.btnAcercaDe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAcercaDe.UseVisualStyleBackColor = true;
            this.btnAcercaDe.Click += new System.EventHandler(this.btnAcercaDe_Click_1);
            // 
            // btnMenuSistema
            // 
            this.btnMenuSistema.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuSistema.FlatAppearance.BorderSize = 0;
            this.btnMenuSistema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuSistema.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnMenuSistema.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnMenuSistema.Location = new System.Drawing.Point(0, 822);
            this.btnMenuSistema.Name = "btnMenuSistema";
            this.btnMenuSistema.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnMenuSistema.Size = new System.Drawing.Size(250, 60);
            this.btnMenuSistema.TabIndex = 11;
            this.btnMenuSistema.Text = "SISTEMA";
            this.btnMenuSistema.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuSistema.UseVisualStyleBackColor = true;
            this.btnMenuSistema.Click += new System.EventHandler(this.btnMenuSistema_Click);
            // 
            // pnlSubMenuConsulta
            // 
            this.pnlSubMenuConsulta.Controls.Add(this.btnConsultaReportes);
            this.pnlSubMenuConsulta.Controls.Add(this.btnConsultaViajes);
            this.pnlSubMenuConsulta.Controls.Add(this.btnConsultaVehiculos);
            this.pnlSubMenuConsulta.Controls.Add(this.btnConsultaRutas);
            this.pnlSubMenuConsulta.Controls.Add(this.btnConsultaChoferes);
            this.pnlSubMenuConsulta.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSubMenuConsulta.Location = new System.Drawing.Point(0, 528);
            this.pnlSubMenuConsulta.Name = "pnlSubMenuConsulta";
            this.pnlSubMenuConsulta.Size = new System.Drawing.Size(250, 294);
            this.pnlSubMenuConsulta.TabIndex = 13;
            // 
            // btnConsultaReportes
            // 
            this.btnConsultaReportes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConsultaReportes.FlatAppearance.BorderSize = 0;
            this.btnConsultaReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultaReportes.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnConsultaReportes.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnConsultaReportes.Location = new System.Drawing.Point(0, 240);
            this.btnConsultaReportes.Name = "btnConsultaReportes";
            this.btnConsultaReportes.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnConsultaReportes.Size = new System.Drawing.Size(250, 60);
            this.btnConsultaReportes.TabIndex = 7;
            this.btnConsultaReportes.Text = "Ver Reportes";
            this.btnConsultaReportes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultaReportes.UseVisualStyleBackColor = true;
            this.btnConsultaReportes.Click += new System.EventHandler(this.btnConsultaReportes_Click);
            // 
            // btnConsultaViajes
            // 
            this.btnConsultaViajes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConsultaViajes.FlatAppearance.BorderSize = 0;
            this.btnConsultaViajes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultaViajes.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnConsultaViajes.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnConsultaViajes.Location = new System.Drawing.Point(0, 180);
            this.btnConsultaViajes.Name = "btnConsultaViajes";
            this.btnConsultaViajes.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnConsultaViajes.Size = new System.Drawing.Size(250, 60);
            this.btnConsultaViajes.TabIndex = 11;
            this.btnConsultaViajes.Text = "Consultar Viajes";
            this.btnConsultaViajes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultaViajes.UseVisualStyleBackColor = true;
            this.btnConsultaViajes.Click += new System.EventHandler(this.btnConsultaViajes_Click);
            // 
            // btnConsultaVehiculos
            // 
            this.btnConsultaVehiculos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConsultaVehiculos.FlatAppearance.BorderSize = 0;
            this.btnConsultaVehiculos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultaVehiculos.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnConsultaVehiculos.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnConsultaVehiculos.Location = new System.Drawing.Point(0, 120);
            this.btnConsultaVehiculos.Name = "btnConsultaVehiculos";
            this.btnConsultaVehiculos.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnConsultaVehiculos.Size = new System.Drawing.Size(250, 60);
            this.btnConsultaVehiculos.TabIndex = 10;
            this.btnConsultaVehiculos.Text = "Consultar Vehículos";
            this.btnConsultaVehiculos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultaVehiculos.UseVisualStyleBackColor = true;
            this.btnConsultaVehiculos.Click += new System.EventHandler(this.btnConsultaVehiculos_Click);
            // 
            // btnConsultaRutas
            // 
            this.btnConsultaRutas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConsultaRutas.FlatAppearance.BorderSize = 0;
            this.btnConsultaRutas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultaRutas.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnConsultaRutas.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnConsultaRutas.Location = new System.Drawing.Point(0, 60);
            this.btnConsultaRutas.Name = "btnConsultaRutas";
            this.btnConsultaRutas.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnConsultaRutas.Size = new System.Drawing.Size(250, 60);
            this.btnConsultaRutas.TabIndex = 9;
            this.btnConsultaRutas.Text = "Consultar Rutas";
            this.btnConsultaRutas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultaRutas.UseVisualStyleBackColor = true;
            this.btnConsultaRutas.Click += new System.EventHandler(this.btnConsultaRutas_Click);
            // 
            // btnConsultaChoferes
            // 
            this.btnConsultaChoferes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConsultaChoferes.FlatAppearance.BorderSize = 0;
            this.btnConsultaChoferes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultaChoferes.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnConsultaChoferes.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnConsultaChoferes.Location = new System.Drawing.Point(0, 0);
            this.btnConsultaChoferes.Name = "btnConsultaChoferes";
            this.btnConsultaChoferes.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnConsultaChoferes.Size = new System.Drawing.Size(250, 60);
            this.btnConsultaChoferes.TabIndex = 8;
            this.btnConsultaChoferes.Text = "Consultar Choferes";
            this.btnConsultaChoferes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultaChoferes.UseVisualStyleBackColor = true;
            this.btnConsultaChoferes.Click += new System.EventHandler(this.btnConsultaChoferes_Click);
            // 
            // btnMenuConsulta
            // 
            this.btnMenuConsulta.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuConsulta.FlatAppearance.BorderSize = 0;
            this.btnMenuConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuConsulta.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnMenuConsulta.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnMenuConsulta.Location = new System.Drawing.Point(0, 468);
            this.btnMenuConsulta.Name = "btnMenuConsulta";
            this.btnMenuConsulta.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnMenuConsulta.Size = new System.Drawing.Size(250, 60);
            this.btnMenuConsulta.TabIndex = 10;
            this.btnMenuConsulta.Text = "CONSULTA";
            this.btnMenuConsulta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuConsulta.UseVisualStyleBackColor = true;
            this.btnMenuConsulta.Click += new System.EventHandler(this.btnMenuConsulta_Click);
            // 
            // pnlSubMenuEntrada
            // 
            this.pnlSubMenuEntrada.Controls.Add(this.btnEntradaViajes);
            this.pnlSubMenuEntrada.Controls.Add(this.btnEntradaTickets);
            this.pnlSubMenuEntrada.Controls.Add(this.btnEntradaVehiculos);
            this.pnlSubMenuEntrada.Controls.Add(this.btnEntradaRutas);
            this.pnlSubMenuEntrada.Controls.Add(this.btnEntradaChoferes);
            this.pnlSubMenuEntrada.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSubMenuEntrada.Location = new System.Drawing.Point(0, 160);
            this.pnlSubMenuEntrada.Name = "pnlSubMenuEntrada";
            this.pnlSubMenuEntrada.Size = new System.Drawing.Size(250, 308);
            this.pnlSubMenuEntrada.TabIndex = 12;
            // 
            // btnEntradaViajes
            // 
            this.btnEntradaViajes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEntradaViajes.FlatAppearance.BorderSize = 0;
            this.btnEntradaViajes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntradaViajes.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnEntradaViajes.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnEntradaViajes.Location = new System.Drawing.Point(0, 240);
            this.btnEntradaViajes.Name = "btnEntradaViajes";
            this.btnEntradaViajes.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnEntradaViajes.Size = new System.Drawing.Size(250, 60);
            this.btnEntradaViajes.TabIndex = 7;
            this.btnEntradaViajes.Text = "Registrar Viajes";
            this.btnEntradaViajes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEntradaViajes.UseVisualStyleBackColor = true;
            this.btnEntradaViajes.Click += new System.EventHandler(this.btnEntradaViajes_Click);
            // 
            // btnEntradaTickets
            // 
            this.btnEntradaTickets.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEntradaTickets.FlatAppearance.BorderSize = 0;
            this.btnEntradaTickets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntradaTickets.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnEntradaTickets.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnEntradaTickets.Location = new System.Drawing.Point(0, 180);
            this.btnEntradaTickets.Name = "btnEntradaTickets";
            this.btnEntradaTickets.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnEntradaTickets.Size = new System.Drawing.Size(250, 60);
            this.btnEntradaTickets.TabIndex = 6;
            this.btnEntradaTickets.Text = "Vender Tickets";
            this.btnEntradaTickets.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEntradaTickets.UseVisualStyleBackColor = true;
            this.btnEntradaTickets.Click += new System.EventHandler(this.btnEntradaTickets_Click);
            // 
            // btnEntradaVehiculos
            // 
            this.btnEntradaVehiculos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEntradaVehiculos.FlatAppearance.BorderSize = 0;
            this.btnEntradaVehiculos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntradaVehiculos.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnEntradaVehiculos.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnEntradaVehiculos.Location = new System.Drawing.Point(0, 120);
            this.btnEntradaVehiculos.Name = "btnEntradaVehiculos";
            this.btnEntradaVehiculos.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnEntradaVehiculos.Size = new System.Drawing.Size(250, 60);
            this.btnEntradaVehiculos.TabIndex = 4;
            this.btnEntradaVehiculos.Text = "Registrar Vehículos";
            this.btnEntradaVehiculos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEntradaVehiculos.UseVisualStyleBackColor = true;
            this.btnEntradaVehiculos.Click += new System.EventHandler(this.btnEntradaVehiculos_Click);
            // 
            // btnEntradaRutas
            // 
            this.btnEntradaRutas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEntradaRutas.FlatAppearance.BorderSize = 0;
            this.btnEntradaRutas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntradaRutas.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnEntradaRutas.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnEntradaRutas.Location = new System.Drawing.Point(0, 60);
            this.btnEntradaRutas.Name = "btnEntradaRutas";
            this.btnEntradaRutas.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnEntradaRutas.Size = new System.Drawing.Size(250, 60);
            this.btnEntradaRutas.TabIndex = 3;
            this.btnEntradaRutas.Text = "Registrar Rutas";
            this.btnEntradaRutas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEntradaRutas.UseVisualStyleBackColor = true;
            this.btnEntradaRutas.Click += new System.EventHandler(this.btnEntradaRutas_Click);
            // 
            // btnEntradaChoferes
            // 
            this.btnEntradaChoferes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEntradaChoferes.FlatAppearance.BorderSize = 0;
            this.btnEntradaChoferes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntradaChoferes.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnEntradaChoferes.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnEntradaChoferes.Location = new System.Drawing.Point(0, 0);
            this.btnEntradaChoferes.Name = "btnEntradaChoferes";
            this.btnEntradaChoferes.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnEntradaChoferes.Size = new System.Drawing.Size(250, 60);
            this.btnEntradaChoferes.TabIndex = 2;
            this.btnEntradaChoferes.Text = "Registrar Choferes";
            this.btnEntradaChoferes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEntradaChoferes.UseVisualStyleBackColor = true;
            this.btnEntradaChoferes.Click += new System.EventHandler(this.btnEntradaChoferes_Click);
            // 
            // btnMenuEntrada
            // 
            this.btnMenuEntrada.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuEntrada.FlatAppearance.BorderSize = 0;
            this.btnMenuEntrada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuEntrada.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnMenuEntrada.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnMenuEntrada.Location = new System.Drawing.Point(0, 100);
            this.btnMenuEntrada.Name = "btnMenuEntrada";
            this.btnMenuEntrada.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnMenuEntrada.Size = new System.Drawing.Size(250, 60);
            this.btnMenuEntrada.TabIndex = 9;
            this.btnMenuEntrada.Text = "ENTRADA";
            this.btnMenuEntrada.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuEntrada.UseVisualStyleBackColor = true;
            this.btnMenuEntrada.Click += new System.EventHandler(this.btnMenuEntrada_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::SistemaRecaudacionOMSA.Properties.Resources.omsa_logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(132)))), ((int)(((byte)(61)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(250, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(934, 100);
            this.panel1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(281, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(373, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "SISTEMA DE RECAUDACIÓN OMSA";
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.BackgroundImage = global::SistemaRecaudacionOMSA.Properties.Resources.omsa_logo;
            this.pnlContenedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Location = new System.Drawing.Point(250, 100);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(934, 641);
            this.pnlContenedor.TabIndex = 9;
            this.pnlContenedor.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlContenedor_Paint);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 741);
            this.Controls.Add(this.pnlContenedor);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlSidebar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Gestión OMSA - Menú Principal";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSubMenuSistema.ResumeLayout(false);
            this.pnlSubMenuConsulta.ResumeLayout(false);
            this.pnlSubMenuEntrada.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.Panel pnlSubMenuSistema;
        private System.Windows.Forms.Panel pnlSubMenuConsulta;
        private System.Windows.Forms.Panel pnlSubMenuEntrada;
        private System.Windows.Forms.Button btnMenuSistema;
        private System.Windows.Forms.Button btnMenuConsulta;
        private System.Windows.Forms.Button btnMenuEntrada;
        private System.Windows.Forms.Button btnEntradaViajes;
        private System.Windows.Forms.Button btnEntradaTickets;
        private System.Windows.Forms.Button btnEntradaVehiculos;
        private System.Windows.Forms.Button btnEntradaChoferes;
        private System.Windows.Forms.Button btnAcercaDe;
        private System.Windows.Forms.Button btnConsultaReportes;
        private System.Windows.Forms.Button btnConsultaChoferes;
        private System.Windows.Forms.Button btnConsultaViajes;
        private System.Windows.Forms.Button btnConsultaVehiculos;
        private System.Windows.Forms.Button btnConsultaRutas;
        private System.Windows.Forms.Button btnEntradaRutas;
    }
}