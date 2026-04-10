using CapaNegocios;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaRecaudacionOMSA
{
    // Gestión y despacho de viajes (Formulario Transaccional)
    public partial class FrmViajes : Form
    {
        // Instancias de la capa de negocios
        private N_Viaje objViaje = new N_Viaje();
        private N_Chofer objChofer = new N_Chofer();
        private N_Ruta objRuta = new N_Ruta();
        private N_Vehiculo objVehiculo = new N_Vehiculo();

        // Control de estado para validación de modificaciones
        private int idViaje = 0;
        private string choferOriginal = "", rutaOriginal = "", vehiculoOriginal = "";
        private DateTime fechaOriginal;

        public FrmViajes()
        {
            InitializeComponent();

            // Configuración visual base de la cuadrícula
            dgvViajes.BackgroundColor = Color.FromArgb(28, 28, 28);
            dgvViajes.BorderStyle = BorderStyle.None;
        }

        // Evento de inicialización del formulario
        private async void FrmViajes_Load(object sender, EventArgs e)
        {
            dtpFecha.MinDate = DateTime.Today;
            dgvViajes.Visible = false;

            // Carga asíncrona de dependencias para no congelar la interfaz
            await CargarListasDesplegablesAsync();
            await MostrarViajesTablaAsync();

            HabilitarCampos(false);
        }

        // ==========================================================
        // GESTIÓN DE INTERFAZ Y ESTADOS VISUALES
        // ==========================================================

        // Activa o desactiva controles ajustando su paleta de colores
        private void HabilitarCampos(bool estado)
        {
            Color colorTexto = estado ? Color.White : Color.Gray;
            Color colorBotonApagado = Color.FromArgb(45, 45, 48);

            lblChofer.ForeColor = lblRuta.ForeColor = lblVehiculo.ForeColor = lblFecha.ForeColor = colorTexto;
            cmbChofer.Enabled = dtpFecha.Enabled = cmbRuta.Enabled = cmbVehiculo.Enabled = estado;

            btnGuardar.Enabled = btnActualizar.Enabled = btnCancelar.Enabled = estado;

            btnGuardar.BackColor = estado ? Color.SeaGreen : colorBotonApagado;
            btnActualizar.BackColor = estado ? Color.Goldenrod : colorBotonApagado;
            btnCancelar.BackColor = estado ? Color.IndianRed : colorBotonApagado;

            btnGuardar.ForeColor = btnActualizar.ForeColor = btnCancelar.ForeColor = colorTexto;
        }

        // Alterna entre modo de solo lectura y modo de edición
        private void btnModoEdicion_Click(object sender, EventArgs e)
        {
            bool habilitar = !cmbChofer.Enabled;
            HabilitarCampos(habilitar);

            if (habilitar)
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
                LimpiarFormulario();
            }
        }

        // Muestra u oculta la tabla del historial de viajes
        private void btnVerTabla_Click(object sender, EventArgs e)
        {
            dgvViajes.Visible = !dgvViajes.Visible;
            btnVerTabla.Text = dgvViajes.Visible ? "Ocultar Tabla" : "Ver Tabla";
            btnVerTabla.ForeColor = dgvViajes.Visible ? Color.Yellow : Color.White;
            btnVerTabla.Image = dgvViajes.Visible ? Properties.Resources.view_off : Properties.Resources.view;
        }

        // Restablece los controles a su estado inicial
        private void LimpiarFormulario()
        {
            idViaje = 0;
            cmbChofer.SelectedIndex = cmbRuta.SelectedIndex = cmbVehiculo.SelectedIndex = -1;

            dtpFecha.MinDate = new DateTime(1900, 1, 1);
            dtpFecha.Value = DateTime.Now;
            dtpFecha.MinDate = DateTime.Today;

            dgvViajes.ClearSelection();
        }

        // ==========================================================
        // LÓGICA DE VALIDACIÓN
        // ==========================================================

        // Verifica si el usuario realizó modificaciones en el registro seleccionado
        private bool HayCambiosReales()
        {
            if (idViaje == 0) return false;

            bool cambioChofer = (cmbChofer.Text != choferOriginal);
            bool cambioRuta = (cmbRuta.Text != rutaOriginal);
            bool cambioVehiculo = (cmbVehiculo.Text != vehiculoOriginal);
            bool cambioFecha = (dtpFecha.Value.Date != fechaOriginal.Date);

            return (cambioChofer || cambioRuta || cambioVehiculo || cambioFecha);
        }

        // Habilita el botón de actualizar solo si existen cambios
        private void VerificarSiHayCambios(object sender, EventArgs e)
        {
            if (idViaje == 0 || cmbChofer.Enabled == false) return;
            btnActualizar.Enabled = HayCambiosReales();
        }

        // ==========================================================
        // OPERACIONES CRUD ASÍNCRONAS
        // ==========================================================

        // Registra un nuevo despacho en el sistema
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (idViaje > 0)
            {
                MessageBox.Show("Ha seleccionado un viaje existente. Use 'Actualizar' para modificar o limpie los campos para un nuevo despacho.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbChofer.SelectedIndex == -1 || cmbRuta.SelectedIndex == -1 || cmbVehiculo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe asignar un chofer, ruta y vehículo para el despacho.", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                MessageBox.Show("Viaje despachado exitosamente.", "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await MostrarViajesTablaAsync();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al despachar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Modifica la programación de un viaje previamente registrado
        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            if (idViaje == 0)
            {
                MessageBox.Show("Seleccione un viaje de la tabla para actualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!HayCambiosReales())
            {
                MessageBox.Show("No se han detectado cambios en la programación del viaje.", "Sin Cambios", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                MessageBox.Show("Programación actualizada correctamente.", "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await MostrarViajesTablaAsync();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cambia el estado del viaje a 'Cancelado' (Baja lógica)
        private async void btnCancelar_Click(object sender, EventArgs e)
        {
            if (idViaje == 0)
            {
                MessageBox.Show("Seleccione un viaje para cancelar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("¿Confirmar la cancelación del viaje? El estado cambiará a 'Cancelado'.", "Confirmar Acción", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    await objViaje.CancelarViajeAsync(idViaje.ToString());
                    MessageBox.Show("El viaje ha sido cancelado en el sistema.", "OMSA Despacho");
                    await MostrarViajesTablaAsync();
                    LimpiarFormulario();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cancelar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================================================
        // CARGA DE DATOS Y CONFIGURACIÓN VISUAL
        // ==========================================================

        // Pobla los menús desplegables con datos de la base de datos
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
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar catálogos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Extrae y procesa los registros para mostrarlos en la interfaz
        private async Task MostrarViajesTablaAsync()
        {
            try
            {
                dgvViajes.DataSource = await objViaje.MostrarViajesAsync();

                if (dgvViajes.Columns["ID"] != null)
                    dgvViajes.Columns["ID"].Visible = false;

                if (dgvViajes.Columns["Fecha y Hora"] != null)
                {
                    dgvViajes.Columns["Fecha y Hora"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgvViajes.Columns["Fecha y Hora"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvViajes.Columns["Fecha y Hora"].HeaderText = "Fecha";
                }

                if (dgvViajes.Columns["Ficha del Vehículo"] != null)
                    dgvViajes.Columns["Ficha del Vehículo"].HeaderText = "Unidad";

                AplicarEstiloTabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar tabla: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Configura la estética Dark Mode del DataGridView
        private void AplicarEstiloTabla()
        {
            dgvViajes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvViajes.RowHeadersVisible = false;
            dgvViajes.BorderStyle = BorderStyle.None;
            dgvViajes.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvViajes.GridColor = Color.FromArgb(64, 64, 64);

            dgvViajes.EnableHeadersVisualStyles = false;
            dgvViajes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvViajes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dgvViajes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvViajes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvViajes.ColumnHeadersHeight = 40;

            dgvViajes.DefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
            dgvViajes.DefaultCellStyle.ForeColor = Color.White;
            dgvViajes.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dgvViajes.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvViajes.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvViajes.RowTemplate.Height = 35;
        }

        // Sincroniza los controles del formulario con la fila seleccionada
        private void dgvViajes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (cmbChofer.Enabled == false || e.RowIndex < 0) return;

            DataGridViewRow fila = dgvViajes.Rows[e.RowIndex];
            idViaje = Convert.ToInt32(fila.Cells["ID"].Value);

            choferOriginal = fila.Cells["Chofer"].Value.ToString();
            rutaOriginal = fila.Cells["Ruta"].Value.ToString();
            vehiculoOriginal = fila.Cells["Ficha del Vehículo"].Value.ToString();
            fechaOriginal = Convert.ToDateTime(fila.Cells["Fecha y Hora"].Value);

            cmbChofer.Text = choferOriginal;
            cmbRuta.Text = rutaOriginal;
            cmbVehiculo.Text = vehiculoOriginal;

            dtpFecha.MinDate = new DateTime(1900, 1, 1);
            dtpFecha.Value = fechaOriginal;
        }

        // Codificación de colores basada en el estado operativo del viaje
        private void dgvViajes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvViajes.Columns[e.ColumnIndex].Name == "Estado" && e.Value != null)
            {
                string estado = e.Value.ToString();
                if (estado == "Cancelado")
                {
                    e.CellStyle.ForeColor = Color.LightCoral;
                }
                else if (estado == "Activo")
                {
                    e.CellStyle.ForeColor = Color.LightGreen;
                    e.CellStyle.Font = new Font(dgvViajes.Font, FontStyle.Bold);
                }
            }
        }
    }
}