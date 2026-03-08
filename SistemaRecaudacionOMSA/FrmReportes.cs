using System;
using System.Windows.Forms;
using CapaNegocios;

namespace SistemaRecaudacionOMSA
{
    public partial class FrmReportes : Form
    {
        // Instancia de la Capa de Negocio para Reportes
        private N_Reporte objReporte = new N_Reporte();

        public FrmReportes()
        {
            InitializeComponent();
        }

        // Se ejecuta al abrir la ventana de reportes
        private void FrmReportes_Load(object sender, EventArgs e)
        {
            CargarReporteRecaudacion();
        }

        // Método para llenar la tabla con la recaudación
        private void CargarReporteRecaudacion()
        {
            try
            {
                // Vincula los datos calculados en SQL al DataGridView
                dgvReporte.DataSource = objReporte.MostrarRecaudacionRuta();
            }
            catch (Exception ex)
            {
                // Informa si hubo un error en la consulta o conexión
                MessageBox.Show("Error al generar el reporte: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}