using CapaNegocios; // Asegúrate de que este sea el nombre correcto de tu namespace de negocio
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaRecaudacionOMSA
{
    public partial class FrmVehiculos : Form
    {
        // 1. CAMBIO: Usar la clase de Negocio de Vehículos
        private N_Vehiculo objNegocio = new N_Vehiculo();
        private int idVehiculo = 0;

        public FrmVehiculos()
        {
            InitializeComponent();
        }

        private void FrmVehiculos_Load(object sender, EventArgs e)
        {
            // 2. CAMBIO: Nombre de método corregido
            MostrarVehiculosTabla();
            LimpiarCampos();
        }

        private void MostrarVehiculosTabla()
        {
            // 3. CAMBIO: Usar dgvVehiculos (asegúrate que así se llame en el diseño)
            dgvVehiculos.DataSource = objNegocio.MostrarVehiculos();
            AplicarEstiloTabla();
        }

        // --- Lógica de Botones ---

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFicha.Text) || string.IsNullOrWhiteSpace(txtPlaca.Text) || string.IsNullOrWhiteSpace(txtCapacidad.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos del vehículo.", "Aviso");
                return;
            }

            try
            {
                if (Convert.ToInt32(txtCapacidad.Text) <= 0)
                {
                    MessageBox.Show("La capacidad debe ser mayor a cero.", "Validación");
                    return;
                }

                // 4. CAMBIO: Llamada al método correcto de N_Vehiculo
                objNegocio.InsertarVehiculo(txtFicha.Text, txtPlaca.Text, txtCapacidad.Text);
                MessageBox.Show("Vehículo guardado con éxito.", "Éxito");

                MostrarVehiculosTabla();
                btnLimpiar.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (idVehiculo == 0)
            {
                MessageBox.Show("Seleccione un vehículo de la tabla.", "Aviso");
                return;
            }

            try
            {
                // 5. CAMBIO: Llamada al método de edición de vehículos
                objNegocio.EditarVehiculo(idVehiculo, txtFicha.Text, txtPlaca.Text, txtCapacidad.Text);
                MessageBox.Show("Vehículo actualizado correctamente.", "Éxito");

                MostrarVehiculosTabla();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idVehiculo == 0)
            {
                MessageBox.Show("Seleccione un vehículo.", "Aviso");
                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Está seguro de eliminar este vehículo?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    objNegocio.EliminarVehiculo(idVehiculo);
                    MessageBox.Show("Vehículo eliminado.");
                    MostrarVehiculosTabla();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtFicha.Clear();
            txtPlaca.Clear();
            txtCapacidad.Clear();
            idVehiculo = 0;
            txtFicha.Focus();

            btnGuardar.Enabled = true;
            btnActualizar.Enabled = false;
        }

        private void dgvVehiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idVehiculo = Convert.ToInt32(dgvVehiculos.CurrentRow.Cells["ID_Vehiculo"].Value);
                txtFicha.Text = dgvVehiculos.CurrentRow.Cells["Ficha"].Value.ToString();
                txtPlaca.Text = dgvVehiculos.CurrentRow.Cells["Placa"].Value.ToString();
                txtCapacidad.Text = dgvVehiculos.CurrentRow.Cells["Capacidad"].Value.ToString();

                btnGuardar.Enabled = false;
                btnActualizar.Enabled = true;
            }
        }

        // --- Estética OMSA ---

        private void AplicarEstiloTabla()
        {
            // 1. ELIMINAR FILA FANTASMA
            dgvVehiculos.AllowUserToAddRows = false;

            // 2. LIMPIEZA DE LÍNEAS
            dgvVehiculos.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvVehiculos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // 3. INTEGRACIÓN VISUAL
            dgvVehiculos.BackgroundColor = Color.White;
            dgvVehiculos.BorderStyle = BorderStyle.None;

            // 4. COMPORTAMIENTO
            dgvVehiculos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVehiculos.MultiSelect = false;
            dgvVehiculos.ReadOnly = true;

            // 5. ESTILO GENERAL
            dgvVehiculos.RowHeadersVisible = false;
            dgvVehiculos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVehiculos.EnableHeadersVisualStyles = false;

            // 6. ENCABEZADOS (Estilo OMSA - Corregido para evitar el azul)
            dgvVehiculos.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#404040");
            dgvVehiculos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // ESTAS LÍNEAS ELIMINAN EL RESALTADO AZUL AL HACER CLIC
            dgvVehiculos.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#404040");
            dgvVehiculos.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            dgvVehiculos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvVehiculos.ColumnHeadersHeight = 40;

            // 7. FILAS (Fuente y Colores)
            dgvVehiculos.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvVehiculos.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#E0F2E9");
            dgvVehiculos.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvVehiculos.RowTemplate.Height = 35;

            // 8. NOMBRES DE COLUMNAS
            if (dgvVehiculos.Columns.Count > 0)
            {
                if (dgvVehiculos.Columns.Contains("ID_Vehiculo")) dgvVehiculos.Columns["ID_Vehiculo"].HeaderText = "ID";
                if (dgvVehiculos.Columns.Contains("Ficha")) dgvVehiculos.Columns["Ficha"].HeaderText = "Ficha OMSA";
                if (dgvVehiculos.Columns.Contains("Placa")) dgvVehiculos.Columns["Placa"].HeaderText = "Placa";
                if (dgvVehiculos.Columns.Contains("Capacidad")) dgvVehiculos.Columns["Capacidad"].HeaderText = "Capacidad";
            }

            // Quitar flecha de ordenamiento
            foreach (DataGridViewColumn columna in dgvVehiculos.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        // Validación para que solo entren números en capacidad
        private void txtCapacidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}