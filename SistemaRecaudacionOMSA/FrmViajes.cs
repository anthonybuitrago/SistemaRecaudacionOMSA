using System;
using System.Windows.Forms;
using CapaNegocios;

namespace SistemaRecaudacionOMSA
{
    public partial class FrmViajes : Form
    {
        // Instancias de la Capa de Negocio necesarias para este formulario
        private N_Viaje objViaje = new N_Viaje();
        private N_Chofer objChofer = new N_Chofer();
        private N_Ruta objRuta = new N_Ruta();
        private N_Vehiculo objVehiculo = new N_Vehiculo();

        public FrmViajes()
        {
            InitializeComponent();
        }

        private void FrmViajes_Load(object sender, EventArgs e)
        {
            CargarInformacionInicial();
        }

        // Centraliza la carga de datos al abrir el formulario
        private void CargarInformacionInicial()
        {
            try
            {
                LlenarListasDesplegables();
                MostrarViajesTabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al inicializar el formulario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para cargar los DataGridView
        private void MostrarViajesTabla()
        {
            dgvViajes.DataSource = objViaje.MostrarViajes();
        }

        // Configura los ComboBox con los datos de Choferes, Rutas y Vehículos
        private void LlenarListasDesplegables()
        {
            // Cargar Choferes
            cmbChofer.DataSource = objChofer.MostrarChoferes();
            cmbChofer.DisplayMember = "NombreCompleto";
            cmbChofer.ValueMember = "ID_Chofer";

            // Cargar Rutas
            cmbRuta.DataSource = objRuta.MostrarRutas();
            cmbRuta.DisplayMember = "NombreRuta";
            cmbRuta.ValueMember = "ID_Ruta";

            // Cargar Vehículos (Usamos Placa como acordamos)
            cmbVehiculo.DataSource = objVehiculo.MostrarVehiculos();
            cmbVehiculo.DisplayMember = "Placa";
            cmbVehiculo.ValueMember = "ID_Vehiculo";
        }

        private void btnGuardarViaje_Click(object sender, EventArgs e)
        {
            // 1. Validación de campos obligatorios
            if (string.IsNullOrWhiteSpace(txtEstado.Text))
            {
                MessageBox.Show("Por favor, ingresa el estado del viaje.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. Captura de datos desde los controles
                string idChofer = cmbChofer.SelectedValue.ToString();
                string idRuta = cmbRuta.SelectedValue.ToString();
                string idVehiculo = cmbVehiculo.SelectedValue.ToString();
                DateTime fecha = dtpFecha.Value;
                string estado = txtEstado.Text;

                // 3. Ejecución a través de la Capa de Negocio
                objViaje.InsertarViaje(idChofer, idRuta, idVehiculo, fecha, estado);

                // 4. Confirmación y limpieza
                MessageBox.Show("Viaje registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MostrarViajesTabla();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el viaje: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Limpia la interfaz para un nuevo registro
        private void LimpiarCampos()
        {
            txtEstado.Clear();
            cmbChofer.SelectedIndex = 0;
            cmbRuta.SelectedIndex = 0;
            cmbVehiculo.SelectedIndex = 0;
            dtpFecha.Value = DateTime.Now;
            txtEstado.Focus();
        }
    }
}