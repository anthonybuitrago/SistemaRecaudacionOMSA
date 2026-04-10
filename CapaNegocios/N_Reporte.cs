using System;
using System.Data;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocios
{
    // Gestiona la lógica de negocio para la generación de reportes financieros y operativos
    public class N_Reporte
    {
        private D_Reporte objDatos = new D_Reporte();

        // Obtiene el reporte consolidado de ingresos y pasajeros agrupado por ruta
        public async Task<DataTable> MostrarRecaudacionRutaAsync()
        {
            try
            {
                return await objDatos.RecaudacionPorRutaAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa de negocios al generar el reporte de recaudación: " + ex.Message);
            }
        }
    }
}