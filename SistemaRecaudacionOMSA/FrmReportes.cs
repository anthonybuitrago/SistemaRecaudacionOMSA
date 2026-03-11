using CapaNegocios;
using System;
using System.Drawing;
using System.Windows.Forms;

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

                // ¡AGREGAR ESTA LÍNEA AQUÍ!
                AplicarEstiloTabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AplicarEstiloTabla()
        {
            // 1. Configuraciones básicas y fondo
            dgvReporte.AllowUserToAddRows = false;
            dgvReporte.RowHeadersVisible = false;
            dgvReporte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReporte.BackgroundColor = Color.White;
            dgvReporte.BorderStyle = BorderStyle.None;

            // 2. Líneas sutiles
            dgvReporte.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvReporte.GridColor = Color.Gainsboro;

            // 3. Estilo del Encabezado (Gris oscuro OMSA)
            dgvReporte.EnableHeadersVisualStyles = false;
            dgvReporte.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#404040");
            dgvReporte.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvReporte.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvReporte.ColumnHeadersHeight = 40;
            dgvReporte.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvReporte.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#404040");

            // 4. Estilo de las Filas 
            dgvReporte.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvReporte.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#E0F2E9"); // Verde OMSA
            dgvReporte.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvReporte.RowTemplate.Height = 35;
        }
    }
}