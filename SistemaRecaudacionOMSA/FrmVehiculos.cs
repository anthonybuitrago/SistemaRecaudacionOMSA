using CapaNegocios;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaRecaudacionOMSA
{
    public partial class FrmVehiculos : Form
    {
        // Instancia para la comunicación con la Capa de Negocio
        private N_Vehiculo objNegocio = new N_Vehiculo();

        // Variable para almacenar el ID del vehículo seleccionado
        private int idVehiculo = 0;

        // Constructor que inicializa los componentes de la ventana
        public FrmVehiculos()
        {
            InitializeComponent();
        }

        // Evento que carga los datos al abrir la ventana
        private void FrmVehiculos_Load(object sender, EventArgs e)
        {
            MostrarVehiculosTabla();
            LimpiarCampos();
        }

        // Método para solicitar y mostrar la lista de vehículos registrados
        private void MostrarVehiculosTabla()
        {
            dgvVehiculos.DataSource = objNegocio.MostrarVehiculos();
            AplicarEstiloTabla();
        }

        // Evento para registrar un nuevo vehículo en el sistema
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validación de campos obligatorios
            if (string.IsNullOrWhiteSpace(txtFicha.Text) || string.IsNullOrWhiteSpace(txtPlaca.Text) || string.IsNullOrWhiteSpace(txtCapacidad.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos del vehículo.", "Aviso");
                return;
            }

            try
            {
                // Validación de lógica de negocio (capacidad positiva)
                if (Convert.ToInt32(txtCapacidad.Text) <= 0)
                {
                    MessageBox.Show("La capacidad debe ser mayor a cero.", "Validación");
                    return;
                }

                // Envío de datos a la Capa de Negocio
                objNegocio.InsertarVehiculo(txtFicha.Text, txtPlaca.Text, txtCapacidad.Text);
                MessageBox.Show("Vehículo guardado con éxito.", "Éxito");

                // Refresco visual y limpieza
                MostrarVehiculosTabla();
                btnLimpiar.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        // Evento para guardar las modificaciones de un vehículo existente
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // Validación de selección previa
            if (idVehiculo == 0)
            {
                MessageBox.Show("Seleccione un vehículo de la tabla.", "Aviso");
                return;
            }

            try
            {
                // Envío de la actualización a la Capa de Negocio
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

        // Evento para borrar permanentemente un vehículo tras confirmar
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Validación de selección previa
            if (idVehiculo == 0)
            {
                MessageBox.Show("Seleccione un vehículo.", "Aviso");
                return;
            }

            // Confirmación de seguridad
            DialogResult respuesta = MessageBox.Show("¿Está seguro de eliminar este vehículo?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    // Petición de eliminación a la Capa de Negocio
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

        // Evento para reiniciar manualmente el formulario
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        // Método para vaciar los campos y resetear el estado visual de los botones
        private void LimpiarCampos()
        {
            txtFicha.Clear();
            txtPlaca.Clear();
            txtCapacidad.Clear();
            idVehiculo = 0;
            txtFicha.Focus();

            // Configuración para modo "Nuevo Registro"
            btnGuardar.Enabled = true;
            btnActualizar.Enabled = false;
        }

        // Evento para seleccionar un registro y cargarlo en los campos para edición
        private void dgvVehiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Extracción de datos de la fila seleccionada
                idVehiculo = Convert.ToInt32(dgvVehiculos.CurrentRow.Cells["ID_Vehiculo"].Value);
                txtFicha.Text = dgvVehiculos.CurrentRow.Cells["Ficha"].Value.ToString();
                txtPlaca.Text = dgvVehiculos.CurrentRow.Cells["Placa"].Value.ToString();
                txtCapacidad.Text = dgvVehiculos.CurrentRow.Cells["Capacidad"].Value.ToString();

                // Configuración para modo "Edición"
                btnGuardar.Enabled = false;
                btnActualizar.Enabled = true;
            }
        }

        // Método para personalizar la apariencia visual y corporativa de la tabla
        private void AplicarEstiloTabla()
        {
            // Configuración de estructura y bordes
            dgvVehiculos.AllowUserToAddRows = false;
            dgvVehiculos.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvVehiculos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvVehiculos.BackgroundColor = Color.White;
            dgvVehiculos.BorderStyle = BorderStyle.None;

            // Comportamiento de selección
            dgvVehiculos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVehiculos.MultiSelect = false;
            dgvVehiculos.ReadOnly = true;

            // Configuración visual general
            dgvVehiculos.RowHeadersVisible = false;
            dgvVehiculos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVehiculos.EnableHeadersVisualStyles = false;

            // Estilo de los encabezados (Gris OMSA)
            dgvVehiculos.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#404040");
            dgvVehiculos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvVehiculos.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#404040");
            dgvVehiculos.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dgvVehiculos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvVehiculos.ColumnHeadersHeight = 40;

            // Estilo de las filas y colores de selección
            dgvVehiculos.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvVehiculos.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#E0F2E9");
            dgvVehiculos.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvVehiculos.RowTemplate.Height = 35;

            // Renombramiento de las cabeceras para el usuario
            if (dgvVehiculos.Columns.Count > 0)
            {
                if (dgvVehiculos.Columns.Contains("ID_Vehiculo")) dgvVehiculos.Columns["ID_Vehiculo"].HeaderText = "ID";
                if (dgvVehiculos.Columns.Contains("Ficha")) dgvVehiculos.Columns["Ficha"].HeaderText = "Ficha OMSA";
                if (dgvVehiculos.Columns.Contains("Placa")) dgvVehiculos.Columns["Placa"].HeaderText = "Placa";
                if (dgvVehiculos.Columns.Contains("Capacidad")) dgvVehiculos.Columns["Capacidad"].HeaderText = "Capacidad";
            }

            // Desactivar el ordenamiento automático
            foreach (DataGridViewColumn columna in dgvVehiculos.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        // Restricción para permitir únicamente la entrada de números
        private void txtCapacidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}