using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CapaDatos
{
    // Implementación del contrato ICrud para la gestión transaccional de viajes
    public class D_Viaje : ICrud
    {
        // Instancia de conexión a la base de datos
        private ConexionBD conexion = new ConexionBD();

        // TODO: [REQUISITO] - Llamadas Asíncronas: Implementación de Task y Async/Await para procesos no bloqueantes.

        // Extrae el listado detallado de viajes con cruce relacional (Chofer, Ruta, Vehículo)
        public async Task<DataTable> MostrarAsync()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexion.AbrirConexion();
                    comando.CommandText = @"
                        SELECT 
                            v.ID_Viaje AS 'ID',
                            c.NombreCompleto AS 'Chofer',
                            r.NombreRuta AS 'Ruta',
                            ve.Ficha AS 'Ficha del Vehículo',
                            v.FechaViaje AS 'Fecha y Hora',
                            v.Estado AS 'Estado'
                        FROM Viaje v
                        INNER JOIN Chofer c ON v.ID_Chofer = c.ID_Chofer
                        INNER JOIN Ruta r ON v.ID_Ruta = r.ID_Ruta
                        INNER JOIN Vehiculo ve ON v.ID_Vehiculo = ve.ID_Vehiculo";

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

        // Obtiene los viajes activos concatenados para selectores de interfaz
        public async Task<DataTable> MostrarParaComboAsync()
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
                            r.NombreRuta + ' - Ficha: ' + ve.Ficha + ' (' + c.NombreCompleto + ')' AS DescripcionViaje
                        FROM Viaje v
                        INNER JOIN Ruta r ON v.ID_Ruta = r.ID_Ruta
                        INNER JOIN Vehiculo ve ON v.ID_Vehiculo = ve.ID_Vehiculo
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

        // Registra la programación de un nuevo viaje en la base de datos
        public async Task InsertarAsync(params object[] parametros)
        {
            int idChofer = Convert.ToInt32(parametros[0]);
            int idRuta = Convert.ToInt32(parametros[1]);
            int idVehiculo = Convert.ToInt32(parametros[2]);
            DateTime fecha = Convert.ToDateTime(parametros[3]);
            string estado = parametros[4].ToString();

            try
            {
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexion.AbrirConexion();
                    comando.CommandText = "INSERT INTO Viaje (ID_Chofer, ID_Ruta, ID_Vehiculo, FechaViaje, Estado) VALUES (@ID_Chofer, @ID_Ruta, @ID_Vehiculo, @Fecha, @Estado)";
                    comando.CommandType = CommandType.Text;

                    comando.Parameters.AddWithValue("@ID_Chofer", idChofer);
                    comando.Parameters.AddWithValue("@ID_Ruta", idRuta);
                    comando.Parameters.AddWithValue("@ID_Vehiculo", idVehiculo);
                    comando.Parameters.AddWithValue("@Fecha", fecha);
                    comando.Parameters.AddWithValue("@Estado", estado);

                    await comando.ExecuteNonQueryAsync();
                }
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        // Actualiza los datos de un viaje previamente programado
        public async Task EditarAsync(params object[] parametros)
        {
            int idViaje = Convert.ToInt32(parametros[0]);
            int idChofer = Convert.ToInt32(parametros[1]);
            int idRuta = Convert.ToInt32(parametros[2]);
            int idVehiculo = Convert.ToInt32(parametros[3]);
            DateTime fecha = Convert.ToDateTime(parametros[4]);
            string estado = parametros[5].ToString();

            try
            {
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexion.AbrirConexion();
                    comando.CommandText = "UPDATE Viaje SET ID_Chofer = @ID_Chofer, ID_Ruta = @ID_Ruta, ID_Vehiculo = @ID_Vehiculo, FechaViaje = @Fecha, Estado = @Estado WHERE ID_Viaje = @ID_Viaje";
                    comando.CommandType = CommandType.Text;

                    comando.Parameters.AddWithValue("@ID_Viaje", idViaje);
                    comando.Parameters.AddWithValue("@ID_Chofer", idChofer);
                    comando.Parameters.AddWithValue("@ID_Ruta", idRuta);
                    comando.Parameters.AddWithValue("@ID_Vehiculo", idVehiculo);
                    comando.Parameters.AddWithValue("@Fecha", fecha);
                    comando.Parameters.AddWithValue("@Estado", estado);

                    await comando.ExecuteNonQueryAsync();
                }
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        // Ejecuta el borrado físico del registro en la tabla (Requisito ICrud)
        public async Task EliminarAsync(int id)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexion.AbrirConexion();
                    comando.CommandText = "DELETE FROM Viaje WHERE ID_Viaje = @id";
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

        // Ejecuta la baja lógica (cancelación) cambiando el estado del viaje
        public async Task CancelarAsync(int idViaje)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexion.AbrirConexion();
                    comando.CommandText = "UPDATE Viaje SET Estado = 'Cancelado' WHERE ID_Viaje = @ID_Viaje";
                    comando.CommandType = CommandType.Text;
                    comando.Parameters.AddWithValue("@ID_Viaje", idViaje);

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