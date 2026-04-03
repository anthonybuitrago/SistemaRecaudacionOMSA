using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks; // Obligatorio para Task
using System.Windows.Forms;

namespace SistemaRecaudacionOMSA
{
    public partial class FrmVehiculos : Form
    {
        // Instancia para la comunicación con la Capa de Negocio
        private N_Vehiculo objNegocio = new N_Vehiculo();

        // Variable para almacenar el ID del vehículo seleccionado
        private int idVehiculo = 0;
        private string modoFormulario;

        // Constructor que inicializa los componentes de la ventana
        public FrmVehiculos()
        {
            InitializeComponent();
            AplicarEstiloTabla();
            ConfigurarVistaSegunModo();
        }

        private void ConfigurarVistaSegunModo()
        {
            if (modoFormulario == "Consulta")
            {
                // Oculta las cajas de texto
                panel1.Visible = false;
                // Hace la tabla gigante
                dgvVehiculos.Dock = DockStyle.Fill;
            }
            else
            {
                // Oculta la tabla para dejar solo el registro
                dgvVehiculos.Visible = false;
                // Bloquea los campos al iniciar
                BloquearCampos();
            }
        }

        // Evento ASÍNCRONO que carga los datos al abrir la ventana
        private async void FrmVehiculos_Load(object sender, EventArgs e)
        {
            await MostrarVehiculosTablaAsync();
        }

        // Método ASÍNCRONO para solicitar y mostrar la lista de vehículos registrados
        private async Task MostrarVehiculosTablaAsync()
        {
            try
            {
                dgvVehiculos.DataSource = await objNegocio.MostrarVehiculosAsync();
                AplicarEstiloTabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar vehículos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento ASÍNCRONO para registrar un nuevo vehículo en el sistema
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validación de campos obligatorios
            if (string.IsNullOrWhiteSpace(txtFicha.Text) || string.IsNullOrWhiteSpace(txtPlaca.Text) || string.IsNullOrWhiteSpace(txtCapacidad.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos del vehículo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Validación de lógica de negocio (capacidad positiva)
                if (Convert.ToInt32(txtCapacidad.Text) <= 0)
                {
                    MessageBox.Show("La capacidad debe ser mayor a cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Envío asíncrono de datos a la Capa de Negocio
                await objNegocio.InsertarVehiculoAsync(txtFicha.Text, txtPlaca.Text, txtCapacidad.Text);
                MessageBox.Show("Vehículo guardado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresco visual y limpieza
                await MostrarVehiculosTablaAsync();
                btnLimpiar.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento ASÍNCRONO para guardar las modificaciones de un vehículo existente
        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            // Validación de selección previa
            if (idVehiculo == 0)
            {
                MessageBox.Show("Seleccione un vehículo de la tabla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Envío asíncrono de la actualización a la Capa de Negocio
                await objNegocio.EditarVehiculoAsync(idVehiculo, txtFicha.Text, txtPlaca.Text, txtCapacidad.Text);
                MessageBox.Show("Vehículo actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await MostrarVehiculosTablaAsync();
                btnLimpiar.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento ASÍNCRONO para borrar permanentemente un vehículo
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idVehiculo == 0)
            {
                MessageBox.Show("Seleccione un vehículo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Está seguro de eliminar este vehículo?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    await objNegocio.EliminarVehiculoAsync(idVehiculo);
                    MessageBox.Show("Vehículo eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await MostrarVehiculosTablaAsync();
                    btnLimpiar.PerformClick();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- LÓGICA DE INTERFAZ: BLOQUEO Y HABILITACIÓN ---

        private void BloquearCampos()
        {
            txtFicha.Enabled = false;
            txtPlaca.Enabled = false;
            txtCapacidad.Enabled = false;
            btnGuardar.Enabled = false;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void HabilitarCampos()
        {
            txtFicha.Enabled = true;
            txtPlaca.Enabled = true;
            txtCapacidad.Enabled = true;
        }

        // Evento para reiniciar el formulario (Botón "Nuevo")
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFicha.Clear();
            txtPlaca.Clear();
            txtCapacidad.Clear();
            idVehiculo = 0;

            HabilitarCampos();
            txtFicha.Focus();

            btnGuardar.Enabled = true;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;

            if (modoFormulario.Equals("Consulta", StringComparison.OrdinalIgnoreCase))
            {
                panel1.Visible = false; // Se esconde al terminar
            }
        }

        // Evento para seleccionar un registro y cargar edición
        private void dgvVehiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idVehiculo = Convert.ToInt32(dgvVehiculos.CurrentRow.Cells["ID_Vehiculo"].Value);
                txtFicha.Text = dgvVehiculos.CurrentRow.Cells["Ficha"].Value.ToString();
                txtPlaca.Text = dgvVehiculos.CurrentRow.Cells["Placa"].Value.ToString();
                txtCapacidad.Text = dgvVehiculos.CurrentRow.Cells["Capacidad"].Value.ToString();

                panel1.Visible = true; // Aparece el cajón para editar

                HabilitarCampos();
                btnGuardar.Enabled = false;
                btnActualizar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }

        // Método de Estilos Visuales (Mantenemos tu diseño)
        private void AplicarEstiloTabla()
        {
            dgvVehiculos.AllowUserToAddRows = false;
            dgvVehiculos.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvVehiculos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvVehiculos.BackgroundColor = Color.White;
            dgvVehiculos.BorderStyle = BorderStyle.None;
            dgvVehiculos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVehiculos.MultiSelect = false;
            dgvVehiculos.ReadOnly = true;
            dgvVehiculos.RowHeadersVisible = false;
            dgvVehiculos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVehiculos.EnableHeadersVisualStyles = false;

            dgvVehiculos.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#404040");
            dgvVehiculos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvVehiculos.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#404040");
            dgvVehiculos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvVehiculos.ColumnHeadersHeight = 40;

            dgvVehiculos.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvVehiculos.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#E0F2E9");
            dgvVehiculos.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvVehiculos.RowTemplate.Height = 35;

            if (dgvVehiculos.Columns.Count > 0)
            {
                if (dgvVehiculos.Columns.Contains("ID_Vehiculo")) dgvVehiculos.Columns["ID_Vehiculo"].HeaderText = "ID";
                if (dgvVehiculos.Columns.Contains("Ficha")) dgvVehiculos.Columns["Ficha"].HeaderText = "Ficha OMSA";
                if (dgvVehiculos.Columns.Contains("Placa")) dgvVehiculos.Columns["Placa"].HeaderText = "Placa";
                if (dgvVehiculos.Columns.Contains("Capacidad")) dgvVehiculos.Columns["Capacidad"].HeaderText = "Capacidad";
            }

            foreach (DataGridViewColumn columna in dgvVehiculos.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void txtCapacidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}