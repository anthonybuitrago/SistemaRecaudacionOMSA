using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SistemaRecaudacionOMSA
{
    // Formulario de visualización de indicadores clave de rendimiento (KPIs)
    public partial class FrmDashboard : Form
    {
        // Instancia de la lógica de negocio para la recuperación de métricas
        private N_Dashboard objNegocio = new N_Dashboard();

        public FrmDashboard()
        {
            InitializeComponent();

            // Inicialización de datos y componentes visuales durante la instanciación
            _ = CargarDatosDashboardAsync();
            ConfigurarGraficoEstetico();
        }

        // Evento disparado al cargar el formulario en memoria
        private async void FrmDashboard_Load(object sender, EventArgs e)
        {
            await CargarDatosDashboardAsync();
            ConfigurarGraficoEstetico();
        }

        // Orquestador asíncrono para la recuperación y renderizado de métricas operativas
        private async Task CargarDatosDashboardAsync()
        {
            try
            {
                // Recuperación de la fuente de datos desde la capa de negocios
                DataTable dt = await objNegocio.ObtenerTotalesAsync();

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow fila = dt.Rows[0];

                    // Asignación de valores a los componentes de la interfaz de usuario
                    lblTotalRecaudacion.Text = "RD$ " + Convert.ToDecimal(fila["RecaudacionHoy"]).ToString("N2");
                    lblTotalTickets.Text = fila["TicketsVendidosHoy"].ToString();
                    lblViajesActivos.Text = fila["ViajesActivos"].ToString();
                    lblTotalVehiculos.Text = fila["TotalVehiculos"].ToString();
                }
                else
                {
                    // Estado por defecto en caso de ausencia de registros
                    lblTotalRecaudacion.Text = "SIN DATOS";
                }
            }
            catch (Exception ex)
            {
                // Gestión de excepciones y notificación de errores en tiempo de ejecución
                MessageBox.Show("Error en la carga de indicadores: " + ex.Message);
            }
        }

        // Configuración avanzada de la interfaz del componente de gráficos
        private void ConfigurarGraficoEstetico()
        {
            // Reset de series para asegurar una renderización limpia
            chartVentas.Series.Clear();

            // Aplicación de esquema cromático de modo oscuro (Dark Mode)
            Color colorOscuro = Color.FromArgb(28, 28, 28);
            chartVentas.BackColor = colorOscuro;

            if (chartVentas.ChartAreas.Count > 0)
            {
                ChartArea area = chartVentas.ChartAreas[0];
                area.BackColor = colorOscuro;

                // Ajustes de legibilidad y estilo de los ejes coordenados
                area.AxisX.LabelStyle.ForeColor = Color.DarkGray;
                area.AxisY.LabelStyle.ForeColor = Color.DarkGray;
                area.AxisX.LineColor = Color.FromArgb(64, 64, 64);
                area.AxisY.LineColor = Color.FromArgb(64, 64, 64);
                area.AxisX.MajorGrid.LineColor = Color.FromArgb(45, 45, 48);
                area.AxisY.MajorGrid.LineColor = Color.FromArgb(45, 45, 48);
                area.AxisX.MajorGrid.Enabled = false;
            }

            // Inhabilitación de la leyenda para optimización de espacio visual
            if (chartVentas.Legends.Count > 0)
                chartVentas.Legends[0].Enabled = false;

            // Instanciación y parametrización de la serie de datos
            Series serie = new Series("Ventas Semanales")
            {
                ChartType = SeriesChartType.SplineArea,
                Color = Color.FromArgb(0, 122, 204), // Identidad visual institucional
                BorderWidth = 3
            };

            // Inyección de puntos de datos para visualización estadística
            serie.Points.AddXY("Lun", 1200);
            serie.Points.AddXY("Mar", 1800);
            serie.Points.AddXY("Mie", 1500);
            serie.Points.AddXY("Jue", 2200);
            serie.Points.AddXY("Vie", 2500);
            serie.Points.AddXY("Sab", 3000);
            serie.Points.AddXY("Dom", 1100);

            chartVentas.Series.Add(serie);
        }
    }
}