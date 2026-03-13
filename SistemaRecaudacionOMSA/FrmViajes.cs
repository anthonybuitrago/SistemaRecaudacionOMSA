using System;
using System.Drawing;
using System.Windows.Forms;
using CapaNegocios;

namespace SistemaRecaudacionOMSA
{
    public partial class FrmViajes : Form
    {
        // Instancias para acceder a la lógica de todas las entidades relacionadas
        private N_Viaje objViaje = new N_Viaje();
        private N_Chofer objChofer = new N_Chofer();
        private N_Ruta objRuta = new N_Ruta();
        private N_Vehiculo objVehiculo = new N_Vehiculo();

        // Variable para identificar el viaje seleccionado en la tabla
        private int idViaje = 0;

        // Constructor del formulario
        public FrmViajes()
        {
            InitializeComponent();
        }

        // Evento inicial que configura el estado por defecto y carga los datos
        private void FrmViajes_Load(object sender, EventArgs e)
        {
            txtEstado.Text = "Activo";
            txtEstado.ReadOnly = true;

            // Carga de información en los selectores y la tabla
            CargarListasDesplegables();
            MostrarViajesTabla();
        }

        // Método para llenar los ComboBox con datos reales de la base de datos
        private void CargarListasDesplegables()
        {
            try
            {
                // Configuración del selector de Choferes
                cmbChofer.DataSource = objChofer.MostrarChoferes();
                cmbChofer.DisplayMember = "NombreCompleto";
                cmbChofer.ValueMember = "ID_Chofer";

                // Configuración del selector de Rutas
                cmbRuta.DataSource = objRuta.MostrarRutas();
                cmbRuta.DisplayMember = "NombreRuta";
                cmbRuta.ValueMember = "ID_Ruta";

                // Configuración del selector de Vehículos
                cmbVehiculo.DataSource = objVehiculo.MostrarVehiculos();
                cmbVehiculo.DisplayMember = "Ficha";
                cmbVehiculo.ValueMember = "ID_Vehiculo";

                // Limpieza de selecciones automáticas al iniciar
                cmbChofer.SelectedIndex = -1;
                cmbRuta.SelectedIndex = -1;
                cmbVehiculo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las listas: " + ex.Message, "Error");
            }
        }

        // Evento para registrar un nuevo viaje cruzando los IDs seleccionados
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validación de selección completa en los ComboBox
            if (cmbChofer.SelectedValue == null || cmbRuta.SelectedValue == null || cmbVehiculo.SelectedValue == null)
            {
                MessageBox.Show("Por favor, asegúrese de seleccionar Chofer, Ruta y Vehículo.", "Aviso OMSA");
                return;
            }

            try
            {
                // Captura de datos para enviar a la Capa de Negocio
                string idChofer = cmbChofer.SelectedValue.ToString();
                string idRuta = cmbRuta.SelectedValue.ToString();
                string idVehiculo = cmbVehiculo.SelectedValue.ToString();
                DateTime fechaViaje = dtpFecha.Value;
                string estado = txtEstado.Text;

                objViaje.InsertarViaje(idChofer, idRuta, idVehiculo, fechaViaje, estado);

                MessageBox.Show("¡Viaje registrado exitosamente!", "Éxito");
                MostrarViajesTabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error");
            }
        }

        // Método para refrescar los datos de la tabla visualmente
        private void MostrarViajesTabla()
        {
            try
            {
                dgvViajes.DataSource = objViaje.MostrarViajes();
                AplicarEstiloTabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la tabla: " + ex.Message);
            }
        }

        // Método para personalizar el diseño corporativo de la tabla
        private void AplicarEstiloTabla()
        {
            // Configuración de visualización y fondo
            dgvViajes.AllowUserToAddRows = false;
            dgvViajes.RowHeadersVisible = false;
            dgvViajes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvViajes.BackgroundColor = Color.White;
            dgvViajes.BorderStyle = BorderStyle.None;

            // Estilo de bordes y líneas divisorias
            dgvViajes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvViajes.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvViajes.GridColor = Color.Gainsboro;

            // Diseño de los encabezados (Gris OMSA)
            dgvViajes.EnableHeadersVisualStyles = false;
            dgvViajes.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#404040");
            dgvViajes.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#404040");
            dgvViajes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvViajes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvViajes.ColumnHeadersHeight = 40;

            // Diseño de filas y colores de selección
            dgvViajes.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvViajes.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#E0F2E9");
            dgvViajes.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvViajes.RowTemplate.Height = 35;

            // Ajuste manual de ancho de columnas
            if (dgvViajes.Columns.Count > 0)
            {
                dgvViajes.Columns["ID"].Width = 40;
            }
        }

        // Evento para resetear el formulario al estado original
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cmbChofer.SelectedIndex = -1;
            cmbRuta.SelectedIndex = -1;
            cmbVehiculo.SelectedIndex = -1;
            dtpFecha.Value = DateTime.Now;
            txtEstado.Text = "Activo";
            btnGuardar.Enabled = true;
        }

        // Evento para capturar los datos de la fila seleccionada y editarlos
        private void dgvViajes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Mapeo de datos desde la tabla hacia los controles visuales
                idViaje = Convert.ToInt32(dgvViajes.Rows[e.RowIndex].Cells["ID"].Value);
                cmbChofer.Text = dgvViajes.Rows[e.RowIndex].Cells["Chofer"].Value.ToString();
                cmbRuta.Text = dgvViajes.Rows[e.RowIndex].Cells["Ruta"].Value.ToString();
                cmbVehiculo.Text = dgvViajes.Rows[e.RowIndex].Cells["Ficha del Vehículo"].Value.ToString();
                dtpFecha.Value = Convert.ToDateTime(dgvViajes.Rows[e.RowIndex].Cells["Fecha y Hora"].Value);
                txtEstado.Text = dgvViajes.Rows[e.RowIndex].Cells["Estado"].Value.ToString();

                // Cambio a modo edición
                btnGuardar.Enabled = false;
                btnActualizar.Enabled = true;
            }
        }

        // Evento para realizar el borrado lógico del viaje (Cancelación)
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (idViaje == 0)
            {
                MessageBox.Show("Por favor, seleccione un viaje de la tabla primero.", "Aviso OMSA");
                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Está seguro de que desea cancelar este viaje?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    objViaje.CancelarViaje(idViaje.ToString());
                    MessageBox.Show("El viaje ha sido cancelado exitosamente.");
                    MostrarViajesTabla();
                    idViaje = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cancelar: " + ex.Message);
                }
            }
        }

        // Evento para actualizar los datos de un viaje existente
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (idViaje == 0)
            {
                MessageBox.Show("Por favor, seleccione un viaje para actualizar.", "Aviso OMSA");
                return;
            }

            if (cmbChofer.SelectedValue == null || cmbRuta.SelectedValue == null || cmbVehiculo.SelectedValue == null)
            {
                MessageBox.Show("Asegúrese de que todos los campos estén seleccionados.", "Aviso OMSA");
                return;
            }

            try
            {
                // Envío de la actualización a la Capa de Negocio
                string idChof = cmbChofer.SelectedValue.ToString();
                string idRut = cmbRuta.SelectedValue.ToString();
                string idVeh = cmbVehiculo.SelectedValue.ToString();
                DateTime fecha = dtpFecha.Value;
                string estado = txtEstado.Text;

                objViaje.EditarViaje(idViaje.ToString(), idChof, idRut, idVeh, fecha, estado);
                MessageBox.Show("¡Viaje actualizado exitosamente!");

                MostrarViajesTabla();
                btnLimpiar_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message);
            }
        }
    }
}