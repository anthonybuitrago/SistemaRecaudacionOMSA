using System;
using System.Windows.Forms;
using CapaNegocios;

namespace SistemaRecaudacionOMSA
{
    public partial class FrmVehiculos : Form
    {
        // Instancia de la Capa de Negocio para manejar la lógica de vehículos
        private N_Vehiculo objNegocio = new N_Vehiculo();

        public FrmVehiculos()
        {
            InitializeComponent();
        }

        private void FrmVehiculos_Load(object sender, EventArgs e)
        {
            MostrarVehiculosTabla();
        }

        // Carga los datos de los autobuses en el DataGridView
        private void MostrarVehiculosTabla()
        {
            try
            {
                dgvVehiculos.DataSource = objNegocio.MostrarVehiculos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la tabla: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardarVehiculo_Click(object sender, EventArgs e)
        {
            // 1. Validación: Verificamos que los TextBox no estén vacíos
            // IMPORTANTE: Usamos txtPlaca, no label2
            if (string.IsNullOrWhiteSpace(txtFicha.Text) ||
                string.IsNullOrWhiteSpace(txtPlaca.Text) ||
                string.IsNullOrWhiteSpace(txtCapacidad.Text))
            {
                MessageBox.Show("Por favor, llena todos los datos del autobús.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. Ejecución: Enviamos los datos a la Capa de Negocio
                objNegocio.InsertarVehiculo(txtFicha.Text, txtPlaca.Text, txtCapacidad.Text);

                // 3. Respuesta: Informamos al usuario y refrescamos la interfaz
                MessageBox.Show("Autobús guardado exitosamente en el sistema.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                MostrarVehiculosTabla();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Restablece los controles del formulario para una nueva entrada
        private void LimpiarCampos()
        {
            txtFicha.Clear();
            txtPlaca.Clear();
            txtCapacidad.Clear();

            txtFicha.Focus(); // Coloca el foco en el primer campo para mayor agilidad
        }
    }
}