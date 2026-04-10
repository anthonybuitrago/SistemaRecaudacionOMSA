using System;
using System.Data;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocios
{
    // Reglas de negocio y orquestación para la generación de reportes financieros y operativos
    public class N_Reporte
    {
        // Enlace de comunicación con la capa de persistencia de datos
        private D_Reporte objDatos = new D_Reporte();

        // Genera el reporte consolidado de ingresos y flujo de pasajeros agrupado por ruta
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