namespace CapaPresentacion
{
    partial class FrmLogin
    {
        private System.ComponentModel.IContainer components = null;

        // Declaración de controles
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Label lblError;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblClave = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();

            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();

            // =============================================
            // PANEL HEADER
            // =============================================
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(28, 58, 92);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Size = new System.Drawing.Size(364, 110);
            this.pnlHeader.Controls.Add(this.lblSubtitulo);
            this.pnlHeader.Controls.Add(this.lblTitulo);

            // =============================================
            // LABEL TITULO
            // =============================================
            this.lblTitulo.Text = "Sistema OMSA";
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Size = new System.Drawing.Size(364, 70);

            // =============================================
            // LABEL SUBTITULO
            // =============================================
            this.lblSubtitulo.Text = "Recaudación";
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.Silver;
            this.lblSubtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSubtitulo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblSubtitulo.Size = new System.Drawing.Size(364, 30);

            // =============================================
            // LABEL USUARIO
            // =============================================
            this.lblUsuario.Text = "Usuario";
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblUsuario.Location = new System.Drawing.Point(40, 130);
            this.lblUsuario.Size = new System.Drawing.Size(300, 20);

            // =============================================
            // TEXTBOX USUARIO
            // =============================================
            this.txtUsuario.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUsuario.Location = new System.Drawing.Point(40, 152);
            this.txtUsuario.Size = new System.Drawing.Size(300, 25);
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // =============================================
            // LABEL CLAVE
            // =============================================
            this.lblClave.Text = "Contraseña";
            this.lblClave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblClave.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblClave.Location = new System.Drawing.Point(40, 200);
            this.lblClave.Size = new System.Drawing.Size(300, 20);

            // =============================================
            // TEXTBOX CLAVE (Condición 13 - contraseña oculta)
            // =============================================
            this.txtClave.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtClave.Location = new System.Drawing.Point(40, 222);
            this.txtClave.Size = new System.Drawing.Size(300, 25);
            this.txtClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClave.UseSystemPasswordChar = true;
            this.txtClave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClave_KeyPress);

            // =============================================
            // BOTON INGRESAR
            // =============================================
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnIngresar.Location = new System.Drawing.Point(40, 275);
            this.btnIngresar.Size = new System.Drawing.Size(300, 38);
            this.btnIngresar.BackColor = System.Drawing.Color.FromArgb(28, 58, 92);
            this.btnIngresar.ForeColor = System.Drawing.Color.White;
            this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresar.FlatAppearance.BorderSize = 0;
            this.btnIngresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);

            // =============================================
            // LABEL ERROR
            // =============================================
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(40, 325);
            this.lblError.Size = new System.Drawing.Size(300, 20);
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblError.Visible = false;

            // =============================================
            // FRLOGIN (formulario)
            // =============================================
            this.Text = "Sistema OMSA - Recaudación";
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(364, 381);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmLogin_Load);

            // Agregar controles al formulario
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblClave);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.lblError);

            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}