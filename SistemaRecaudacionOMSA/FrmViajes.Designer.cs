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
            this.cmbChofer = new System.Windows.Forms.ComboBox();
            this.cmbRuta = new System.Windows.Forms.ComboBox();
            this.cmbVehiculo = new System.Windows.Forms.ComboBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGuardarViaje = new System.Windows.Forms.Button();
            this.dgvViajes = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViajes)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbChofer
            // 
            this.cmbChofer.FormattingEnabled = true;
            this.cmbChofer.Location = new System.Drawing.Point(55, 49);
            this.cmbChofer.Name = "cmbChofer";
            this.cmbChofer.Size = new System.Drawing.Size(121, 21);
            this.cmbChofer.TabIndex = 0;
            // 
            // cmbRuta
            // 
            this.cmbRuta.FormattingEnabled = true;
            this.cmbRuta.Location = new System.Drawing.Point(55, 127);
            this.cmbRuta.Name = "cmbRuta";
            this.cmbRuta.Size = new System.Drawing.Size(121, 21);
            this.cmbRuta.TabIndex = 1;
            // 
            // cmbVehiculo
            // 
            this.cmbVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVehiculo.FormattingEnabled = true;
            this.cmbVehiculo.Location = new System.Drawing.Point(55, 205);
            this.cmbVehiculo.Name = "cmbVehiculo";
            this.cmbVehiculo.Size = new System.Drawing.Size(121, 21);
            this.cmbVehiculo.TabIndex = 2;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(55, 280);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 20);
            this.dtpFecha.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Seleccione Chofer:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Seleccione Ruta:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Seleccione Vehículo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Fecha del Viaje:";
            // 
            // btnGuardarViaje
            // 
            this.btnGuardarViaje.Location = new System.Drawing.Point(55, 404);
            this.btnGuardarViaje.Name = "btnGuardarViaje";
            this.btnGuardarViaje.Size = new System.Drawing.Size(99, 23);
            this.btnGuardarViaje.TabIndex = 10;
            this.btnGuardarViaje.Text = "Registrar Viaje";
            this.btnGuardarViaje.UseVisualStyleBackColor = true;
            this.btnGuardarViaje.Click += new System.EventHandler(this.btnGuardarViaje_Click);
            // 
            // dgvViajes
            // 
            this.dgvViajes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViajes.Location = new System.Drawing.Point(261, 24);
            this.dgvViajes.Name = "dgvViajes";
            this.dgvViajes.Size = new System.Drawing.Size(612, 465);
            this.dgvViajes.TabIndex = 11;
            this.dgvViajes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvViajes_CellContentClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 330);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Estado del Viaje:";
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(58, 363);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(118, 20);
            this.txtEstado.TabIndex = 13;
            // 
            // FrmViajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 501);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvViajes);
            this.Controls.Add(this.btnGuardarViaje);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.cmbVehiculo);
            this.Controls.Add(this.cmbRuta);
            this.Controls.Add(this.cmbChofer);
            this.Name = "FrmViajes";
            this.Text = "FrmViajes";
            this.Load += new System.EventHandler(this.FrmViajes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvViajes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbChofer;
        private System.Windows.Forms.ComboBox cmbRuta;
        private System.Windows.Forms.ComboBox cmbVehiculo;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGuardarViaje;
        private System.Windows.Forms.DataGridView dgvViajes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEstado;
    }
}