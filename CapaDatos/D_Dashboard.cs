using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class D_Dashboard
    {
        // Instancia para gestionar la comunicación con la base de datos
        private ConexionBD conexion = new ConexionBD();

        // Obtiene las métricas principales del Dashboard ejecutando el procedimiento almacenado correspondiente.
        public async Task<DataTable> ObtenerResumenDashboardAsync()
        {
            DataTable dt = new DataTable();
            try
            {
                // Se establece y abre el canal de comunicación con SQL Server
                SqlConnection cn = conexion.AbrirConexion();

                using (SqlCommand cmd = new SqlCommand("SP_Dashboard_Totales", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Ejecución asíncrona del lector para optimizar el rendimiento de la aplicación
                    using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                    {
                        dt.Load(dr);
                    }
                }
            }
            catch (Exception ex)
            {
                // Captura y propagación de excepciones ocurridas en la capa de persistencia
                throw new Exception("Error en el acceso a datos del Dashboard: " + ex.Message);
            }
            finally
            {
                // Asegura la liberación de los recursos de conexión tras la consulta
                conexion.CerrarConexion();
            }
            return dt;
        }
    }
}