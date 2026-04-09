using CapaNegocios;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaRecaudacionOMSA
{
    // Formulario de visualización de reportes operativos y financieros
    public partial class FrmReportes : Form
    {
        private N_Reporte objReporte = new N_Reporte();

        public FrmReportes()
        {
            InitializeComponent();

            // Configura la tabla para que ocupe todo el espacio disponible en el panel contenedor
            dgvReporte.Dock = DockStyle.Fill;
        }

        private async void FrmReportes_Load(object sender, EventArgs e)
        {
            await CargarReporteRecaudacionAsync();
        }

        // Obtiene los datos consolidados de recaudación y aplica el formato visual financiero
        private async Task CargarReporteRecaudacionAsync()
        {
            try
            {
                dgvReporte.DataSource = await objReporte.MostrarRecaudacionRutaAsync();

                AplicarEstiloTabla();

                // Formateo avanzado de columnas financieras y de conteo
                if (dgvReporte.Columns["Pasajeros"] != null)
                {
                    dgvReporte.Columns["Pasajeros"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                if (dgvReporte.Columns["Total Recaudado RD$"] != null)
                {
                    var columnaDinero = dgvReporte.Columns["Total Recaudado RD$"];

                    // Formato de moneda y alineación contable
                    columnaDinero.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    columnaDinero.DefaultCellStyle.Format = "N2"; // Formato numérico con dos decimales

                    // Resaltado visual para métricas financieras
                    columnaDinero.DefaultCellStyle.ForeColor = Color.LightGreen;
                    columnaDinero.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte: " + ex.Message, "Error de Reporte", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Aplica el diseño visual oscuro y profesional a la cuadrícula de datos
        private void AplicarEstiloTabla()
        {
            dgvReporte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReporte.RowHeadersVisible = false;
            dgvReporte.BorderStyle = BorderStyle.None;
            dgvReporte.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvReporte.GridColor = Color.FromArgb(64, 64, 64);

            // Estilo de encabezados
            dgvReporte.EnableHeadersVisualStyles = false;
            dgvReporte.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvReporte.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dgvReporte.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvReporte.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvReporte.ColumnHeadersHeight = 40;

            // Estilo de filas y selección
            dgvReporte.DefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
            dgvReporte.DefaultCellStyle.ForeColor = Color.White;
            dgvReporte.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dgvReporte.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvReporte.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvReporte.RowTemplate.Height = 35;
        }
    }
}