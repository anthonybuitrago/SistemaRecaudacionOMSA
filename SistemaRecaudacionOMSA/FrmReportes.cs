using CapaNegocios;
using System;
using System.Drawing;
using System.Threading.Tasks; // Obligatorio para el asincronismo
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

            // Si tienes un método de estilo, déjalo. Por ejemplo:
            // AplicarEstiloTabla();

            // 🔥 LA LÍNEA MÁGICA PARA QUE SE VEA COMO LOS DEMÁS
            dgvReporte.Dock = DockStyle.Fill;
        }

        // Evento ASÍNCRONO que carga los datos del reporte al abrir la ventana
        private async void FrmReportes_Load(object sender, EventArgs e)
        {
            await CargarReporteRecaudacionAsync();
        }

        // Método ASÍNCRONO para solicitar y mostrar los totales de recaudación
        private async Task CargarReporteRecaudacionAsync()
        {
            try
            {
                dgvReporte.DataSource = await objReporte.MostrarRecaudacionRutaAsync();

                // 1. Ponemos la tabla bonita y oscura
                AplicarEstiloTabla();

                // 2. Formateamos las columnas numéricas (SOLO si existen)
                if (dgvReporte.Columns["Pasajeros"] != null)
                {
                    // Centramos la cantidad de pasajeros
                    dgvReporte.Columns["Pasajeros"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                if (dgvReporte.Columns["Total Recaudado RD$"] != null)
                {
                    // Alinear a la derecha (como en contabilidad)
                    dgvReporte.Columns["Total Recaudado RD$"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    // Poner el símbolo de moneda local (dependiendo de la PC, pondrá RD$ o $)
                    dgvReporte.Columns["Total Recaudado RD$"].DefaultCellStyle.Format = "C2";

                    // Pintar el dinero de verde para que destaque
                    dgvReporte.Columns["Total Recaudado RD$"].DefaultCellStyle.ForeColor = Color.LightGreen;
                    dgvReporte.Columns["Total Recaudado RD$"].DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para personalizar la apariencia visual de la tabla de datos
        private void AplicarEstiloTabla()
        {
            // Configuración de estructura
            dgvReporte.AllowUserToAddRows = false;
            dgvReporte.AllowUserToResizeRows = false;
            dgvReporte.RowHeadersVisible = false;
            dgvReporte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReporte.BorderStyle = BorderStyle.None;
            dgvReporte.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReporte.ReadOnly = true; // Para que no escriban encima del reporte

            // 🌙 COLORES DARK MODE
            dgvReporte.BackgroundColor = Color.FromArgb(32, 32, 32); // Fondo oscuro
            dgvReporte.GridColor = Color.FromArgb(64, 64, 64);
            dgvReporte.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // Encabezados
            dgvReporte.EnableHeadersVisualStyles = false;
            dgvReporte.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 20, 20); // Casi negro
            dgvReporte.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvReporte.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvReporte.ColumnHeadersHeight = 40;
            dgvReporte.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvReporte.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(20, 20, 20);

            // Filas normales
            dgvReporte.DefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40); // Gris oscuro
            dgvReporte.DefaultCellStyle.ForeColor = Color.White;
            dgvReporte.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvReporte.RowTemplate.Height = 35;

            // Color de Selección (Azul Windows)
            dgvReporte.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
            dgvReporte.DefaultCellStyle.SelectionForeColor = Color.White;
        }
    }
}