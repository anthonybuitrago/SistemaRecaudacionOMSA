using System;
using System.Data;
using System.Threading.Tasks;
using CapaDatos; // IMPORTANTE: Para conectar con D_Dashboard

namespace CapaNegocios
{
    public class N_Dashboard
    {
        // Instancia de la capa de datos
        private D_Dashboard objDatos = new D_Dashboard();

        /// <summary>
        /// Solicita los totales generales para las tarjetas del Dashboard
        /// </summary>
        /// <returns>DataTable con las columnas: RecaudacionHoy, TicketsVendidosHoy, ViajesActivos, TotalVehiculos</returns>
        public async Task<DataTable> ObtenerTotalesAsync()
        {
            try
            {
                // Llamamos al método en la capa de datos
                return await objDatos.ObtenerResumenDashboardAsync();
            }
            catch (Exception ex)
            {
                // Registramos el error y lo lanzamos a la interfaz
                throw new Exception("Error en CapaNegocios al obtener totales: " + ex.Message);
            }
        }

        /* Aquí puedes agregar más métodos en el futuro, por ejemplo:
           public async Task<DataTable> ObtenerDatosGraficoSemanalAsync() { ... }
        */
    }
}