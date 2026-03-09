using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaRecaudacionOMSA
{
    public partial class FrmTickets : Form
    {
        // 1. Instancias de Negocio
        private N_Ticket objTicket = new N_Ticket();
        private N_Viaje objViaje = new N_Viaje();
        private int idTicket = 0;

        public FrmTickets()
        {
            InitializeComponent();
        }

        private void FrmTickets_Load(object sender, EventArgs e)
        {
            // Cargamos los datos iniciales
            CargarViajes();
            MostrarTicketsTabla();
            LimpiarCampos();
        }

        private void MostrarTicketsTabla()
        {
            // Llama al método que creamos en la Capa de Negocio
            dgvTickets.DataSource = objTicket.MostrarTickets();
            AplicarEstiloTabla();
        }

        private void CargarViajes()
        {
            try
            {
                // Usamos el nuevo método de la capa de negocio
                cmbViaje.DataSource = objViaje.MostrarViajesCombo();

                // Le decimos que muestre la columna virtual que creamos en SQL
                cmbViaje.DisplayMember = "DescripcionViaje";

                // El valor oculto sigue siendo el ID del viaje para poder guardarlo
                cmbViaje.ValueMember = "ID_Viaje";
                // --- Quitar la selección por defecto del viaje ---
                cmbViaje.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar viajes: " + ex.Message);
            }
        }

        // --- Lógica de Botones ---

        private void btnVender_Click(object sender, EventArgs e)
        {
            // 1. Validar que el monto no esté vacío
            if (string.IsNullOrWhiteSpace(txtMonto.Text))
            {
                MessageBox.Show("Por favor, ingrese el monto del ticket.", "Aviso OMSA");
                return;
            }

            // 2. VALIDACIÓN CRUCIAL: Verificar si hay un viaje seleccionado
            if (cmbViaje.SelectedValue == null)
            {
                MessageBox.Show("No hay un viaje seleccionado. Asegúrese de que existan viajes registrados.", "Error de Selección");
                return;
            }

            try
            {
                // 3. Ahora que sabemos que no es null, capturamos los datos
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // 1. Limpiar el ComboBox (quitar selección)
            cmbViaje.SelectedIndex = -1;

            // 2. Limpiar el cuadro de texto del monto
            // (Asegúrate de ponerle el nombre real de tu TextBox, yo asumí txtMonto)
            txtMonto.Clear();

            // 3. Volver a poner el cursor en el ComboBox para que el usuario empiece de nuevo
            cmbViaje.Focus();
        }

        private void LimpiarCampos()
        {
            // Ajustado a los nombres de Tickets
            if (cmbViaje.Items.Count > 0) cmbViaje.SelectedIndex = 0;
            txtMonto.Clear();
            idTicket = 0;
            txtMonto.Focus();
        }

        // --- Estética OMSA ---

        private void AplicarEstiloTabla()
        {
            dgvTickets.AllowUserToAddRows = false;
            dgvTickets.RowHeadersVisible = false;
            dgvTickets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTickets.BackgroundColor = Color.White;
            dgvTickets.BorderStyle = BorderStyle.None;

            // Dejamos solo esta línea para que se vean las divisiones horizontales
            dgvTickets.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTickets.GridColor = Color.Gainsboro;

            // --- ESTILO DEL ENCABEZADO ---
            dgvTickets.EnableHeadersVisualStyles = false;
            dgvTickets.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#404040");
            dgvTickets.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTickets.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvTickets.ColumnHeadersHeight = 40;
            dgvTickets.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Evitar resaltado azul en el encabezado
            dgvTickets.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#404040");

            // --- ¡ESTO ERA LO QUE FALTABA: ESTILO DE LAS FILAS! ---
            dgvTickets.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvTickets.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#E0F2E9"); // Color verde OMSA al seleccionar
            dgvTickets.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvTickets.RowTemplate.Height = 35;

            // Nombres de Columnas para Tickets
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

        }
    } // Aquí cierra la clase correctamente
} // Aquí cierra el namespace