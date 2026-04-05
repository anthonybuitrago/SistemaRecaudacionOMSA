using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class D_Ticket : ICrud
    {
        private ConexionBD conexion = new ConexionBD();

        // 1. Mostrar Todos los Tickets (Mantenemos el tuyo pero optimizado con JOIN)
        public async Task<DataTable> MostrarAsync()
        {
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion.AbrirConexion();
            // JOIN para mostrar datos legibles en la tabla del formulario, no solo IDs
            comando.CommandText = @"
                SELECT 
                    t.ID_Ticket, 
                    c.NombreCompleto AS Chofer,
                    r.NombreRuta AS Ruta,
                    v.FechaViaje AS Fecha,
                    t.MontoPagado AS Tarifa,
                    t.Estado -- AGREGAMOS ESTO
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

            conexion.CerrarConexion();
            return tabla;
        }

        // 2. NUEVO MÉTODO: Mostrar Viajes Activos para la Venta (El "Buscador Inteligente")
        public async Task<DataTable> MostrarViajesActivosParaVentaAsync()
        {
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion.AbrirConexion();

            // Traemos el ID, una descripción combinada (Ruta + Chofer) y la Tarifa
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

            conexion.CerrarConexion();
            return tabla;
        }

        // 3. Insertar un Ticket (Cumple con ICrud)
        public async Task InsertarAsync(params object[] parametros)
        {
            int idViaje = Convert.ToInt32(parametros[0]);
            DateTime horaEmision = Convert.ToDateTime(parametros[1]);
            decimal montoPagado = Convert.ToDecimal(parametros[2]);

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();

            comando.CommandText = "INSERT INTO Ticket (ID_Viaje, HoraEmision, MontoPagado) VALUES (@ID_Viaje, @HoraEmision, @MontoPagado)";
            comando.CommandType = CommandType.Text;

            comando.Parameters.AddWithValue("@ID_Viaje", idViaje);
            comando.Parameters.AddWithValue("@HoraEmision", horaEmision);
            comando.Parameters.AddWithValue("@MontoPagado", montoPagado);

            await comando.ExecuteNonQueryAsync();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        // 4. Editar (Obligatorio por ICrud, aunque casi no se use)
        public async Task EditarAsync(params object[] parametros)
        {
            int idTicket = Convert.ToInt32(parametros[0]);
            int idViaje = Convert.ToInt32(parametros[1]);
            DateTime horaEmision = Convert.ToDateTime(parametros[2]);
            decimal montoPagado = Convert.ToDecimal(parametros[3]);

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();

            comando.CommandText = "UPDATE Ticket SET ID_Viaje = @ID_Viaje, HoraEmision = @HoraEmision, MontoPagado = @MontoPagado WHERE ID_Ticket = @ID_Ticket";
            comando.CommandType = CommandType.Text;

            comando.Parameters.AddWithValue("@ID_Ticket", idTicket);
            comando.Parameters.AddWithValue("@ID_Viaje", idViaje);
            comando.Parameters.AddWithValue("@HoraEmision", horaEmision);
            comando.Parameters.AddWithValue("@MontoPagado", montoPagado);

            await comando.ExecuteNonQueryAsync();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        // 5. Eliminar (Obligatorio por ICrud, usar con precaución)
        public async Task EliminarAsync(int id)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();

            comando.CommandText = "DELETE FROM Ticket WHERE ID_Ticket = @id";
            comando.CommandType = CommandType.Text;

            comando.Parameters.AddWithValue("@id", id);

            await comando.ExecuteNonQueryAsync();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
    }
}