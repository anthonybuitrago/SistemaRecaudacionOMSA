using System;
using System.Windows.Forms;
using CapaNegocios;

namespace SistemaRecaudacionOMSA
{
    public partial class FrmRutas : Form
    {
        private N_Ruta objNegocio = new N_Ruta();

        public FrmRutas()
        {
            InitializeComponent();
        }

        private void FrmRutas_Load(object sender, EventArgs e)
        {
            MostrarRutasTabla();
        }

        private void MostrarRutasTabla()
        {
            dgvRutas.DataSource = objNegocio.MostrarRutas();
        }

        private void btnGuardarRuta_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreRuta.Text) || string.IsNullOrWhiteSpace(txtDetalle.Text))
            {
                MessageBox.Show("Por favor, llena todos los datos de la ruta.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                objNegocio.InsertarRuta(txtNombreRuta.Text, txtDetalle.Text);
                MessageBox.Show("Ruta guardada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MostrarRutasTabla();
                txtNombreRuta.Clear();
                txtDetalle.Clear();
                txtNombreRuta.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error (¿Quizás los nombres de las columnas en SQL son diferentes?): " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}