namespace SistemaRecaudacionOMSA
{
    partial class FrmAcercaDe
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
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblCreditos = new System.Windows.Forms.Label();
            this.lblAnthony = new System.Windows.Forms.Label();
            this.lblElvis = new System.Windows.Forms.Label();
            this.lblEduardo = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblVersion.ForeColor = System.Drawing.Color.White;
            this.lblVersion.Location = new System.Drawing.Point(823, 680);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(99, 23);
            this.lblVersion.TabIndex = 3;
            this.lblVersion.Text = "Versión 1.0.0";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCreditos
            // 
            this.lblCreditos.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCreditos.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblCreditos.ForeColor = System.Drawing.Color.White;
            this.lblCreditos.Location = new System.Drawing.Point(342, 331);
            this.lblCreditos.Name = "lblCreditos";
            this.lblCreditos.Size = new System.Drawing.Size(203, 45);
            this.lblCreditos.TabIndex = 4;
            this.lblCreditos.Text = "Desarrollado por:";
            this.lblCreditos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAnthony
            // 
            this.lblAnthony.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblAnthony.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblAnthony.ForeColor = System.Drawing.Color.White;
            this.lblAnthony.Location = new System.Drawing.Point(342, 446);
            this.lblAnthony.Name = "lblAnthony";
            this.lblAnthony.Size = new System.Drawing.Size(203, 23);
            this.lblAnthony.TabIndex = 5;
            this.lblAnthony.Text = "Anthony Buitrago";
            this.lblAnthony.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblElvis
            // 
            this.lblElvis.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblElvis.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblElvis.ForeColor = System.Drawing.Color.White;
            this.lblElvis.Location = new System.Drawing.Point(342, 415);
            this.lblElvis.Name = "lblElvis";
            this.lblElvis.Size = new System.Drawing.Size(203, 23);
            this.lblElvis.TabIndex = 6;
            this.lblElvis.Text = "Elvis Baez";
            this.lblElvis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEduardo
            // 
            this.lblEduardo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblEduardo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblEduardo.ForeColor = System.Drawing.Color.White;
            this.lblEduardo.Location = new System.Drawing.Point(342, 384);
            this.lblEduardo.Name = "lblEduardo";
            this.lblEduardo.Size = new System.Drawing.Size(203, 23);
            this.lblEduardo.TabIndex = 7;
            this.lblEduardo.Text = "Eduardo Soto";
            this.lblEduardo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = global::SistemaRecaudacionOMSA.Properties.Resources.omsa_logo;
            this.pictureBox1.Location = new System.Drawing.Point(342, 205);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(203, 123);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // FrmAcercaDe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(934, 712);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblEduardo);
            this.Controls.Add(this.lblElvis);
            this.Controls.Add(this.lblAnthony);
            this.Controls.Add(this.lblCreditos);
            this.Controls.Add(this.lblVersion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAcercaDe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acerca del Sistema de Recaudación OMSA";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblCreditos;
        private System.Windows.Forms.Label lblAnthony;
        private System.Windows.Forms.Label lblElvis;
        private System.Windows.Forms.Label lblEduardo;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}