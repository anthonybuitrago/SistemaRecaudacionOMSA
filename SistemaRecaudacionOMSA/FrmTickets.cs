using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
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

        // Evento que carga los datos iniciales al abrir la ventana
        private void FrmTickets_Load(object sender, EventArgs e)
        {
            CargarViajes();
            MostrarTicketsTabla();
            LimpiarCampos();
        }

        // Método para solicitar y listar los tickets vendidos en la tabla
        private void MostrarTicketsTabla()
        {
            dgvTickets.DataSource = objTicket.MostrarTickets();
            AplicarEstiloTabla();
        }

        // Método para llenar el selector (ComboBox) con los viajes activos legibles
        private void CargarViajes()
        {
            try
            {
                // Vinculación de datos con el selector de viajes
                cmbViaje.DataSource = objViaje.MostrarViajesCombo();
                cmbViaje.DisplayMember = "DescripcionViaje";
                cmbViaje.ValueMember = "ID_Viaje";

                // Reiniciar selección por defecto
                cmbViaje.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar viajes: " + ex.Message);
            }
        }

        // Evento para procesar y registrar la emisión de un nuevo ticket
        private void btnVender_Click(object sender, EventArgs e)
        {
            // Validación de entrada de datos y selección
            if (string.IsNullOrWhiteSpace(txtMonto.Text))
            {
                MessageBox.Show("Por favor, ingrese el monto del ticket.", "Aviso OMSA");
                return;
            }

            if (cmbViaje.SelectedValue == null)
            {
                MessageBox.Show("No hay un viaje seleccionado. Asegúrese de que existan viajes registrados.", "Error de Selección");
                return;
            }

            try
            {
                // Envío de datos a la Capa de Negocio para su inserción
                string idViaje = cmbViaje.SelectedValue.ToString();
                string monto = txtMonto.Text;

                objTicket.InsertarTicket(idViaje, monto);
                MessageBox.Show("¡Ticket emitido correctamente!", "Éxito");

                MostrarTicketsTabla();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al vender: " + ex.Message);
            }
        }

        // Evento para reiniciar manualmente los campos del formulario
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cmbViaje.SelectedIndex = -1;
            txtMonto.Clear();
            cmbViaje.Focus();
        }

        // Método interno para vaciar cajas de texto y resetear el selector
        private void LimpiarCampos()
        {
            if (cmbViaje.Items.Count > 0) cmbViaje.SelectedIndex = 0;
            txtMonto.Clear();
            idTicket = 0;
            txtMonto.Focus();
        }

        // Método para personalizar la apariencia visual y corporativa de la tabla
        private void AplicarEstiloTabla()
        {
            // Configuración de estructura y bordes
            dgvTickets.AllowUserToAddRows = false;
            dgvTickets.RowHeadersVisible = false;
            dgvTickets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTickets.BackgroundColor = Color.White;
            dgvTickets.BorderStyle = BorderStyle.None;
            dgvTickets.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTickets.GridColor = Color.Gainsboro;

            // Configuración de colores corporativos para los encabezados
            dgvTickets.EnableHeadersVisualStyles = false;
            dgvTickets.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#404040");
            dgvTickets.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTickets.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvTickets.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#404040");
            dgvTickets.ColumnHeadersHeight = 40;
            dgvTickets.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Configuración visual de las filas y colores de selección
            dgvTickets.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvTickets.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#E0F2E9");
            dgvTickets.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvTickets.RowTemplate.Height = 35;

            // Renombramiento de las cabeceras para el usuario final
            if (dgvTickets.Columns.Count > 0)
            {
                if (dgvTickets.Columns.Contains("ID_Ticket")) dgvTickets.Columns["ID_Ticket"].HeaderText = "No. Ticket";
                if (dgvTickets.Columns.Contains("ID_Viaje")) dgvTickets.Columns["ID_Viaje"].HeaderText = "ID Viaje";
                if (dgvTickets.Columns.Contains("HoraEmision")) dgvTickets.Columns["HoraEmision"].HeaderText = "Fecha/Hora";
                if (dgvTickets.Columns.Contains("MontoPagado")) dgvTickets.Columns["MontoPagado"].HeaderText = "Monto (RD$)";
            }
        }

        // Evento para capturar la selección de celdas (sin implementar)
        private void dgvTickets_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Espacio para lógica futura de selección de tickets
        }
    }
}