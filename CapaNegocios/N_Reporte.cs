using System;
using System.Data;
using System.Threading.Tasks; // Obligatorio para el asincronismo
using CapaDatos;

namespace CapaNegocios
{
    public class N_Reporte
    {
        // Conexión con la Capa de Datos
        private D_Reporte objDatos = new D_Reporte();

        // TODO: Requisito - Llamada Asíncrona (Async/Await) en Capa de Negocios
        // Método para pedir el reporte de ingresos y pasajeros a la base de datos de forma asíncrona
        public async Task<DataTable> MostrarRecaudacionRutaAsync()
        {
            try
            {
                // Esperamos asíncronamente el resultado de la Capa de Datos
                return await objDatos.RecaudacionPorRutaAsync();
            }
            catch (Exception ex)
            {
                // TODO: Requisito - Manejo de excepciones (Try/Catch)
                // Si la base de datos falla (ej. se cae el servidor), atrapamos el error aquí
                throw new Exception("Error al intentar generar el reporte de recaudación: " + ex.Message);
            }
        }
    }
}