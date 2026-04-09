using CapaNegocios;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaRecaudacionOMSA
{
    // Formulario de autenticación para el acceso al sistema
    public partial class FrmLogin : Form
    {
        private N_Usuario negocio = new N_Usuario();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
            txtUsuario.Focus();
        }

        // Procesa la solicitud de acceso al sistema
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtClave.Text))
            {
                lblError.Text = "Por favor complete todos los campos.";
                lblError.Visible = true;
                return;
            }

            // Validación de credenciales en la capa de datos
            bool acceso = negocio.ValidarUsuario(txtUsuario.Text, txtClave.Text);

            if (acceso)
            {
                // TODO: [REQUISITO] - El usuario entra al programa, la validación se hace y se cierra el login
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                lblError.Text = "Usuario o contraseña incorrectos.";
                lblError.Visible = true;
                txtClave.Clear();
                txtClave.Focus();
            }
        }

        // TODO: [REQUISITO] - El usuario puede dar Enter luego de colocar el password para ingresar
        // Detecta si se presiona la tecla Enter estando en el campo de contraseña
        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Evita el sonido de "beep" de Windows
                btnIngresar_Click(sender, e);
            }
        }
    }
}