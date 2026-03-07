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
            this.cmbViaje = new System.Windows.Forms.ComboBox();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.btnVender = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbViaje
            // 
            this.cmbViaje.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbViaje.FormattingEnabled = true;
            this.cmbViaje.Location = new System.Drawing.Point(344, 90);
            this.cmbViaje.Name = "cmbViaje";
            this.cmbViaje.Size = new System.Drawing.Size(121, 21);
            this.cmbViaje.TabIndex = 0;
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(353, 169);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(100, 20);
            this.txtMonto.TabIndex = 1;
            // 
            // btnVender
            // 
            this.btnVender.Location = new System.Drawing.Point(353, 233);
            this.btnVender.Name = "btnVender";
            this.btnVender.Size = new System.Drawing.Size(102, 23);
            this.btnVender.TabIndex = 2;
            this.btnVender.Text = "Registrar Venta";
            this.btnVender.UseVisualStyleBackColor = true;
            this.btnVender.Click += new System.EventHandler(this.btnVender_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(350, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Monto a Pagar";
            // 
            // FrmTickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnVender);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.cmbViaje);
            this.Name = "FrmTickets";
            this.Text = "FrmTickets";
            this.Load += new System.EventHandler(this.FrmTickets_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbViaje;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Button btnVender;
        private System.Windows.Forms.Label label1;
    }
}