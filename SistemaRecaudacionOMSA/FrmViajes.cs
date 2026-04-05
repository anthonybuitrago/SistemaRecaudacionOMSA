using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;

namespace SistemaRecaudacionOMSA
{
    public partial class FrmViajes : Form
    {
        private N_Viaje objViaje = new N_Viaje();
        private N_Chofer objChofer = new N_Chofer();
        private N_Ruta objRuta = new N_Ruta();
        private N_Vehiculo objVehiculo = new N_Vehiculo();

        private int idViaje = 0;
        private string choferOriginal = "", rutaOriginal = "", vehiculoOriginal = "";
        private DateTime fechaOriginal;

        public FrmViajes()
        {
            InitializeComponent();

            // Estética inicial del DGV
            dgvViajes.BackgroundColor = Color.FromArgb(28, 28, 28);
            dgvViajes.BorderStyle = BorderStyle.None;
        }

        private async void FrmViajes_Load(object sender, EventArgs e)
        {
            dtpFecha.MinDate = DateTime.Today;
            dgvViajes.Visible = false;

            await CargarListasDesplegablesAsync();
            await MostrarViajesTablaAsync();

            HabilitarCampos(false);
        }

        // --- LÓGICA DE INTERFAZ ---

        private void HabilitarCampos(bool estado)
        {
            Color colorTexto = estado ? Color.White : Color.Gray;

            // Labels
            lblChofer.ForeColor = lblRuta.ForeColor = lblVehiculo.ForeColor = lblFecha.ForeColor = colorTexto;

            // Controles
            cmbChofer.Enabled = dtpFecha.Enabled = cmbRuta.Enabled = cmbVehiculo.Enabled = estado;

            // Botones CRUD: Ahora SIEMPRE se encienden cuando estás en modo edición
            btnGuardar.Enabled = estado;
            btnActualizar.Enabled = estado;
            btnCancelar.Enabled = estado;
        }

        private void btnModoEdicion_Click(object sender, EventArgs e)
        {
            bool estaAbriendo = !cmbChofer.Enabled;
            HabilitarCampos(estaAbriendo);

            if (estaAbriendo)
            {
                btnModoEdicion.Text = "Cerrar Edición";
                btnModoEdicion.ForeColor = Color.Tomato;
                btnModoEdicion.Image = Properties.Resources.open_lock;
            }
            else
            {
                btnModoEdicion.Text = "Editar Datos";
                btnModoEdicion.ForeColor = Color.White;
                btnModoEdicion.Image = Properties.Resources.closed_lock;
                LimpiarFormulario(); // Limpieza automática al cerrar
            }
        }

        private void btnVerTabla_Click(object sender, EventArgs e)
        {
            dgvViajes.Visible = !dgvViajes.Visible;

            if (dgvViajes.Visible)
            {
                btnVerTabla.Text = "Ocultar Tabla";
                btnVerTabla.ForeColor = Color.Yellow;
                btnVerTabla.Image = Properties.Resources.view_off;
            }
            else
            {
                btnVerTabla.Text = "Ver Tabla";
                btnVerTabla.ForeColor = Color.White;
                btnVerTabla.Image = Properties.Resources.view;
            }
        }

        // --- VALIDACIÓN DE CAMBIOS ---
        private bool HayCambiosReales()
        {
            if (idViaje == 0) return false;

            bool cambioChofer = (cmbChofer.Text != choferOriginal);
            bool cambioRuta = (cmbRuta.Text != rutaOriginal);
            bool cambioVehiculo = (cmbVehiculo.Text != vehiculoOriginal);
            bool cambioFecha = (dtpFecha.Value.ToString("yyyy-MM-dd HH:mm") != fechaOriginal.ToString("yyyy-MM-dd HH:mm"));

            return (cambioChofer || cambioRuta || cambioVehiculo || cambioFecha);
        }

