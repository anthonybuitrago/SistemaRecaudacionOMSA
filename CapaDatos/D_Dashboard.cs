using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class D_Dashboard
    {
        // Instancia de tu clase de conexión
        private ConexionBD conexion = new ConexionBD();

        /// <summary>
        /// Ejecuta un procedimiento almacenado para obtener las 4 métricas principales
        /// </summary>
        public async Task<DataTable> ObtenerResumenDashboardAsync()
        {
            DataTable dt = new DataTable();
            try
            {
                // AbrirConexion ya nos da la conexión abierta
                SqlConnection cn = conexion.AbrirConexion();

                using (SqlCommand cmd = new SqlCommand("SP_Dashboard_Totales", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Usamos ExecuteReaderAsync directamente
                    using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                    {
                        dt.Load(dr);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en CapaDatos: " + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
            return dt;
        }
    }
}