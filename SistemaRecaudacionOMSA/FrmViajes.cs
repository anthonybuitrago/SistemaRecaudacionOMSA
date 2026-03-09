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
    }
}