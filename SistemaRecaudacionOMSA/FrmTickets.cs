using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaRecaudacionOMSA
{
    public partial class FrmTickets : Form
    {
        private N_Ticket objTicket = new N_Ticket();
        private decimal tarifaActual = 0m; // Para guardar el precio en la memoria temporal

        public FrmTickets()
        {
            InitializeComponent();

            // Configurar diseño base del DGV
            dgvTickets.BackgroundColor = Color.FromArgb(28, 28, 28);
            dgvTickets.BorderStyle = BorderStyle.None;
        }

        private async void FrmTickets_Load(object sender, EventArgs e)
        {
            dgvTickets.Visible = false;

            // Llenar el combo de cantidad (1 al 10, por ejemplo)
            LlenarComboCantidad();

            await CargarViajesActivosAsync();
            await MostrarTicketsTablaAsync();

            HabilitarCampos(false);
        }

        // --- LÓGICA DE INTERFAZ Y BOTONES ---

        private void HabilitarCampos(bool estado)
        {
            Color colorTexto = estado ? Color.White : Color.Gray;

            lblViaje.ForeColor = lblCantidadTickets.ForeColor = lblTarifa.ForeColor = lblTotalPagar.ForeColor = colorTexto;

            cmbViaje.Enabled = cmbCantidadTickets.Enabled = estado;
            // OJO: La Tarifa y el TotalPagar NUNCA se habilitan para escribir, solo muestran datos
            txtTarifa.Enabled = false;
            txtTotalPagar.Enabled = false; // Asumo que usas un TextBox/MaskedTextBox llamado txtTotalPagar por tu outline

            btnGuardar.Enabled = estado;
            // Para la venta de tickets, no se debe permitir Actualizar. Solo Cancelar la operación.
        }

        private void btnModoEdicion_Click(object sender, EventArgs e)
        {
            bool estaAbriendo = !cmbViaje.Enabled;
            HabilitarCampos(estaAbriendo);

            if (estaAbriendo)
            {
                btnModoEdicion.Text = "Cerrar Edición";
                btnModoEdicion.ForeColor = Color.Tomato;
                btnModoEdicion.Image = Properties.Resources.open_lock;

                // Valores por defecto al abrir la caja
                cmbCantidadTickets.SelectedIndex = 0; // Selecciona "1" por defecto
                txtTarifa.Text = "0.00";
                txtTotalPagar.Text = "0.00";
            }
            else
            {
                btnModoEdicion.Text = "Vender Tickets"; // Cambiado de "Editar" a "Vender" por lógica
                btnModoEdicion.ForeColor = Color.White;
                btnModoEdicion.Image = Properties.Resources.closed_lock;
                LimpiarFormulario();
            }
        }

        private void btnVerTabla_Click(object sender, EventArgs e)
        {
            dgvTickets.Visible = !dgvTickets.Visible;
            btnVerTabla.Text = dgvTickets.Visible ? "Ocultar Tabla" : "Ver Tabla";
            btnVerTabla.ForeColor = dgvTickets.Visible ? Color.Yellow : Color.White;
            btnVerTabla.Image = dgvTickets.Visible ? Properties.Resources.view_off : Properties.Resources.view;
        }

        // --- CARGA DE DATOS Y CÁLCULOS AUTOMÁTICOS ---

        private void LlenarComboCantidad()
        {
            cmbCantidadTickets.Items.Clear();
            for (int i = 1; i <= 20; i++) // Permite vender hasta 20 tickets de un golpe
            {
                cmbCantidadTickets.Items.Add(i.ToString());
            }
        }

        private async Task CargarViajesActivosAsync()
        {
            try
            {
                DataTable dtViajes = await objTicket.MostrarViajesActivosAsync();

                cmbViaje.DataSource = dtViajes;
                cmbViaje.DisplayMember = "DescripcionViaje"; // Lo que ve el usuario (Ruta + Chofer)
                cmbViaje.ValueMember = "ID_Viaje";           // El ID oculto

                // Reiniciar selección
                cmbViaje.SelectedIndex = -1;
            }
            catch (Exception ex) { MessageBox.Show("Error al cargar viajes activos: " + ex.Message); }
        }

        // ¡LA MAGIA OCURRE AQUÍ! Cuando el cajero elige un viaje...
        private void cmbViaje_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificamos si hay un viaje seleccionado y si tenemos los datos cargados (DataRowView)
            if (cmbViaje.SelectedIndex != -1 && cmbViaje.SelectedItem is DataRowView filaSeleccionada)
            {
                // Extraemos la tarifa oculta que vino de la base de datos
                tarifaActual = Convert.ToDecimal(filaSeleccionada["Tarifa"]);

                // La mostramos en pantalla formateada
                txtTarifa.Text = tarifaActual.ToString("N2"); // Formato de 2 decimales

                // Recalculamos el total automáticamente
                CalcularTotalPagar();
            }
            else
            {
                tarifaActual = 0m;
                txtTarifa.Text = "0.00";
                txtTotalPagar.Text = "0.00";
            }
        }

        // Cuando el cajero cambia la cantidad (ej. de 1 ticket a 3 tickets)...
        private void cmbCantidadTickets_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularTotalPagar();
        }

        private void CalcularTotalPagar()
        {
            if (cmbCantidadTickets.SelectedItem != null && tarifaActual > 0)
            {
                int cantidad = Convert.ToInt32(cmbCantidadTickets.SelectedItem);
                decimal total = cantidad * tarifaActual;

                // Mostramos el gran total al cajero
                txtTotalPagar.Text = total.ToString("N2");
            }
        }

        // --- PROCESO DE VENTA (CRUD) ---

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbViaje.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione un viaje activo de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbCantidadTickets.SelectedItem == null)
            {
                MessageBox.Show("Debe indicar la cantidad de tickets a vender.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string idViaje = cmbViaje.SelectedValue.ToString();
                string cantidad = cmbCantidadTickets.SelectedItem.ToString();
                string tarifaTexto = tarifaActual.ToString();

                // Confirmación visual estilo cajero
                string mensaje = $"¿Confirmar venta de {cantidad} ticket(s) por un total de RD$ {txtTotalPagar.Text}?";
                if (MessageBox.Show(mensaje, "Procesar Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Mandamos a vender a la Capa de Negocio
                    await objTicket.VenderTicketsAsync(idViaje, tarifaTexto, cantidad);

                    MessageBox.Show("¡Venta procesada con éxito!", "Ticket(s) Generado(s)", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await MostrarTicketsTablaAsync();
                    LimpiarFormulario();

                    // Volvemos a seleccionar 1 cantidad por defecto para la siguiente venta rápida
                    cmbCantidadTickets.SelectedIndex = 0;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error en Venta", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Para la caja, el botón rojo simplemente limpia el formulario rápidamente sin cerrar el candado
            LimpiarFormulario();
            cmbCantidadTickets.SelectedIndex = 0;
        }

        private void LimpiarFormulario()
        {
            cmbViaje.SelectedIndex = -1;
            // No limpiamos el combo de cantidad para que siga en "1"
            txtTarifa.Text = "0.00";
            txtTotalPagar.Text = "0.00";
            dgvTickets.ClearSelection();
        }

        // --- ESTILO DE LA TABLA (DARK FLAT) ---

        private async Task MostrarTicketsTablaAsync()
        {
            dgvTickets.DataSource = await objTicket.MostrarTicketsAsync();

            if (dgvTickets.Columns["ID_Ticket"] != null) dgvTickets.Columns["ID_Ticket"].HeaderText = "No. Ticket";
            if (dgvTickets.Columns["MontoPagado"] != null) dgvTickets.Columns["MontoPagado"].HeaderText = "Monto (RD$)";
            if (dgvTickets.Columns["Estado"] != null) dgvTickets.Columns["Estado"].HeaderText = "Estado";

            // Formatear Fecha
            if (dgvTickets.Columns["Fecha"] != null)
            {
                dgvTickets.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvTickets.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            AplicarEstiloTabla();
        }

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
            // Las cajas registradoras no permiten editar tickets tocando la tabla.
            // Así que este evento se queda vacío a propósito.
        }
    }
}