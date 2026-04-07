using CapaNegocios;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaRecaudacionOMSA
{
    public partial class FrmVehiculos : Form
    {
        // Instancia para la comunicación con la Capa de Negocio
        private N_Vehiculo objNegocio = new N_Vehiculo();

        private int idVehiculo = 0;
        private string fichaOriginal = "";
        private string placaOriginal = "";
        private string modeloOriginal = "";
        private string capacidadOriginal = "";

        public FrmVehiculos()
        {
            InitializeComponent();

            // Estética inicial de la tabla
            dgvVehiculos.BackgroundColor = Color.FromArgb(28, 28, 28);
            dgvVehiculos.BorderStyle = BorderStyle.None;
            dgvVehiculos.DefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
            dgvVehiculos.DefaultCellStyle.ForeColor = Color.White;

            AplicarEstiloTabla();
        }

        private async void FrmVehiculos_Load(object sender, EventArgs e)
        {
            // Ocultamos la tabla al inicio
            dgvVehiculos.Visible = false;

            await MostrarVehiculosTablaAsync();

            // Bloqueamos los campos y labels al inicio
            HabilitarCampos(false);
        }

        // --- LÓGICA DE INTERFAZ (IGUAL A CHOFERES) ---

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

        private void btnModoEdicion_Click(object sender, EventArgs e)
        {
            bool estaAbriendo = !txtFicha.Enabled;
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
                LimpiarCampos();
            }
        }

        private void HabilitarCampos(bool estado)
        {
            // Colores definidos
            Color colorLabel = estado ? Color.White : Color.Gray;
            Color colorBotonApagado = Color.FromArgb(45, 45, 48); // Gris oscuro

            // 1. Color para los Labels
            lblFicha.ForeColor = colorLabel;
            lblPlaca.ForeColor = colorLabel;
            lblModelo.ForeColor = colorLabel;
            lblCapacidad.ForeColor = colorLabel;

            // 2. Control de los campos
            txtFicha.Enabled = estado;
            txtPlaca.Enabled = estado;
            txtModelo.Enabled = estado;
            txtCapacidad.Enabled = estado;

            // 3. Control de los botones CRUD
            btnGuardar.Enabled = estado;
            btnActualizar.Enabled = estado;
            btnEliminar.Enabled = estado;

            // 4. Color de Fondo de los Botones
            btnGuardar.BackColor = estado ? Color.SeaGreen : colorBotonApagado;
            btnActualizar.BackColor = estado ? Color.Goldenrod : colorBotonApagado;
            btnEliminar.BackColor = estado ? Color.IndianRed : colorBotonApagado;

            // 5. Color del Texto de los Botones
            btnGuardar.ForeColor = colorLabel;
            btnActualizar.ForeColor = colorLabel;
            btnEliminar.ForeColor = colorLabel;
        }

        // --- EVENTOS DE LA TABLA ---

        private void dgvVehiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvVehiculos.Rows[e.RowIndex];

                idVehiculo = Convert.ToInt32(fila.Cells["ID_Vehiculo"].Value);

                // Cargamos los campos
                txtFicha.Text = fichaOriginal = fila.Cells["Ficha"].Value.ToString();
                txtPlaca.Text = placaOriginal = fila.Cells["Placa"].Value.ToString();
                txtModelo.Text = modeloOriginal = fila.Cells["Modelo"].Value.ToString();
                txtCapacidad.Text = capacidadOriginal = fila.Cells["Capacidad"].Value.ToString();

                // IMPORTANTE: NO deshabilitamos btnGuardar, solo activamos los otros
                btnActualizar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }

        // --- MÉTODOS CRUD ASÍNCRONOS ---

        private async Task MostrarVehiculosTablaAsync()
        {
            try
            {
                dgvVehiculos.DataSource = await objNegocio.MostrarVehiculosAsync();

                // Orden visual
                if (dgvVehiculos.Columns["Ficha"] != null) dgvVehiculos.Columns["Ficha"].DisplayIndex = 0;
                if (dgvVehiculos.Columns["Placa"] != null) dgvVehiculos.Columns["Placa"].DisplayIndex = 1;
                if (dgvVehiculos.Columns["Modelo"] != null) dgvVehiculos.Columns["Modelo"].DisplayIndex = 2;
                if (dgvVehiculos.Columns["Capacidad"] != null) dgvVehiculos.Columns["Capacidad"].DisplayIndex = 3;

                // Ocultar columnas técnicas
                if (dgvVehiculos.Columns["ID_Vehiculo"] != null) dgvVehiculos.Columns["ID_Vehiculo"].Visible = false;
                if (dgvVehiculos.Columns["Estado"] != null) dgvVehiculos.Columns["Estado"].Visible = false;

                AplicarEstiloTabla();
            }
            catch (Exception ex) { MessageBox.Show("Error al cargar datos: " + ex.Message); }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            // Si hay un ID seleccionado, avisamos que esto creará un duplicado o un registro nuevo
            if (idVehiculo != 0)
            {
                DialogResult result = MessageBox.Show("¿Desea crear un nuevo registro con estos datos?",
                                                     "Aviso de duplicidad", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No) return;
            }

            if (string.IsNullOrWhiteSpace(txtFicha.Text) || string.IsNullOrWhiteSpace(txtPlaca.Text))
            {
                MessageBox.Show("Por favor, complete los campos obligatorios para continuar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Validación de duplicados en BD
                if (await objNegocio.VerificarFichaExiste(txtFicha.Text))
                {
                    MessageBox.Show("Esta Ficha ya está registrada.");
                    return;
                }

                await objNegocio.InsertarVehiculoAsync(txtFicha.Text, txtPlaca.Text, txtModelo.Text, txtCapacidad.Text);
                MessageBox.Show("¡Vehículo guardado!");
                await MostrarVehiculosTablaAsync();
                LimpiarCampos(); // Esto pondrá el idVehiculo en 0
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            if (idVehiculo == 0) return;

            if (!HayCambiosVehiculo())
            {
                MessageBox.Show("No hay cambios para actualizar.", "Aviso");
                return;
            }

            // Alerta de confirmación
            if (MessageBox.Show("¿Desea guardar los cambios realizados?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    await objNegocio.EditarVehiculoAsync(idVehiculo, txtFicha.Text, txtPlaca.Text, txtModelo.Text, txtCapacidad.Text);
                    MessageBox.Show("Cambios guardados.");
                    await MostrarVehiculosTablaAsync();
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idVehiculo == 0) return;

            // Alerta de eliminación
            if (MessageBox.Show("¿Está seguro de eliminar este vehículo?", "Eliminar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    await objNegocio.EliminarVehiculoAsync(idVehiculo);
                    MessageBox.Show("Vehículo eliminado.");
                    await MostrarVehiculosTablaAsync();
                    LimpiarCampos();
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }
        }

        // --- ESTILO Y RESTRICCIONES ---

        private void AplicarEstiloTabla()
        {
            // Colores de fondo y bordes
            dgvVehiculos.BackgroundColor = Color.FromArgb(30, 30, 30);
            dgvVehiculos.BorderStyle = BorderStyle.None;
            dgvVehiculos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvVehiculos.GridColor = Color.FromArgb(64, 64, 64);

            // Cabecera (Headers)
            dgvVehiculos.EnableHeadersVisualStyles = false; // ¡IMPORTANTE para poder cambiar el color!
            dgvVehiculos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvVehiculos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dgvVehiculos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvVehiculos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvVehiculos.ColumnHeadersHeight = 40;

            // Celdas y Filas
            dgvVehiculos.DefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
            dgvVehiculos.DefaultCellStyle.ForeColor = Color.White;
            dgvVehiculos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dgvVehiculos.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvVehiculos.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvVehiculos.RowTemplate.Height = 35;
            dgvVehiculos.RowHeadersVisible = false;

            // Ajuste automático y lectura
            dgvVehiculos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVehiculos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVehiculos.ReadOnly = true;
            dgvVehiculos.MultiSelect = false;

            // Renombrar y Ocultar
            if (dgvVehiculos.Columns["ID_Vehiculo"] != null) dgvVehiculos.Columns["ID_Vehiculo"].Visible = false;
            if (dgvVehiculos.Columns["Estado"] != null) dgvVehiculos.Columns["Estado"].Visible = false;

            // Si quieres que los títulos se vean bonitos
            if (dgvVehiculos.Columns["Ficha"] != null) dgvVehiculos.Columns["Ficha"].HeaderText = "Ficha";
            if (dgvVehiculos.Columns["Placa"] != null) dgvVehiculos.Columns["Placa"].HeaderText = "Placa";
        }

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

        // Función para detectar si hubo cambios
        private bool HayCambiosVehiculo()
        {
            return txtFicha.Text != fichaOriginal ||
                   txtPlaca.Text != placaOriginal ||
                   txtModelo.Text != modeloOriginal ||
                   txtCapacidad.Text != capacidadOriginal;
        }
    }
}