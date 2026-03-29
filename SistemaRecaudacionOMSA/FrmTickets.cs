using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks; // Obligatorio para Task
using System.Windows.Forms;

namespace SistemaRecaudacionOMSA
{
    public partial class FrmTickets : Form
    {
        // Instancias de las clases de negocio necesarias
        private N_Ticket objTicket = new N_Ticket();
        private N_Viaje objViaje = new N_Viaje();
        private int idTicket = 0;

        // Constructor que inicializa los componentes de la ventana
        public FrmTickets()
        {
            InitializeComponent();
        }

        // Evento ASÍNCRONO que carga los datos iniciales al abrir la ventana
        private async void FrmTickets_Load(object sender, EventArgs e)
        {
            await CargarViajesAsync();
            await MostrarTicketsTablaAsync();
            BloquearCampos(); // Los campos arrancan desactivados
        }

        // Método ASÍNCRONO para solicitar y listar los tickets vendidos
        private async Task MostrarTicketsTablaAsync()
        {
            try
            {
                dgvTickets.DataSource = await objTicket.MostrarTicketsAsync();
                AplicarEstiloTabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar tickets: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método ASÍNCRONO para llenar el selector (ComboBox) con los viajes activos
        private async Task CargarViajesAsync()
        {
            try
            {
                // Vinculación asíncrona de datos con el selector de viajes
                cmbViaje.DataSource = await objViaje.MostrarViajesComboAsync();
                cmbViaje.DisplayMember = "DescripcionViaje";
                cmbViaje.ValueMember = "ID_Viaje";

                // Reiniciar selección por defecto
                cmbViaje.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar viajes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento ASÍNCRONO para procesar y registrar la emisión de un nuevo ticket
        private async void btnVender_Click(object sender, EventArgs e)
        {
            // Validación de entrada de datos y selección
            if (string.IsNullOrWhiteSpace(txtMonto.Text))
            {
                MessageBox.Show("Por favor, ingrese el monto del ticket.", "Aviso OMSA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbViaje.SelectedValue == null)
            {
                MessageBox.Show("No hay un viaje seleccionado.", "Error de Selección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Envío asíncrono de datos a la Capa de Negocio
                string idViaje = cmbViaje.SelectedValue.ToString();
                string monto = txtMonto.Text;

                await objTicket.InsertarTicketAsync(idViaje, monto);
                MessageBox.Show("¡Ticket emitido correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await MostrarTicketsTablaAsync();
                btnLimpiar.PerformClick(); // Limpia y vuelve a bloquear
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al vender: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- LÓGICA DE INTERFAZ: BLOQUEO Y HABILITACIÓN ---

        private void BloquearCampos()
        {
            cmbViaje.Enabled = false;
            txtMonto.Enabled = false;
            btnVender.Enabled = false;
        }

        private void HabilitarCampos()
        {
            cmbViaje.Enabled = true;
            txtMonto.Enabled = true;
            btnVender.Enabled = true;
        }

        // Evento para reiniciar manualmente el formulario (Botón "Nuevo Ticket")
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cmbViaje.SelectedIndex = -1;
            txtMonto.Clear();
            idTicket = 0;

            HabilitarCampos();
            cmbViaje.Focus();
        }

        // Método para personalizar la apariencia visual de la tabla
        private void AplicarEstiloTabla()
        {
            dgvTickets.AllowUserToAddRows = false;
            dgvTickets.RowHeadersVisible = false;
            dgvTickets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTickets.BackgroundColor = Color.White;
            dgvTickets.BorderStyle = BorderStyle.None;
            dgvTickets.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTickets.GridColor = Color.Gainsboro;

            dgvTickets.EnableHeadersVisualStyles = false;
            dgvTickets.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#404040");
            dgvTickets.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTickets.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvTickets.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#404040");
            dgvTickets.ColumnHeadersHeight = 40;
            dgvTickets.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgvTickets.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvTickets.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#E0F2E9");
            dgvTickets.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvTickets.RowTemplate.Height = 35;

            if (dgvTickets.Columns.Count > 0)
            {
                if (dgvTickets.Columns.Contains("ID_Ticket")) dgvTickets.Columns["ID_Ticket"].HeaderText = "No. Ticket";
                if (dgvTickets.Columns.Contains("ID_Viaje")) dgvTickets.Columns["ID_Viaje"].HeaderText = "ID Viaje";
                if (dgvTickets.Columns.Contains("HoraEmision")) dgvTickets.Columns["HoraEmision"].HeaderText = "Fecha/Hora";
                if (dgvTickets.Columns.Contains("MontoPagado")) dgvTickets.Columns["MontoPagado"].HeaderText = "Monto (RD$)";
            }
        }

        private void dgvTickets_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // En tickets usualmente no permitimos edición por seguridad de caja.
        }
    }
}