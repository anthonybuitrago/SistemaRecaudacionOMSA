using CapaNegocios;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaRecaudacionOMSA
{
    public partial class FrmReportes : Form
    {
        // Instancia para la comunicación con la Capa de Negocio
        private N_Reporte objReporte = new N_Reporte();

        // Constructor que inicializa los componentes de la ventana
        public FrmReportes()
        {
            InitializeComponent();
        }

        // Evento que carga los datos del reporte al abrir la ventana
        private void FrmReportes_Load(object sender, EventArgs e)
        {
            CargarReporteRecaudacion();
        }

        // Método para solicitar y mostrar los totales de recaudación
        private void CargarReporteRecaudacion()
        {
            try
            {
                // Volcamos los resultados calculados por el servidor en la tabla visual
                dgvReporte.DataSource = objReporte.MostrarRecaudacionRuta();

                // Aplicamos el diseño corporativo a la tabla
                AplicarEstiloTabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para personalizar la apariencia visual de la tabla de datos
        private void AplicarEstiloTabla()
        {
            // Configuración de estructura y bordes
            dgvReporte.AllowUserToAddRows = false;
            dgvReporte.RowHeadersVisible = false;
            dgvReporte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReporte.BackgroundColor = Color.White;
            dgvReporte.BorderStyle = BorderStyle.None;
            dgvReporte.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvReporte.GridColor = Color.Gainsboro;

            // Configuración de colores corporativos para los encabezados
            dgvReporte.EnableHeadersVisualStyles = false;
            dgvReporte.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#404040");
            dgvReporte.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvReporte.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvReporte.ColumnHeadersHeight = 40;
            dgvReporte.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvReporte.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#404040");

            // Configuración visual de las filas y colores de selección
            dgvReporte.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvReporte.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#E0F2E9");
            dgvReporte.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvReporte.RowTemplate.Height = 35;
        }
    }
}