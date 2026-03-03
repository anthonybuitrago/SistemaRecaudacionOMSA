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
            this.label1 = new System.Windows.Forms.Label();
            this.btnAbrirChoferes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(307, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sistema de Recaudación OMSA";
            // 
            // btnAbrirChoferes
            // 
            this.btnAbrirChoferes.Location = new System.Drawing.Point(332, 89);
            this.btnAbrirChoferes.Name = "btnAbrirChoferes";
            this.btnAbrirChoferes.Size = new System.Drawing.Size(117, 23);
            this.btnAbrirChoferes.TabIndex = 1;
            this.btnAbrirChoferes.Text = "Gestión de Choferes";
            this.btnAbrirChoferes.UseVisualStyleBackColor = true;
            this.btnAbrirChoferes.Click += new System.EventHandler(this.btnAbrirChoferes_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAbrirChoferes);
            this.Controls.Add(this.label1);
            this.Name = "FrmPrincipal";
            this.Text = "FrmPrincipal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAbrirChoferes;
    }
}