namespace SistemaRecaudacionOMSA
{
    partial class FrmDashboard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tlpDashboard = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCardVehiculos = new System.Windows.Forms.Panel();
            this.lblTotalVehiculos = new System.Windows.Forms.Label();
            this.lblTituloVehiculos = new System.Windows.Forms.Label();
            this.pnlBarVehiculos = new System.Windows.Forms.Panel();
            this.pnlCardViajes = new System.Windows.Forms.Panel();
            this.lblViajesActivos = new System.Windows.Forms.Label();
            this.lblTituloViajes = new System.Windows.Forms.Label();
            this.pnlBarViajes = new System.Windows.Forms.Panel();
            this.pnlCardRecaudacion = new System.Windows.Forms.Panel();
            this.lblTotalRecaudacion = new System.Windows.Forms.Label();
            this.lblTituloRecaudacion = new System.Windows.Forms.Label();
            this.pnlBarRecaudacion = new System.Windows.Forms.Panel();
            this.pnlCardTickets = new System.Windows.Forms.Panel();
            this.lblTotalTickets = new System.Windows.Forms.Label();
            this.lblTituloTickets = new System.Windows.Forms.Label();
            this.pnlBarTickets = new System.Windows.Forms.Panel();
            this.chartVentas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tlpDashboard.SuspendLayout();
            this.pnlCardVehiculos.SuspendLayout();
            this.pnlCardViajes.SuspendLayout();
            this.pnlCardRecaudacion.SuspendLayout();
            this.pnlCardTickets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpDashboard
            // 
            this.tlpDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.tlpDashboard.ColumnCount = 4;
            this.tlpDashboard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpDashboard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpDashboard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpDashboard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpDashboard.Controls.Add(this.pnlCardVehiculos, 3, 0);
            this.tlpDashboard.Controls.Add(this.pnlCardViajes, 2, 0);
            this.tlpDashboard.Controls.Add(this.pnlCardRecaudacion, 0, 0);
            this.tlpDashboard.Controls.Add(this.pnlCardTickets, 1, 0);
            this.tlpDashboard.Controls.Add(this.chartVentas, 0, 1);
            this.tlpDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDashboard.Location = new System.Drawing.Point(0, 0);
            this.tlpDashboard.Name = "tlpDashboard";
            this.tlpDashboard.Padding = new System.Windows.Forms.Padding(20);
            this.tlpDashboard.RowCount = 1;
            this.tlpDashboard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpDashboard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDashboard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDashboard.Size = new System.Drawing.Size(918, 673);
            this.tlpDashboard.TabIndex = 0;
            // 
            // pnlCardVehiculos
            // 
            this.pnlCardVehiculos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pnlCardVehiculos.Controls.Add(this.lblTotalVehiculos);
            this.pnlCardVehiculos.Controls.Add(this.lblTituloVehiculos);
            this.pnlCardVehiculos.Controls.Add(this.pnlBarVehiculos);
            this.pnlCardVehiculos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardVehiculos.Location = new System.Drawing.Point(687, 30);
            this.pnlCardVehiculos.Margin = new System.Windows.Forms.Padding(10);
            this.pnlCardVehiculos.Name = "pnlCardVehiculos";
            this.pnlCardVehiculos.Padding = new System.Windows.Forms.Padding(15);
            this.pnlCardVehiculos.Size = new System.Drawing.Size(201, 100);
            this.pnlCardVehiculos.TabIndex = 5;
            // 
            // lblTotalVehiculos
            // 
            this.lblTotalVehiculos.AutoSize = true;
            this.lblTotalVehiculos.Font = new System.Drawing.Font("Segoe UI Semibold", 18F);
            this.lblTotalVehiculos.ForeColor = System.Drawing.Color.White;
            this.lblTotalVehiculos.Location = new System.Drawing.Point(78, 44);
            this.lblTotalVehiculos.Name = "lblTotalVehiculos";
            this.lblTotalVehiculos.Size = new System.Drawing.Size(59, 32);
            this.lblTotalVehiculos.TabIndex = 3;
            this.lblTotalVehiculos.Text = "0.00";
            // 
            // lblTituloVehiculos
            // 
            this.lblTituloVehiculos.AutoSize = true;
            this.lblTituloVehiculos.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTituloVehiculos.ForeColor = System.Drawing.Color.DarkGray;
            this.lblTituloVehiculos.Location = new System.Drawing.Point(57, 15);
            this.lblTituloVehiculos.Name = "lblTituloVehiculos";
            this.lblTituloVehiculos.Size = new System.Drawing.Size(106, 15);
            this.lblTituloVehiculos.TabIndex = 2;
            this.lblTituloVehiculos.Text = "TOTAL VEHÍCULOS";
            // 
            // pnlBarVehiculos
            // 
            this.pnlBarVehiculos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.pnlBarVehiculos.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBarVehiculos.Location = new System.Drawing.Point(15, 15);
            this.pnlBarVehiculos.Name = "pnlBarVehiculos";
            this.pnlBarVehiculos.Size = new System.Drawing.Size(5, 70);
            this.pnlBarVehiculos.TabIndex = 1;
            // 
            // pnlCardViajes
            // 
            this.pnlCardViajes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pnlCardViajes.Controls.Add(this.lblViajesActivos);
            this.pnlCardViajes.Controls.Add(this.lblTituloViajes);
            this.pnlCardViajes.Controls.Add(this.pnlBarViajes);
            this.pnlCardViajes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardViajes.Location = new System.Drawing.Point(468, 30);
            this.pnlCardViajes.Margin = new System.Windows.Forms.Padding(10);
            this.pnlCardViajes.Name = "pnlCardViajes";
            this.pnlCardViajes.Padding = new System.Windows.Forms.Padding(15);
            this.pnlCardViajes.Size = new System.Drawing.Size(199, 100);
            this.pnlCardViajes.TabIndex = 4;
            // 
            // lblViajesActivos
            // 
            this.lblViajesActivos.AutoSize = true;
            this.lblViajesActivos.Font = new System.Drawing.Font("Segoe UI Semibold", 18F);
            this.lblViajesActivos.ForeColor = System.Drawing.Color.White;
            this.lblViajesActivos.Location = new System.Drawing.Point(79, 44);
            this.lblViajesActivos.Name = "lblViajesActivos";
            this.lblViajesActivos.Size = new System.Drawing.Size(59, 32);
            this.lblViajesActivos.TabIndex = 3;
            this.lblViajesActivos.Text = "0.00";
            // 
            // lblTituloViajes
            // 
            this.lblTituloViajes.AutoSize = true;
            this.lblTituloViajes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTituloViajes.ForeColor = System.Drawing.Color.DarkGray;
            this.lblTituloViajes.Location = new System.Drawing.Point(64, 15);
            this.lblTituloViajes.Name = "lblTituloViajes";
            this.lblTituloViajes.Size = new System.Drawing.Size(93, 15);
            this.lblTituloViajes.TabIndex = 2;
            this.lblTituloViajes.Text = "VIAJES ACTIVOS";
            // 
            // pnlBarViajes
            // 
            this.pnlBarViajes.BackColor = System.Drawing.Color.Purple;
            this.pnlBarViajes.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBarViajes.Location = new System.Drawing.Point(15, 15);
            this.pnlBarViajes.Name = "pnlBarViajes";
            this.pnlBarViajes.Size = new System.Drawing.Size(5, 70);
            this.pnlBarViajes.TabIndex = 1;
            // 
            // pnlCardRecaudacion
            // 
            this.pnlCardRecaudacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pnlCardRecaudacion.Controls.Add(this.lblTotalRecaudacion);
            this.pnlCardRecaudacion.Controls.Add(this.lblTituloRecaudacion);
            this.pnlCardRecaudacion.Controls.Add(this.pnlBarRecaudacion);
            this.pnlCardRecaudacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardRecaudacion.Location = new System.Drawing.Point(30, 30);
            this.pnlCardRecaudacion.Margin = new System.Windows.Forms.Padding(10);
            this.pnlCardRecaudacion.Name = "pnlCardRecaudacion";
            this.pnlCardRecaudacion.Padding = new System.Windows.Forms.Padding(15);
            this.pnlCardRecaudacion.Size = new System.Drawing.Size(199, 100);
            this.pnlCardRecaudacion.TabIndex = 1;
            // 
            // lblTotalRecaudacion
            // 
            this.lblTotalRecaudacion.AutoSize = true;
            this.lblTotalRecaudacion.Font = new System.Drawing.Font("Segoe UI Semibold", 18F);
            this.lblTotalRecaudacion.ForeColor = System.Drawing.Color.White;
            this.lblTotalRecaudacion.Location = new System.Drawing.Point(52, 44);
            this.lblTotalRecaudacion.Name = "lblTotalRecaudacion";
            this.lblTotalRecaudacion.Size = new System.Drawing.Size(111, 32);
            this.lblTotalRecaudacion.TabIndex = 2;
            this.lblTotalRecaudacion.Text = "RD$ 0.00";
            // 
            // lblTituloRecaudacion
            // 
            this.lblTituloRecaudacion.AutoSize = true;
            this.lblTituloRecaudacion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTituloRecaudacion.ForeColor = System.Drawing.Color.DarkGray;
            this.lblTituloRecaudacion.Location = new System.Drawing.Point(55, 15);
            this.lblTituloRecaudacion.Name = "lblTituloRecaudacion";
            this.lblTituloRecaudacion.Size = new System.Drawing.Size(117, 15);
            this.lblTituloRecaudacion.TabIndex = 1;
            this.lblTituloRecaudacion.Text = "RECAUDACIÓN HOY";
            // 
            // pnlBarRecaudacion
            // 
            this.pnlBarRecaudacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.pnlBarRecaudacion.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBarRecaudacion.Location = new System.Drawing.Point(15, 15);
            this.pnlBarRecaudacion.Name = "pnlBarRecaudacion";
            this.pnlBarRecaudacion.Size = new System.Drawing.Size(5, 70);
            this.pnlBarRecaudacion.TabIndex = 0;
            // 
            // pnlCardTickets
            // 
            this.pnlCardTickets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pnlCardTickets.Controls.Add(this.lblTotalTickets);
            this.pnlCardTickets.Controls.Add(this.lblTituloTickets);
            this.pnlCardTickets.Controls.Add(this.pnlBarTickets);
            this.pnlCardTickets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardTickets.Location = new System.Drawing.Point(249, 30);
            this.pnlCardTickets.Margin = new System.Windows.Forms.Padding(10);
            this.pnlCardTickets.Name = "pnlCardTickets";
            this.pnlCardTickets.Padding = new System.Windows.Forms.Padding(15);
            this.pnlCardTickets.Size = new System.Drawing.Size(199, 100);
            this.pnlCardTickets.TabIndex = 3;
            // 
            // lblTotalTickets
            // 
            this.lblTotalTickets.AutoSize = true;
            this.lblTotalTickets.Font = new System.Drawing.Font("Segoe UI Semibold", 18F);
            this.lblTotalTickets.ForeColor = System.Drawing.Color.White;
            this.lblTotalTickets.Location = new System.Drawing.Point(75, 44);
            this.lblTotalTickets.Name = "lblTotalTickets";
            this.lblTotalTickets.Size = new System.Drawing.Size(59, 32);
            this.lblTotalTickets.TabIndex = 3;
            this.lblTotalTickets.Text = "0.00";
            // 
            // lblTituloTickets
            // 
            this.lblTituloTickets.AutoSize = true;
            this.lblTituloTickets.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTituloTickets.ForeColor = System.Drawing.Color.DarkGray;
            this.lblTituloTickets.Location = new System.Drawing.Point(53, 15);
            this.lblTituloTickets.Name = "lblTituloTickets";
            this.lblTituloTickets.Size = new System.Drawing.Size(110, 15);
            this.lblTituloTickets.TabIndex = 2;
            this.lblTituloTickets.Text = "TICKETS VENDIDOS";
            // 
            // pnlBarTickets
            // 
            this.pnlBarTickets.BackColor = System.Drawing.Color.Blue;
            this.pnlBarTickets.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBarTickets.Location = new System.Drawing.Point(15, 15);
            this.pnlBarTickets.Name = "pnlBarTickets";
            this.pnlBarTickets.Size = new System.Drawing.Size(5, 70);
            this.pnlBarTickets.TabIndex = 1;
            // 
            // chartVentas
            // 
            this.chartVentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            chartArea1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            chartArea1.Name = "ChartArea1";
            this.chartVentas.ChartAreas.Add(chartArea1);
            this.tlpDashboard.SetColumnSpan(this.chartVentas, 4);
            this.chartVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartVentas.Location = new System.Drawing.Point(23, 143);
            this.chartVentas.Name = "chartVentas";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            series1.Name = "Series1";
            this.chartVentas.Series.Add(series1);
            this.chartVentas.Size = new System.Drawing.Size(872, 507);
            this.chartVentas.TabIndex = 6;
            this.chartVentas.Text = "chart1";
            // 
            // FrmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(918, 673);
            this.Controls.Add(this.tlpDashboard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDashboard";
            this.Text = "FrmDashboard";
            this.tlpDashboard.ResumeLayout(false);
            this.pnlCardVehiculos.ResumeLayout(false);
            this.pnlCardVehiculos.PerformLayout();
            this.pnlCardViajes.ResumeLayout(false);
            this.pnlCardViajes.PerformLayout();
            this.pnlCardRecaudacion.ResumeLayout(false);
            this.pnlCardRecaudacion.PerformLayout();
            this.pnlCardTickets.ResumeLayout(false);
            this.pnlCardTickets.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpDashboard;
        private System.Windows.Forms.Panel pnlCardRecaudacion;
        private System.Windows.Forms.Panel pnlCardTickets;
        private System.Windows.Forms.Panel pnlCardVehiculos;
        private System.Windows.Forms.Label lblTotalVehiculos;
        private System.Windows.Forms.Label lblTituloVehiculos;
        private System.Windows.Forms.Panel pnlBarVehiculos;
        private System.Windows.Forms.Panel pnlCardViajes;
        private System.Windows.Forms.Label lblViajesActivos;
        private System.Windows.Forms.Label lblTituloViajes;
        private System.Windows.Forms.Panel pnlBarViajes;
        private System.Windows.Forms.Label lblTotalRecaudacion;
        private System.Windows.Forms.Label lblTituloRecaudacion;
        private System.Windows.Forms.Panel pnlBarRecaudacion;
        private System.Windows.Forms.Label lblTotalTickets;
        private System.Windows.Forms.Label lblTituloTickets;
        private System.Windows.Forms.Panel pnlBarTickets;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVentas;
    }
}