using System;
using System.Data;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocios
{
    // Reglas de negocio y orquestación para las métricas del panel principal (Dashboard)
    public class N_Dashboard
    {
        // Enlace de comunicación con la capa de persistencia de datos
        private D_Dashboard objDatos = new D_Dashboard();

        // Recupera las métricas globales consolidadas (recaudación, ventas y operatividad)
        public async Task<DataTable> ObtenerTotalesAsync()
        {
            try
            {
                return await objDatos.ObtenerResumenDashboardAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la lógica de negocio del Dashboard: " + ex.Message);
            }
        }
    }
}