using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CapaDatos
{
    // Persistencia de datos para la emisión de boletos (Implementación ICrud)
    public class D_Ticket : ICrud
    {
        private ConexionBD conexion = new ConexionBD();

        // ==========================================================
        // CONSULTAS DE DATOS RELACIONALES
        // ==========================================================

        // Extrae el historial resolviendo llaves foráneas mediante JOINs relacionales
        public async Task<DataTable> MostrarAsync()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (SqlCommand comando = new SqlCommand())
                {
                    // TODO: [REQUISITO] - Llaves Foráneas: Integridad referencial demostrada mediante consultas relacionales(JOINs)

                    comando.Connection = conexion.AbrirConexion();
                    comando.CommandText = @"
                        SELECT 
                            t.ID_Ticket, 
                            c.NombreCompleto AS Chofer,
                            r.NombreRuta AS Ruta,
                            v.FechaViaje AS Fecha,
                            t.MontoPagado AS Tarifa,
                            t.Estado
                        FROM Ticket t
                        INNER JOIN Viaje v ON t.ID_Viaje = v.ID_Viaje
                        INNER JOIN Ruta r ON v.ID_Ruta = r.ID_Ruta
                        INNER JOIN Chofer c ON v.ID_Chofer = c.ID_Chofer
                        ORDER BY t.ID_Ticket DESC";

                    comando.CommandType = CommandType.Text;

                    using (SqlDataReader leer = await comando.ExecuteReaderAsync())
                    {
                        tabla.Load(leer);
                    }
                }
            }
            finally
            {
                conexion.CerrarConexion();
            }
            return tabla;
        }

        // Obtiene la disponibilidad de viajes activos para la interfaz de ventas
        public async Task<DataTable> MostrarViajesActivosParaVentaAsync()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexion.AbrirConexion();
                    comando.CommandText = @"
                        SELECT 
                            v.ID_Viaje, 
                            r.NombreRuta + ' | ' + c.NombreCompleto AS DescripcionViaje,
                            r.Tarifa
                        FROM Viaje v
                        INNER JOIN Ruta r ON v.ID_Ruta = r.ID_Ruta
                        INNER JOIN Chofer c ON v.ID_Chofer = c.ID_Chofer
                        WHERE v.Estado = 'Activo'";

                    comando.CommandType = CommandType.Text;

                    using (SqlDataReader leer = await comando.ExecuteReaderAsync())
                    {
                        tabla.Load(leer);
                    }
                }
            }
            finally
            {
                conexion.CerrarConexion();
            }
            return tabla;
        }

        // ==========================================================
        // OPERACIONES TRANSACCIONALES
        // ==========================================================

        // Registra una nueva venta de ticket en la base de datos
        public async Task InsertarAsync(params object[] parametros)
        {
            int idViaje = Convert.ToInt32(parametros[0]);
            DateTime horaEmision = Convert.ToDateTime(parametros[1]);
            decimal montoPagado = Convert.ToDecimal(parametros[2]);

            try
            {
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexion.AbrirConexion();
                    comando.CommandText = "INSERT INTO Ticket (ID_Viaje, HoraEmision, MontoPagado) VALUES (@ID_Viaje, @HoraEmision, @MontoPagado)";
                    comando.CommandType = CommandType.Text;

                    comando.Parameters.AddWithValue("@ID_Viaje", idViaje);
                    comando.Parameters.AddWithValue("@HoraEmision", horaEmision);
                    comando.Parameters.AddWithValue("@MontoPagado", montoPagado);

                    await comando.ExecuteNonQueryAsync();
                }
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        // Modifica los datos de un ticket registrado anteriormente
        public async Task EditarAsync(params object[] parametros)
        {
            int idTicket = Convert.ToInt32(parametros[0]);
            int idViaje = Convert.ToInt32(parametros[1]);
            DateTime horaEmision = Convert.ToDateTime(parametros[2]);
            decimal montoPagado = Convert.ToDecimal(parametros[3]);

            try
            {
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexion.AbrirConexion();
                    comando.CommandText = "UPDATE Ticket SET ID_Viaje = @ID_Viaje, HoraEmision = @HoraEmision, MontoPagado = @MontoPagado WHERE ID_Ticket = @ID_Ticket";
                    comando.CommandType = CommandType.Text;

                    comando.Parameters.AddWithValue("@ID_Ticket", idTicket);
                    comando.Parameters.AddWithValue("@ID_Viaje", idViaje);
                    comando.Parameters.AddWithValue("@HoraEmision", horaEmision);
                    comando.Parameters.AddWithValue("@MontoPagado", montoPagado);

                    await comando.ExecuteNonQueryAsync();
                }
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        // Ejecuta la eliminación física del registro de ticket
        public async Task EliminarAsync(int id)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexion.AbrirConexion();
                    comando.CommandText = "DELETE FROM Ticket WHERE ID_Ticket = @id";
                    comando.CommandType = CommandType.Text;
                    comando.Parameters.AddWithValue("@id", id);

                    await comando.ExecuteNonQueryAsync();
                }
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }
    }
}