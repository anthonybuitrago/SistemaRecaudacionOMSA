using OMSA_Recaudacion.CapaNegocio;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmLogin : Form
    {
        // Instancia de la capa de negocio para validar credenciales
        N_Usuario negocio = new N_Usuario();

        public FrmLogin()
        {
            InitializeComponent();
        }

        // Al cargar el formulario ocultamos el mensaje de error
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
            txtUsuario.Focus(); // El cursor inicia en el campo usuario
        }

        // Evento del botón Ingresar
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // Validar que los campos no estén vacíos
            if (string.IsNullOrEmpty(txtUsuario.Text) ||
                string.IsNullOrEmpty(txtClave.Text))
            {
                lblError.Text = "Por favor complete todos los campos.";
                lblError.Visible = true;
                return;
            }

            // Validar credenciales contra la base de datos
            bool acceso = negocio.ValidarUsuario(txtUsuario.Text, txtClave.Text);

            if (acceso)
            {
                // Condición 17: cierra el login y deja abierto el principal
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                // Muestra error si las credenciales son incorrectas
                lblError.Text = "Usuario o contraseña incorrectos.";
                lblError.Visible = true;
                txtClave.Clear();
                txtClave.Focus();
            }
        }

        // Condición 13: permite presionar Enter desde el campo contraseña
        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnIngresar_Click(sender, e);
            }
        }

        private void lblError_Click(object sender, EventArgs e)
        {

        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblSubtitulo_Click(object sender, EventArgs e)
        {

        }
    }
}