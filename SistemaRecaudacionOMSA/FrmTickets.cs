using System;
using System.Windows.Forms;
using CapaNegocios;

namespace SistemaRecaudacionOMSA
{
    public partial class FrmTickets : Form
    {
        private N_Viaje objViaje = new N_Viaje();

        public FrmTickets()
        {
            InitializeComponent();
        }

        private void FrmTickets_Load(object sender, EventArgs e)
        {
            LlenarComboViajes();
        }

        private void LlenarComboViajes()
        {
            cmbViaje.DataSource = objViaje.MostrarViajes();
            cmbViaje.DisplayMember = "ID_Viaje";
            cmbViaje.ValueMember = "ID_Viaje";
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMonto.Text))
            {
                MessageBox.Show("Por favor, ingresa el monto pagado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string idViaje = cmbViaje.SelectedValue.ToString();
                string monto = txtMonto.Text;

                N_Ticket objTicket = new N_Ticket();
                objTicket.InsertarTicket(idViaje, monto);

                MessageBox.Show("¡Ticket vendido y registrado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMonto.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al vender el ticket: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}