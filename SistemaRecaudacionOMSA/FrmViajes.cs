using System;
using System.Windows.Forms;
using CapaNegocios;

namespace SistemaRecaudacionOMSA
{
    public partial class FrmViajes : Form
    {
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
            LlenarListas();
            MostrarViajesTabla();
        }
        private void MostrarViajesTabla()
        {
            dgvViajes.DataSource = objViaje.MostrarViajes();
        }
        private void LlenarListas()
        {
            cmbChofer.DataSource = objChofer.MostrarChoferes();
            cmbChofer.DisplayMember = "NombreCompleto";
            cmbChofer.ValueMember = "ID_Chofer";        
            cmbRuta.DataSource = objRuta.MostrarRutas();
            cmbRuta.DisplayMember = "NombreRuta";
            cmbRuta.ValueMember = "ID_Ruta";
            cmbVehiculo.DataSource = objVehiculo.MostrarVehiculos();
            cmbVehiculo.DisplayMember = "Placa";
            cmbVehiculo.ValueMember = "ID_Vehiculo";
        }
        private void btnGuardarViaje_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEstado.Text))
            {
                MessageBox.Show("Por favor, ingresa el estado del viaje (Ej: Completado, En Ruta).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string idChofer = cmbChofer.SelectedValue.ToString();
                string idRuta = cmbRuta.SelectedValue.ToString();
                string idVehiculo = cmbVehiculo.SelectedValue.ToString();

                DateTime fecha = dtpFecha.Value;
                string estado = txtEstado.Text;

                objViaje.InsertarViaje(idChofer, idRuta, idVehiculo, fecha, estado);

                MessageBox.Show("Viaje registrado exitosamente en el sistema.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MostrarViajesTabla();

                txtEstado.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvViajes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}