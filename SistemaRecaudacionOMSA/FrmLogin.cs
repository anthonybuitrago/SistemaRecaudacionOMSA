using CapaNegocios;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaRecaudacionOMSA
{
    // Formulario de autenticación para el acceso al sistema
    public partial class FrmLogin : Form
    {
        // Instancia de la capa de negocios
        private N_Usuario negocio = new N_Usuario();

        public FrmLogin()
        {
            InitializeComponent();
        }

        // Inicialización de la interfaz de login
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
            txtUsuario.Focus();
        }

        // ==========================================================
        // AUTENTICACIÓN Y VALIDACIÓN
        // ==========================================================

        // TODO: [REQUISITO] - El Login se cierra al validar y transfiere el control al Formulario Principal.

        // Procesa la solicitud de acceso al sistema
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // Validación de campos obligatorios
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtClave.Text))
            {
                lblError.Text = "Por favor complete todos los campos.";
                lblError.Visible = true;
                return;
            }

            // Delegación de validación de credenciales a la capa de negocios
            bool acceso = negocio.ValidarUsuario(txtUsuario.Text, txtClave.Text);

            if (acceso)
            {
                // Credenciales válidas: se aprueba el acceso y se transfiere el control a Program.cs
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                // Credenciales inválidas: alerta visual y limpieza del campo de seguridad
                lblError.Text = "Usuario o contraseña incorrectos.";
                lblError.Visible = true;
                txtClave.Clear();
                txtClave.Focus();
            }
        }

        // ==========================================================
        // EVENTOS DE TECLADO
        // ==========================================================

        // Permite ejecutar el inicio de sesión presionando la tecla Enter
        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Intercepta la tecla para evitar el sonido de alerta de Windows
                btnIngresar_Click(sender, e);
            }
        }
    }
}