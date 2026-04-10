using CapaNegocios;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaRecaudacionOMSA
{
    // Formulario para la gestión (CRUD) del inventario de vehículos
    public partial class FrmVehiculos : Form
    {
        private N_Vehiculo objNegocio = new N_Vehiculo();

        // Variables de control de estado y detección de cambios
        private int idVehiculo = 0;
        private string fichaOriginal = "";
        private string placaOriginal = "";
        private string modeloOriginal = "";
        private string capacidadOriginal = "";

        public FrmVehiculos()
        {
            InitializeComponent();
        }

        private async void FrmVehiculos_Load(object sender, EventArgs e)
        {
            dgvVehiculos.Visible = false;
            await MostrarVehiculosTablaAsync();

            HabilitarCampos(false);
            AplicarEstiloTabla();
        }

        // --- GESTIÓN VISUAL Y DE INTERFAZ ---

        // Controla la disponibilidad de los campos y botones según el modo (Lectura/Edición)
        private void HabilitarCampos(bool estado)
        {
            Color colorLabel = estado ? Color.White : Color.Gray;
            Color colorBotonApagado = Color.FromArgb(45, 45, 48);

            lblFicha.ForeColor = lblPlaca.ForeColor = lblModelo.ForeColor = lblCapacidad.ForeColor = colorLabel;

            txtFicha.Enabled = txtPlaca.Enabled = txtModelo.Enabled = txtCapacidad.Enabled = estado;

            btnGuardar.Enabled = estado;
            btnActualizar.Enabled = estado;
            btnEliminar.Enabled = estado;

            btnGuardar.BackColor = estado ? Color.SeaGreen : colorBotonApagado;
            btnActualizar.BackColor = estado ? Color.Goldenrod : colorBotonApagado;
            btnEliminar.BackColor = estado ? Color.IndianRed : colorBotonApagado;

            btnGuardar.ForeColor = btnActualizar.ForeColor = btnEliminar.ForeColor = colorLabel;
        }

        // Alterna la visibilidad de la cuadrícula de datos
        private void btnVerTabla_Click(object sender, EventArgs e)
        {
            dgvVehiculos.Visible = !dgvVehiculos.Visible;

            if (dgvVehiculos.Visible)
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

        // Gestiona el cambio entre modo de visualización y edición de datos
        private void btnModoEdicion_Click(object sender, EventArgs e)
        {
            bool habilitar = !txtFicha.Enabled;
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
                LimpiarCampos();
            }
        }

        // --- OPERACIONES DE BASE DE DATOS (CRUD) ---

        // Recupera y renderiza el listado de vehículos activos
        private async Task MostrarVehiculosTablaAsync()
        {
            try
            {
                dgvVehiculos.DataSource = await objNegocio.MostrarVehiculosAsync();
                AplicarEstiloTabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar inventario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Procesa el registro de una nueva unidad
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (idVehiculo != 0)
            {
                if (MessageBox.Show("¿Desea crear un nuevo registro con estos datos?", "Confirmar Nuevo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            }

            if (string.IsNullOrWhiteSpace(txtFicha.Text) || string.IsNullOrWhiteSpace(txtPlaca.Text))
            {
                MessageBox.Show("Por favor, complete los campos obligatorios (Ficha y Placa).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (await objNegocio.VerificarFichaExiste(txtFicha.Text))
                {
                    MessageBox.Show("El número de Ficha ingresado ya pertenece a otro vehículo.", "Registro Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                await objNegocio.InsertarVehiculoAsync(txtFicha.Text, txtPlaca.Text, txtModelo.Text, txtCapacidad.Text);

                MessageBox.Show("Unidad registrada exitosamente.", "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await MostrarVehiculosTablaAsync();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Actualiza los datos de la unidad seleccionada
        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            if (idVehiculo == 0) return;

            if (!HayCambiosVehiculo())
            {
                MessageBox.Show("No se detectaron cambios en la información actual.", "Sin Cambios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("¿Desea guardar las modificaciones realizadas?", "Confirmar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    await objNegocio.EditarVehiculoAsync(idVehiculo, txtFicha.Text, txtPlaca.Text, txtModelo.Text, txtCapacidad.Text);

                    MessageBox.Show("Datos actualizados correctamente.", "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await MostrarVehiculosTablaAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Ejecuta la baja lógica del vehículo
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idVehiculo == 0) return;

            if (MessageBox.Show("¿Está seguro de que desea eliminar este vehículo del sistema?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    await objNegocio.EliminarVehiculoAsync(idVehiculo);

                    MessageBox.Show("Vehículo eliminado correctamente.", "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await MostrarVehiculosTablaAsync();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- EVENTOS DE CONTROLES Y DISEÑO ---

        // Carga los datos de la fila seleccionada en los campos de edición
        private void dgvVehiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvVehiculos.Rows[e.RowIndex];

                idVehiculo = Convert.ToInt32(fila.Cells["ID_Vehiculo"].Value);
                txtFicha.Text = fichaOriginal = fila.Cells["Ficha"].Value.ToString();
                txtPlaca.Text = placaOriginal = fila.Cells["Placa"].Value.ToString();
                txtModelo.Text = modeloOriginal = fila.Cells["Modelo"].Value.ToString();
                txtCapacidad.Text = capacidadOriginal = fila.Cells["Capacidad"].Value.ToString();

                btnActualizar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }

        // Aplica el estilo visual profesional a la tabla
        private void AplicarEstiloTabla()
        {
            dgvVehiculos.BackgroundColor = Color.FromArgb(30, 30, 30);
            dgvVehiculos.BorderStyle = BorderStyle.None;
            dgvVehiculos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvVehiculos.GridColor = Color.FromArgb(64, 64, 64);

            dgvVehiculos.EnableHeadersVisualStyles = false;
            dgvVehiculos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvVehiculos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dgvVehiculos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvVehiculos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvVehiculos.ColumnHeadersHeight = 40;

            dgvVehiculos.DefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
            dgvVehiculos.DefaultCellStyle.ForeColor = Color.White;
            dgvVehiculos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dgvVehiculos.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvVehiculos.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvVehiculos.RowTemplate.Height = 35;
            dgvVehiculos.RowHeadersVisible = false;

            dgvVehiculos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVehiculos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVehiculos.ReadOnly = true;
            dgvVehiculos.MultiSelect = false;

            // Formato de columnas
            if (dgvVehiculos.Columns["ID_Vehiculo"] != null) dgvVehiculos.Columns["ID_Vehiculo"].Visible = false;
            if (dgvVehiculos.Columns["Estado"] != null) dgvVehiculos.Columns["Estado"].Visible = false;

            if (dgvVehiculos.Columns["Ficha"] != null) dgvVehiculos.Columns["Ficha"].HeaderText = "Ficha";
            if (dgvVehiculos.Columns["Placa"] != null) dgvVehiculos.Columns["Placa"].HeaderText = "Placa";
        }

        // Posiciona el cursor en el primer espacio editable de un MaskedTextBox
        private void AcomodarCursor_Click(object sender, EventArgs e)
        {
            MaskedTextBox m = sender as MaskedTextBox;
            if (m != null && m.MaskedTextProvider != null)
            {
                int pos = m.MaskedTextProvider.FindUnassignedEditPositionFrom(0, true);
                if (pos != -1 && m.SelectionStart > pos) m.SelectionStart = pos;
            }
        }

        private void LimpiarCampos()
        {
            idVehiculo = 0;
            txtFicha.Clear();
            txtPlaca.Clear();
            txtModelo.Clear();
            txtCapacidad.Clear();
            fichaOriginal = placaOriginal = modeloOriginal = capacidadOriginal = "";
        }

        private bool HayCambiosVehiculo()
        {
            return txtFicha.Text != fichaOriginal ||
                   txtPlaca.Text != placaOriginal ||
                   txtModelo.Text != modeloOriginal ||
                   txtCapacidad.Text != capacidadOriginal;
        }
    }
}