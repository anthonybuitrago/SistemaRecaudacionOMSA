using System;
using System.Data;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocios
{
    public class N_Dashboard
    {
        // Referencia a la capa de persistencia de datos del Dashboard
        private D_Dashboard objDatos = new D_Dashboard();

        // Solicita el procesamiento de las métricas globales para la interfaz principal
        // Retorna un objeto DataTable con las métricas de recaudación, ventas y operatividad
        public async Task<DataTable> ObtenerTotalesAsync()
        {
            try
            {
                // Invocación del método de consulta en la capa de datos
                return await objDatos.ObtenerResumenDashboardAsync();
            }
            catch (Exception ex)
            {
                // Encapsulamiento de la excepción original con contexto de la capa de negocios
                throw new Exception("Error en la lógica de negocio del Dashboard: " + ex.Message);
            }
        }
    }
}