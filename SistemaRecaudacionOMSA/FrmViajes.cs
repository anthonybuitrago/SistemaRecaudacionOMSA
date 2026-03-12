using System;
using System.Drawing;
using System.Windows.Forms;
using CapaNegocios;

namespace SistemaRecaudacionOMSA
{
    public partial class FrmViajes : Form
    {
        // Instancias de todas las capas de negocio que necesitamos aquí
        private N_Viaje objViaje = new N_Viaje();
        private N_Chofer objChofer = new N_Chofer();
        private N_Ruta objRuta = new N_Ruta();
        private N_Vehiculo objVehiculo = new N_Vehiculo();

        private int idViaje = 0;

        public FrmViajes()
        {
            InitializeComponent();
        }

        private void FrmViajes_Load(object sender, EventArgs e)
        {
            // 1. Ponemos el estado por defecto y lo bloqueamos
            txtEstado.Text = "Activo";
            txtEstado.ReadOnly = true;

            // 2. Cargamos los datos de la base de datos a los ComboBox
            CargarListasDesplegables();

            // 3. AQUÍ LO COLOCAS: Carga la tabla apenas se abre el formulario
            MostrarViajesTabla();
        }

        private void CargarListasDesplegables()
        {
            try
            {
                // --- Llenar ComboBox de Choferes ---
                cmbChofer.DataSource = objChofer.MostrarChoferes();
                cmbChofer.DisplayMember = "NombreCompleto"; // ¡Aquí está la corrección clave!
                cmbChofer.ValueMember = "ID_Chofer";

                // --- Llenar ComboBox de Rutas ---
                cmbRuta.DataSource = objRuta.MostrarRutas();
                cmbRuta.DisplayMember = "NombreRuta"; // Usamos el nombre de la columna real
                cmbRuta.ValueMember = "ID_Ruta";

                // --- Llenar ComboBox de Vehículos ---
                cmbVehiculo.DataSource = objVehiculo.MostrarVehiculos();
                cmbVehiculo.DisplayMember = "Ficha";
                cmbVehiculo.ValueMember = "ID_Vehiculo";
                // --- Quitar la selección por defecto ---
                cmbChofer.SelectedIndex = -1;
                cmbRuta.SelectedIndex = -1;
                cmbVehiculo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las listas: " + ex.Message, "Error");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // 1. Validar que se haya seleccionado todo
            if (cmbChofer.SelectedValue == null || cmbRuta.SelectedValue == null || cmbVehiculo.SelectedValue == null)
            {
                MessageBox.Show("Por favor, asegúrese de seleccionar Chofer, Ruta y Vehículo.", "Aviso OMSA");
                return;
            }

            try
            {
                // 2. Extraer los IDs como texto para que coincidan con tu N_Viaje
                string idChofer = cmbChofer.SelectedValue.ToString();
                string idRuta = cmbRuta.SelectedValue.ToString();
                string idVehiculo = cmbVehiculo.SelectedValue.ToString();
                DateTime fechaViaje = dtpFecha.Value;
                string estado = txtEstado.Text;

                // 3. Enviar a la Capa de Negocio
                objViaje.InsertarViaje(idChofer, idRuta, idVehiculo, fechaViaje, estado);

                MessageBox.Show("¡Viaje registrado exitosamente!", "Éxito");

                // 4. Actualizar la tabla y limpiar (crearemos el método ahora)
                MostrarViajesTabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error");
            }
        }

        private void MostrarViajesTabla()
        {
            try
            {
                dgvViajes.DataSource = objViaje.MostrarViajes();
                AplicarEstiloTabla(); // <--- ¡AÑADE ESTA LÍNEA AQUÍ!
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la tabla: " + ex.Message);
            }
        }

        private void AplicarEstiloTabla()
        {
            // 1. Configuraciones básicas y fondo
            dgvViajes.AllowUserToAddRows = false;
            dgvViajes.RowHeadersVisible = false;
            dgvViajes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvViajes.BackgroundColor = Color.White;
            dgvViajes.BorderStyle = BorderStyle.None;

            // 2. Quitar bordes (para que quede plano y limpio)
            dgvViajes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvViajes.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvViajes.GridColor = Color.Gainsboro;

            // 3. Diseño del Encabezado (Gris oscuro OMSA)
            dgvViajes.EnableHeadersVisualStyles = false;
            dgvViajes.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#404040");
            dgvViajes.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#404040");
            dgvViajes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvViajes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvViajes.ColumnHeadersHeight = 40;

            // 4. Diseño de las Filas y Selección (Verde claro)
            dgvViajes.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvViajes.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#E0F2E9"); // Verde muy clarito
            dgvViajes.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvViajes.RowTemplate.Height = 35;

            // 5. Ajuste de ancho de columnas específico (Opcional)
            if (dgvViajes.Columns.Count > 0)
            {
                dgvViajes.Columns["ID"].Width = 40; // Hace la columna de ID más pequeña
                                                    // dgvViajes.Columns["ID"].Visible = false; // Descomenta esta línea si prefieres ocultar el ID
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Deseleccionamos los ComboBox
            cmbChofer.SelectedIndex = -1;
            cmbRuta.SelectedIndex = -1;
            cmbVehiculo.SelectedIndex = -1;

            // Reseteamos fecha y estado
            dtpFecha.Value = DateTime.Now;
            txtEstado.Text = "Activo";

            // Habilitamos el botón guardar por si estábamos en modo edición
            btnGuardar.Enabled = true;
            // btnActualizar.Enabled = false; (Descomenta esto si lo vas a usar)
        }

        private void dgvViajes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // 1. Guardar el ID
                idViaje = Convert.ToInt32(dgvViajes.Rows[e.RowIndex].Cells["ID"].Value);

                // 2. Pasar los textos de la tabla a los controles visuales
                cmbChofer.Text = dgvViajes.Rows[e.RowIndex].Cells["Chofer"].Value.ToString();
                cmbRuta.Text = dgvViajes.Rows[e.RowIndex].Cells["Ruta"].Value.ToString();
                cmbVehiculo.Text = dgvViajes.Rows[e.RowIndex].Cells["Ficha del Vehículo"].Value.ToString();
                dtpFecha.Value = Convert.ToDateTime(dgvViajes.Rows[e.RowIndex].Cells["Fecha y Hora"].Value);
                txtEstado.Text = dgvViajes.Rows[e.RowIndex].Cells["Estado"].Value.ToString();

                // 3. UX: Cambiar de modo "Nuevo" a modo "Edición"
                btnGuardar.Enabled = false;
                btnActualizar.Enabled = true; // Activa el amarillo
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // 1. Validar que haya seleccionado algo
            if (idViaje == 0)
            {
                MessageBox.Show("Por favor, seleccione un viaje de la tabla primero.", "Aviso OMSA");
                return;
            }

            // 2. Pedir confirmación al usuario
            DialogResult respuesta = MessageBox.Show("¿Está seguro de que desea cancelar este viaje? Ya no aparecerá disponible para vender tickets.", "Confirmar Cancelación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    // 3. Enviar la orden a la Capa de Negocio
                    objViaje.CancelarViaje(idViaje.ToString());

                    MessageBox.Show("El viaje ha sido cancelado exitosamente.", "Operación Exitosa");

                    // 4. Refrescar la tabla y limpiar
                    MostrarViajesTabla();
                    idViaje = 0; // Reseteamos el ID
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cancelar el viaje: " + ex.Message, "Error del Sistema");
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (idViaje == 0)
            {
                MessageBox.Show("Por favor, seleccione un viaje de la tabla para actualizar.", "Aviso OMSA");
                return;
            }

            if (cmbChofer.SelectedValue == null || cmbRuta.SelectedValue == null || cmbVehiculo.SelectedValue == null)
            {
                MessageBox.Show("Asegúrese de que Chofer, Ruta y Vehículo estén seleccionados.", "Aviso OMSA");
                return;
            }

            try
            {
                // 1. Tomamos los IDs ocultos de los ComboBox
                string idChof = cmbChofer.SelectedValue.ToString();
                string idRut = cmbRuta.SelectedValue.ToString();
                string idVeh = cmbVehiculo.SelectedValue.ToString();
                DateTime fecha = dtpFecha.Value;
                string estado = txtEstado.Text;

                // 2. Mandamos a actualizar
                objViaje.EditarViaje(idViaje.ToString(), idChof, idRut, idVeh, fecha, estado);
                MessageBox.Show("¡Viaje actualizado exitosamente!", "Operación Exitosa");

                // 3. Refrescar la tabla y limpiar la pantalla
                MostrarViajesTabla();
                btnLimpiar_Click(null, null); // Llamamos al botón limpiar para que resetee todo
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el viaje: " + ex.Message, "Error del Sistema");
            }
        }
    }
}