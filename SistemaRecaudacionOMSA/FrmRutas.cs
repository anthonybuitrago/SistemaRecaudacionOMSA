using System;
using System.Windows.Forms;
using CapaNegocios;

namespace SistemaRecaudacionOMSA
{
    public partial class FrmRutas : Form
    {
        // Instancia de la Capa de Negocio para Rutas
        private N_Ruta objNegocio = new N_Ruta();

        public FrmRutas()
        {
            InitializeComponent();
        }

        private void FrmRutas_Load(object sender, EventArgs e)
        {
            MostrarRutasTabla();
        }

        // Método para llenar el DataGridView con las rutas existentes
        private void MostrarRutasTabla()
        {
            dgvRutas.DataSource = objNegocio.MostrarRutas();
        }

        private void btnGuardarRuta_Click(object sender, EventArgs e)
        {
            // 1. Validación de campos obligatorios
            if (string.IsNullOrWhiteSpace(txtNombreRuta.Text) || string.IsNullOrWhiteSpace(txtDetalle.Text))
            {
                MessageBox.Show("Por favor, llena todos los campos de la ruta.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. Ejecutar la inserción a través de la Capa de Negocio
                objNegocio.InsertarRuta(txtNombreRuta.Text, txtDetalle.Text);

                // 3. Confirmación y limpieza
                MessageBox.Show("Ruta guardada exitosamente.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                MostrarRutasTabla();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al procesar la ruta: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para resetear la interfaz después de guardar
        private void LimpiarCampos()
        {
            txtNombreRuta.Clear();
            txtDetalle.Clear();
            txtNombreRuta.Focus();
        }
    }
}