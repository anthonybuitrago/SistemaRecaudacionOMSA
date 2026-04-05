using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; // Necesario para el gráfico
using CapaNegocios;

namespace SistemaRecaudacionOMSA
{
    public partial class FrmDashboard : Form
    {
        private N_Dashboard objNegocio = new N_Dashboard();

        public FrmDashboard()
        {
            InitializeComponent();

            // FORZAMOS LA CARGA AQUÍ: 
            // Si el Load no se dispara, el constructor lo hará.
            CargarDatosDashboardAsync();
            ConfigurarGraficoEstetico();
        }

        // El método Load lo dejamos igual por si acaso
        private async void FrmDashboard_Load(object sender, EventArgs e)
        {
            await CargarDatosDashboardAsync();
            ConfigurarGraficoEstetico();
        }

        private async Task CargarDatosDashboardAsync()
        {
            try
            {
                // LINEA DE PRUEBA: Si sale este mensaje al abrir, el código SÍ funciona.
                // MessageBox.Show("Buscando datos en la DB...");

                DataTable dt = await objNegocio.ObtenerTotalesAsync();

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow fila = dt.Rows[0];
                    lblTotalRecaudacion.Text = "RD$ " + Convert.ToDecimal(fila["RecaudacionHoy"]).ToString("N2");
                    lblTotalTickets.Text = fila["TicketsVendidosHoy"].ToString();
                    lblViajesActivos.Text = fila["ViajesActivos"].ToString();
                    lblTotalVehiculos.Text = fila["TotalVehiculos"].ToString();
                }
                else
                {
                    // Si ves esto en pantalla, es que la conexión funciona pero la tabla llegó VACÍA
                    lblTotalRecaudacion.Text = "SIN DATOS";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error detectado: " + ex.Message);
            }
        }

        private void ConfigurarGraficoEstetico()
        {

            chartVentas.Series.Clear();
            chartVentas.ChartAreas[0].BackColor = Color.FromArgb(28, 28, 28);
            chartVentas.BackColor = Color.FromArgb(28, 28, 28);

            // Limpiamos cualquier dato previo
            chartVentas.Series.Clear();

            // Color de fondo oscuro (mismo que tu formulario)
            Color colorOscuro = Color.FromArgb(28, 28, 28);
            chartVentas.BackColor = colorOscuro;

            // ESTO ES LO QUE QUITA EL CUADRO BLANCO:
            if (chartVentas.ChartAreas.Count > 0)
            {
                ChartArea area = chartVentas.ChartAreas[0];
                area.BackColor = colorOscuro; // Forzamos el fondo del área a oscuro

                // Configuramos los ejes para que se vean en modo oscuro
                area.AxisX.LabelStyle.ForeColor = Color.DarkGray;
                area.AxisY.LabelStyle.ForeColor = Color.DarkGray;
                area.AxisX.LineColor = Color.FromArgb(64, 64, 64);
                area.AxisY.LineColor = Color.FromArgb(64, 64, 64);
                area.AxisX.MajorGrid.LineColor = Color.FromArgb(45, 45, 48);
                area.AxisY.MajorGrid.LineColor = Color.FromArgb(45, 45, 48);
                area.AxisX.MajorGrid.Enabled = false; // Quita las líneas verticales para un look más limpio
            }

            // Quitamos la leyenda "Series1"
            if (chartVentas.Legends.Count > 0)
                chartVentas.Legends[0].Enabled = false;

            // Creamos la serie del gráfico
            Series serie = new Series("Ventas Semanales");
            serie.ChartType = SeriesChartType.SplineArea;
            serie.Color = Color.FromArgb(0, 122, 204); // Azul OMSA
            serie.BorderWidth = 3;

            // Datos de prueba (puedes cambiarlos por reales luego)
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