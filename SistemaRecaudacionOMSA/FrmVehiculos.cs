using System;
using System.Windows.Forms;
using CapaNegocios;

namespace SistemaRecaudacionOMSA
{
    public partial class FrmVehiculos : Form
    {
        private N_Vehiculo objNegocio = new N_Vehiculo();

        public FrmVehiculos()
        {
            InitializeComponent();
        }

        private void FrmVehiculos_Load(object sender, EventArgs e)
        {
            MostrarVehiculosTabla();
        }

        private void MostrarVehiculosTabla()
        {
            dgvVehiculos.DataSource = objNegocio.MostrarVehiculos();
        }

        private void btnGuardarVehiculo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFicha.Text) || string.IsNullOrWhiteSpace(txtMarca.Text) || string.IsNullOrWhiteSpace(txtCapacidad.Text))
            {
                MessageBox.Show("Por favor, llena todos los datos del vehículo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                objNegocio.InsertarVehiculo(txtFicha.Text, txtMarca.Text, txtCapacidad.Text);
                MessageBox.Show("Autobús guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MostrarVehiculosTabla();

                txtFicha.Clear();
                txtMarca.Clear();
                txtCapacidad.Clear();
                txtFicha.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error. Verifica que ingresaste un número en la capacidad y que las columnas de SQL coincidan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}