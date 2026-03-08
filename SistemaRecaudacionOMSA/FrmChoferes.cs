using System;
using System.Windows.Forms;
using CapaNegocios;

namespace SistemaRecaudacionOMSA
{
    public partial class FrmChoferes : Form
    {
        // Instancia de la Capa de Negocio
        private N_Chofer objNegocio = new N_Chofer();

        public FrmChoferes()
        {
            InitializeComponent();
        }

        // Evento que se ejecuta al abrir el formulario
        private void FrmChoferes_Load(object sender, EventArgs e)
        {
            MostrarChoferesTabla();
        }

        // Método para refrescar el DataGridView
        private void MostrarChoferesTabla()
        {
            dgvChoferes.DataSource = objNegocio.MostrarChoferes();
        }

        // Lógica del botón Guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // 1. Validación de seguridad: Evitar campos vacíos
            if (string.IsNullOrWhiteSpace(txtCedula.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtLicencia.Text))
            {
                MessageBox.Show("Por favor, llena todos los campos antes de guardar.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. Llamada a la Capa de Negocio
                objNegocio.InsertarChofer(txtCedula.Text, txtNombre.Text, txtLicencia.Text);

                // 3. Respuesta al usuario y actualización
                MessageBox.Show("Chofer guardado correctamente.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                MostrarChoferesTabla();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para limpiar la interfaz
        private void LimpiarCampos()
        {
            txtCedula.Clear();
            txtNombre.Clear();
            txtLicencia.Clear();
            txtCedula.Focus(); // Pone el cursor listo para el siguiente registro
        }
    }
}