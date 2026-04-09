using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaRecaudacionOMSA
{
    // Módulo de punto de venta y emisión de boletos
    public partial class FrmTickets : Form
    {
        private N_Ticket objTicket = new N_Ticket();
        private decimal tarifaActual = 0m;

        public FrmTickets()
        {
            InitializeComponent();

            dgvTickets.BackgroundColor = Color.FromArgb(28, 28, 28);
            dgvTickets.BorderStyle = BorderStyle.None;
        }

        private async void FrmTickets_Load(object sender, EventArgs e)
        {
            dgvTickets.Visible = false;

            LlenarComboCantidad();
            await CargarViajesActivosAsync();
            await MostrarTicketsTablaAsync();

            HabilitarCampos(false);
        }

        // --- GESTIÓN DE INTERFAZ Y ESTADOS ---

        // Controla la habilitación visual y funcional de los componentes del formulario
        private void HabilitarCampos(bool estado)
        {
            Color colorTexto = estado ? Color.White : Color.Gray;
            Color colorBotonApagado = Color.FromArgb(45, 45, 48);

            lblViaje.ForeColor = lblCantidadTickets.ForeColor = lblTarifa.ForeColor = lblTotalPagar.ForeColor = colorTexto;

            cmbViaje.Enabled = cmbCantidadTickets.Enabled = estado;

            // Bloqueo de campos calculados
            txtTarifa.Enabled = false;
            txtTotalPagar.Enabled = false;

            btnGuardar.Enabled = estado;
            btnGuardar.BackColor = estado ? Color.SeaGreen : colorBotonApagado;
            btnGuardar.ForeColor = colorTexto;
        }

        // Alterna el estado operativo de la caja registradora
        private void btnModoEdicion_Click(object sender, EventArgs e)
        {
            bool habilitar = !cmbViaje.Enabled;
            HabilitarCampos(habilitar);

            if (habilitar)
            {
                btnModoEdicion.Text = "Cerrar Caja";
                btnModoEdicion.ForeColor = Color.Tomato;
                btnModoEdicion.Image = Properties.Resources.open_lock;

                cmbCantidadTickets.SelectedIndex = 0;
                txtTarifa.Text = "0.00";
                txtTotalPagar.Text = "0.00";
            }
            else
            {
                btnModoEdicion.Text = "Vender Tickets";
                btnModoEdicion.ForeColor = Color.White;
                btnModoEdicion.Image = Properties.Resources.closed_lock;
                LimpiarFormulario();
            }
        }

        private void btnVerTabla_Click(object sender, EventArgs e)
        {
            dgvTickets.Visible = !dgvTickets.Visible;
            btnVerTabla.Text = dgvTickets.Visible ? "Ocultar Historial" : "Ver Historial";
            btnVerTabla.ForeColor = dgvTickets.Visible ? Color.Yellow : Color.White;
            btnVerTabla.Image = dgvTickets.Visible ? Properties.Resources.view_off : Properties.Resources.view;
        }

        // --- CARGA DE DATOS Y LÓGICA FINANCIERA ---

        // Configura el selector de volumen de compra
        private void LlenarComboCantidad()
        {
            cmbCantidadTickets.Items.Clear();
            for (int i = 1; i <= 20; i++)
            {
                cmbCantidadTickets.Items.Add(i.ToString());
            }
        }

        // Recupera y enlista los viajes disponibles para asignación de tickets
        private async Task CargarViajesActivosAsync()
        {
            try
            {
                DataTable dtViajes = await objTicket.MostrarViajesActivosAsync();

                cmbViaje.DataSource = dtViajes;
                cmbViaje.DisplayMember = "DescripcionViaje";
                cmbViaje.ValueMember = "ID_Viaje";

                cmbViaje.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar cartelera de viajes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Actualiza el precio unitario basado en el viaje seleccionado
        private void cmbViaje_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbViaje.SelectedIndex != -1 && cmbViaje.SelectedItem is DataRowView filaSeleccionada)
            {
                tarifaActual = Convert.ToDecimal(filaSeleccionada["Tarifa"]);
                txtTarifa.Text = tarifaActual.ToString("N2");

                CalcularTotalPagar();
            }
            else
            {
                tarifaActual = 0m;
                txtTarifa.Text = "0.00";
                txtTotalPagar.Text = "0.00";
            }
        }

        // Dispara la re-evaluación financiera al modificar el volumen
        private void cmbCantidadTickets_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularTotalPagar();
        }

        // Ejecuta el cálculo del monto total de la transacción
        private void CalcularTotalPagar()
        {
            if (cmbCantidadTickets.SelectedItem != null && tarifaActual > 0)
            {
                int cantidad = Convert.ToInt32(cmbCantidadTickets.SelectedItem);
                decimal total = cantidad * tarifaActual;

                txtTotalPagar.Text = total.ToString("N2");
            }
        }

        // --- TRANSACCIONES CRUD ---

        // Procesa y formaliza la venta de boletos
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbViaje.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione un viaje activo de la cartelera.", "Requisito Incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbCantidadTickets.SelectedItem == null)
            {
                MessageBox.Show("Debe indicar el volumen de tickets a emitir.", "Requisito Incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string idViaje = cmbViaje.SelectedValue.ToString();
                string cantidad = cmbCantidadTickets.SelectedItem.ToString();
                string tarifaTexto = tarifaActual.ToString();

                string mensajeValidacion = $"¿Autoriza la emisión de {cantidad} ticket(s) por un valor total de RD$ {txtTotalPagar.Text}?";

                if (MessageBox.Show(mensajeValidacion, "Confirmar Transacción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    await objTicket.VenderTicketsAsync(idViaje, tarifaTexto, cantidad);

                    MessageBox.Show("Transacción procesada correctamente.", "Emisión Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await MostrarTicketsTablaAsync();
                    LimpiarFormulario();
                    cmbCantidadTickets.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error durante la emisión: " + ex.Message, "Fallo Transaccional", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cancela la operación actual y limpia la interfaz
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            if (cmbCantidadTickets.Items.Count > 0) cmbCantidadTickets.SelectedIndex = 0;
        }

        private void LimpiarFormulario()
        {
            cmbViaje.SelectedIndex = -1;
            txtTarifa.Text = "0.00";
            txtTotalPagar.Text = "0.00";
            dgvTickets.ClearSelection();
        }

        // --- PRESENTACIÓN DE DATOS (HISTÓRICO) ---

        // Consulta y muestra el registro histórico de ventas
        private async Task MostrarTicketsTablaAsync()
        {
            try
            {
                dgvTickets.DataSource = await objTicket.MostrarTicketsAsync();

                if (dgvTickets.Columns["ID_Ticket"] != null) dgvTickets.Columns["ID_Ticket"].HeaderText = "No. Ticket";
                if (dgvTickets.Columns["MontoPagado"] != null) dgvTickets.Columns["MontoPagado"].HeaderText = "Monto (RD$)";
                if (dgvTickets.Columns["Estado"] != null) dgvTickets.Columns["Estado"].HeaderText = "Estado";

                if (dgvTickets.Columns["Fecha"] != null)
                {
                    dgvTickets.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgvTickets.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                AplicarEstiloTabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar histórico de ventas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Aplica el diseño corporativo a la cuadrícula de datos
        private void AplicarEstiloTabla()
        {
            dgvTickets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTickets.RowHeadersVisible = false;

            dgvTickets.BorderStyle = BorderStyle.None;
            dgvTickets.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTickets.GridColor = Color.FromArgb(64, 64, 64);

            dgvTickets.EnableHeadersVisualStyles = false;
            dgvTickets.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvTickets.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dgvTickets.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTickets.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvTickets.ColumnHeadersHeight = 40;

            dgvTickets.DefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
            dgvTickets.DefaultCellStyle.ForeColor = Color.White;
            dgvTickets.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dgvTickets.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvTickets.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvTickets.RowTemplate.Height = 35;
        }

        private void dgvTickets_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}