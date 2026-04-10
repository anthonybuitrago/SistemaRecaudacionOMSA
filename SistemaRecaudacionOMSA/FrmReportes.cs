using CapaNegocios;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaRecaudacionOMSA
{
    // Visualización de reportes operativos y financieros
    public partial class FrmReportes : Form
    {
        // Instancia de la capa de negocios
        private N_Reporte objReporte = new N_Reporte();

        public FrmReportes()
        {
            InitializeComponent();

            // Expansión automática de la cuadrícula al contenedor
            dgvReporte.Dock = DockStyle.Fill;
        }

        // Evento de inicialización del formulario
        private async void FrmReportes_Load(object sender, EventArgs e)
        {
            // Carga asíncrona para no bloquear la interfaz
            await CargarReporteRecaudacionAsync();
        }

        // ==========================================================
        // CARGA DE DATOS Y FORMATEO
        // ==========================================================

        // Obtiene los datos consolidados y aplica formato visual
        private async Task CargarReporteRecaudacionAsync()
        {
            try
            {
                dgvReporte.DataSource = await objReporte.MostrarRecaudacionRutaAsync();

                AplicarEstiloTabla();

                // Formateo de métricas de flujo de pasajeros
                if (dgvReporte.Columns["Pasajeros"] != null)
                {
                    dgvReporte.Columns["Pasajeros"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                // Formateo de métricas financieras
                if (dgvReporte.Columns["Total Recaudado RD$"] != null)
                {
                    var columnaDinero = dgvReporte.Columns["Total Recaudado RD$"];

                    columnaDinero.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    columnaDinero.DefaultCellStyle.Format = "N2";
                    columnaDinero.DefaultCellStyle.ForeColor = Color.LightGreen;
                    columnaDinero.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte: " + ex.Message, "Error de Reporte", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================================
        // DISEÑO VISUAL
        // ==========================================================

        // Aplica el diseño corporativo (Dark Mode) a la cuadrícula
        private void AplicarEstiloTabla()
        {
            dgvReporte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReporte.RowHeadersVisible = false;
            dgvReporte.BorderStyle = BorderStyle.None;
            dgvReporte.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvReporte.GridColor = Color.FromArgb(64, 64, 64);

            dgvReporte.EnableHeadersVisualStyles = false;
            dgvReporte.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvReporte.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dgvReporte.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvReporte.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvReporte.ColumnHeadersHeight = 40;

            dgvReporte.DefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
            dgvReporte.DefaultCellStyle.ForeColor = Color.White;
            dgvReporte.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dgvReporte.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvReporte.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvReporte.RowTemplate.Height = 35;
        }
    }
}