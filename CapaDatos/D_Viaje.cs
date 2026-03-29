using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks; // Obligatorio para el asincronismo

namespace CapaDatos
{
    // TODO: Requisito - Implementación de Interfaz ICrud en tabla transaccional
    public class D_Viaje : ICrud
    {
        // Instancia para establecer la comunicación con el servidor SQL
        private ConexionBD conexion = new ConexionBD();

        // TODO: Requisito - Llamada Asíncrona (Async/Await)
        // Método para extraer y listar los viajes cruzando tablas
        public async Task<DataTable> MostrarAsync()
        {
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();
            SqlDataReader leer;

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

            // Ejecutamos la consulta asíncrona
            leer = await comando.ExecuteReaderAsync();
            tabla.Load(leer);

            conexion.CerrarConexion();
            return tabla;
        }

        // Método exclusivo asíncrono para cargar selectores (ComboBox)
        public async Task<DataTable> MostrarParaComboAsync()
        {
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();
            SqlDataReader leer;

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

            // Ejecutamos la consulta asíncrona
            leer = await comando.ExecuteReaderAsync();
            tabla.Load(leer);

            conexion.CerrarConexion();
            return tabla;
        }

        // TODO: Requisito - Llamada Asíncrona usando el arreglo de parámetros de la Interfaz
        // Método para registrar un nuevo viaje
        public async Task InsertarAsync(params object[] parametros)
        {
            // Extraemos los datos del empaque: ID_Chofer, ID_Ruta, ID_Vehiculo, Fecha, Estado
            int idChofer = Convert.ToInt32(parametros[0]);
            int idRuta = Convert.ToInt32(parametros[1]);
            int idVehiculo = Convert.ToInt32(parametros[2]);
            DateTime fecha = Convert.ToDateTime(parametros[3]);
            string estado = parametros[4].ToString();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "INSERT INTO Viaje (ID_Chofer, ID_Ruta, ID_Vehiculo, FechaViaje, Estado) VALUES (@ID_Chofer, @ID_Ruta, @ID_Vehiculo, @Fecha, @Estado)";
            comando.CommandType = CommandType.Text;

            comando.Parameters.AddWithValue("@ID_Chofer", idChofer);
            comando.Parameters.AddWithValue("@ID_Ruta", idRuta);
            comando.Parameters.AddWithValue("@ID_Vehiculo", idVehiculo);
            comando.Parameters.AddWithValue("@Fecha", fecha);
            comando.Parameters.AddWithValue("@Estado", estado);

            // Ejecutamos de forma asíncrona
            await comando.ExecuteNonQueryAsync();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        // Método para modificar los datos de un viaje ya existente
        public async Task EditarAsync(params object[] parametros)
        {
            // Extraemos los datos: ID_Viaje, ID_Chofer, ID_Ruta, ID_Vehiculo, Fecha, Estado
            int idViaje = Convert.ToInt32(parametros[0]);
            int idChofer = Convert.ToInt32(parametros[1]);
            int idRuta = Convert.ToInt32(parametros[2]);
            int idVehiculo = Convert.ToInt32(parametros[3]);
            DateTime fecha = Convert.ToDateTime(parametros[4]);
            string estado = parametros[5].ToString();

            SqlCommand comando = new SqlCommand();
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
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        // Método OBLIGATORIO por la interfaz ICrud (Borrado físico)
        public async Task EliminarAsync(int id)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "DELETE FROM Viaje WHERE ID_Viaje = @id";
            comando.CommandType = CommandType.Text;

            comando.Parameters.AddWithValue("@id", id);

            await comando.ExecuteNonQueryAsync();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        // Método original tuyo para realizar un "borrado lógico" (Hecho asíncrono)
        public async Task CancelarAsync(int idViaje)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();

            comando.CommandText = "UPDATE Viaje SET Estado = 'Cancelado' WHERE ID_Viaje = @ID_Viaje";
            comando.CommandType = CommandType.Text;
            comando.Parameters.AddWithValue("@ID_Viaje", idViaje);

            await comando.ExecuteNonQueryAsync();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
    }
}