        // --- MÉTODOS CRUD CON ADVERTENCIAS ---

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            // ADVERTENCIA 1: Evitar duplicados si seleccionó uno de la tabla
            if (idViaje > 0)
            {
                MessageBox.Show("Ha seleccionado un viaje existente. Si desea modificarlo use el botón 'Actualizar'.\n\nPara registrar uno nuevo, cierre la edición y vuelva a abrirla para limpiar los campos.", "Acción Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ADVERTENCIA 2: Campos vacíos
            if (cmbChofer.SelectedIndex == -1 || cmbRuta.SelectedIndex == -1 || cmbVehiculo.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, complete todos los campos (Chofer, Ruta y Vehículo) antes de guardar el viaje.", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                await objViaje.InsertarViajeAsync(
                    cmbChofer.SelectedValue.ToString(),
                    cmbRuta.SelectedValue.ToString(),
                    cmbVehiculo.SelectedValue.ToString(),
                    dtpFecha.Value,
                    "Activo"
                );

                MessageBox.Show("¡Viaje despachado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await MostrarViajesTablaAsync();
                LimpiarFormulario();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            // ADVERTENCIA 3: Intentar actualizar sin seleccionar un viaje
            if (idViaje == 0)
            {
                MessageBox.Show("Primero debe seleccionar un viaje de la tabla haciendo clic en él para poder actualizarlo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // ADVERTENCIA 4: Intentar actualizar sin hacer ningún cambio
            if (!HayCambiosReales())
            {
                MessageBox.Show("No se han detectado cambios en la información del viaje. Modifique algún campo antes de actualizar.", "Sin Cambios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                await objViaje.EditarViajeAsync(
                    idViaje.ToString(),
                    cmbChofer.SelectedValue.ToString(),
                    cmbRuta.SelectedValue.ToString(),
                    cmbVehiculo.SelectedValue.ToString(),
                    dtpFecha.Value,
                    "Activo"
                );

                MessageBox.Show("¡Viaje actualizado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await MostrarViajesTablaAsync();
                LimpiarFormulario();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private async void btnCancelar_Click(object sender, EventArgs e)
        {
            // ADVERTENCIA 5: Intentar cancelar sin seleccionar un viaje
            if (idViaje == 0)
            {
                MessageBox.Show("No hay ningún viaje seleccionado. Haga clic en un viaje de la tabla para poder cancelarlo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Está seguro de que desea cancelar este viaje? Esta acción cambiará su estado a 'Cancelado'.", "Confirmar Cancelación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    await objViaje.CancelarViajeAsync(idViaje.ToString());
                    MessageBox.Show("El viaje ha sido cancelado.", "Sistema OMSA");
                    await MostrarViajesTablaAsync();
                    LimpiarFormulario();
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }
        }

        // --- EVENTOS DE TABLA Y DISEÑO ---

        private async Task CargarListasDesplegablesAsync()
        {
            try
            {
                cmbChofer.DataSource = await objChofer.MostrarChoferesAsync();
                cmbChofer.DisplayMember = "NombreCompleto";
                cmbChofer.ValueMember = "ID_Chofer";

                cmbRuta.DataSource = await objRuta.MostrarRutasAsync();
                cmbRuta.DisplayMember = "NombreRuta";
                cmbRuta.ValueMember = "ID_Ruta";

                cmbVehiculo.DataSource = await objVehiculo.MostrarVehiculosAsync();
                cmbVehiculo.DisplayMember = "Ficha";
                cmbVehiculo.ValueMember = "ID_Vehiculo";

                cmbChofer.SelectedIndex = cmbRuta.SelectedIndex = cmbVehiculo.SelectedIndex = -1;
            }
            catch (Exception ex) { MessageBox.Show("Error listas: " + ex.Message); }
        }

        private async Task MostrarViajesTablaAsync()
        {
            dgvViajes.DataSource = await objViaje.MostrarViajesAsync();

            if (dgvViajes.Columns["ID"] != null) dgvViajes.Columns["ID"].Visible = false;

            // 2. Formatear la Fecha para que NO muestre la hora
            if (dgvViajes.Columns["Fecha y Hora"] != null)
            {
                // Cambiamos "dd/MM/yyyy hh:mm tt" por "dd/MM/yyyy"
                dgvViajes.Columns["Fecha y Hora"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvViajes.Columns["Fecha y Hora"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvViajes.Columns["Ficha del Vehículo"] != null) dgvViajes.Columns["Ficha del Vehículo"].HeaderText = "Ficha";
            if (dgvViajes.Columns["Fecha y Hora"] != null) dgvViajes.Columns["Fecha y Hora"].HeaderText = "Fecha";

            AplicarEstiloTabla();
        }

        private void AplicarEstiloTabla()
        {
            dgvViajes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvViajes.RowHeadersVisible = false;

            // Bordes Flat
            dgvViajes.BorderStyle = BorderStyle.None;
            dgvViajes.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvViajes.GridColor = Color.FromArgb(64, 64, 64);

            // Cabeceras limpias (sin bordes blancos)
            dgvViajes.EnableHeadersVisualStyles = false;
            dgvViajes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvViajes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dgvViajes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvViajes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvViajes.ColumnHeadersHeight = 40;

            // Filas
            dgvViajes.DefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
            dgvViajes.DefaultCellStyle.ForeColor = Color.White;
            dgvViajes.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dgvViajes.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvViajes.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvViajes.RowTemplate.Height = 35;
        }

        private void dgvViajes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (cmbChofer.Enabled == false || e.RowIndex < 0) return;

            DataGridViewRow fila = dgvViajes.Rows[e.RowIndex];
            idViaje = Convert.ToInt32(fila.Cells["ID"].Value);

            // Cargar datos a memoria
            choferOriginal = fila.Cells["Chofer"].Value.ToString();
            rutaOriginal = fila.Cells["Ruta"].Value.ToString();
            vehiculoOriginal = fila.Cells["Ficha del Vehículo"].Value.ToString();
            fechaOriginal = Convert.ToDateTime(fila.Cells["Fecha y Hora"].Value);

            // Asignar a controles
            cmbChofer.Text = choferOriginal;
            cmbRuta.Text = rutaOriginal;
            cmbVehiculo.Text = vehiculoOriginal;

            dtpFecha.MinDate = new DateTime(1900, 1, 1);
            dtpFecha.Value = fechaOriginal;
        }

        private void dgvViajes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvViajes.Columns[e.ColumnIndex].Name == "Estado" && e.Value != null)
            {
                string estado = e.Value.ToString();
                if (estado == "Cancelado") e.CellStyle.ForeColor = Color.LightCoral;
                else if (estado == "Activo")
                {
                    e.CellStyle.ForeColor = Color.LightGreen;
                    e.CellStyle.Font = new Font(dgvViajes.Font, FontStyle.Bold);
                }
            }
        }

        private void LimpiarFormulario()
        {
            idViaje = 0;
            cmbChofer.SelectedIndex = cmbRuta.SelectedIndex = cmbVehiculo.SelectedIndex = -1;
            dtpFecha.MinDate = new DateTime(1900, 1, 1);
            dtpFecha.Value = DateTime.Now;
            dtpFecha.MinDate = DateTime.Today;

            dgvViajes.ClearSelection();
        }

        // --- MÉTODO FALTANTE PARA LOS EVENTOS DE CAMBIO ---
        private void VerificarSiHayCambios(object sender, EventArgs e)
        {
            // Si el candado está cerrado o es un viaje nuevo, ignoramos.
            if (idViaje == 0 || cmbChofer.Enabled == false) return;

            // Comparamos los valores actuales con los originales
            bool cambioChofer = (cmbChofer.Text != choferOriginal);
            bool cambioRuta = (cmbRuta.Text != rutaOriginal);
            bool cambioVehiculo = (cmbVehiculo.Text != vehiculoOriginal);
            bool cambioFecha = (dtpFecha.Value.ToString("yyyy-MM-dd HH:mm") != fechaOriginal.ToString("yyyy-MM-dd HH:mm"));

            // Habilita el botón "Actualizar" solo si encuentra algún cambio
            btnActualizar.Enabled = (cambioChofer || cambioRuta || cambioVehiculo || cambioFecha);
        }
    }
}