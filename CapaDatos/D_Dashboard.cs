using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CapaDatos
{
    // Persistencia de datos especializada en métricas operativas del sistema (Dashboard)
    public class D_Dashboard
    {
        // Instancia de gestión de conexión
        private ConexionBD conexion = new ConexionBD();

        // Ejecuta el procedimiento almacenado para recuperar los KPIs globales consolidados
        public async Task<DataTable> ObtenerResumenDashboardAsync()
        {
            DataTable dt = new DataTable();
            try
            {
                // Apertura del canal de comunicación con SQL Server
                SqlConnection cn = conexion.AbrirConexion();

                // Implementación mediante Procedimiento Almacenado para optimización de rendimiento
                using (SqlCommand cmd = new SqlCommand("SP_Dashboard_Totales", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Lectura asíncrona de datos para mantener la fluidez de la interfaz
                    using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                    {
                        dt.Load(dr);
                    }
                }
            }
            catch (Exception ex)
            {
                // Propagación controlada de excepciones de persistencia
                throw new Exception("Error en el acceso a datos analíticos del Dashboard: " + ex.Message);
            }
            finally
            {
                // Liberación obligatoria de recursos de conexión
                conexion.CerrarConexion();
            }
            return dt;
        }
    }
}