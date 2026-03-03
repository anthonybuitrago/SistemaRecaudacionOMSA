using System;
using System.Windows.Forms;
using CapaNegocios;

namespace SistemaRecaudacionOMSA
{
    public partial class FrmChoferes : Form
    {
        private N_Chofer objNegocio = new N_Chofer();
        public FrmChoferes()
        {
            InitializeComponent();
        }
        private void FrmChoferes_Load(object sender, EventArgs e)
        {
            MostrarChoferesTabla();
        }
        private void MostrarChoferesTabla()
        {
            dgvChoferes.DataSource = objNegocio.MostrarChoferes();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCedula.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtLicencia.Text))
            {
                MessageBox.Show("Por favor, no dejes campos vacíos. Llena todos los datos del chofer.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                objNegocio.InsertarChofer(txtCedula.Text, txtNombre.Text, txtLicencia.Text);
                MessageBox.Show("Chofer guardado exitosamente en la base de datos de OMSA.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MostrarChoferesTabla();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimpiarCampos()
        {
            txtCedula.Clear();
            txtNombre.Clear();
            txtLicencia.Clear();
            txtCedula.Focus();
        }
    }
}