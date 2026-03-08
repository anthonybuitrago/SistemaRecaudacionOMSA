using System;
using System.Windows.Forms;
using CapaNegocios;

namespace SistemaRecaudacionOMSA
{
    public partial class FrmTickets : Form
    {
        // Instancias de Negocio
        private N_Viaje objViaje = new N_Viaje();
        private N_Ticket objTicket = new N_Ticket();

        public FrmTickets()
        {
            InitializeComponent();
        }

        private void FrmTickets_Load(object sender, EventArgs e)
        {
            LlenarComboViajes();
        }

        // Carga los viajes activos para que el cajero seleccione uno
        private void LlenarComboViajes()
        {
            try
            {
                cmbViaje.DataSource = objViaje.MostrarViajes();
                cmbViaje.DisplayMember = "ID_Viaje"; // Lo que ve el usuario
                cmbViaje.ValueMember = "ID_Viaje";   // El valor real que guardamos
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar viajes: " + ex.Message);
            }
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            // 1. Validación de entrada
            if (string.IsNullOrWhiteSpace(txtMonto.Text))
            {
                MessageBox.Show("Por favor, ingresa el monto pagado por el pasajero.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. Captura de datos de la interfaz
                string idViaje = cmbViaje.SelectedValue.ToString();
                string monto = txtMonto.Text;

                // 3. Procesar venta a través de la Capa de Negocio
                objTicket.InsertarTicket(idViaje, monto);

                // 4. Éxito y limpieza
                MessageBox.Show("¡Ticket emitido correctamente!", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la venta: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtMonto.Clear();
            txtMonto.Focus();
        }
    }
}