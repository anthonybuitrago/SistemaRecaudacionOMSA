using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class D_Viaje
    {
        // Conexión a la base de datos
        private ConexionBD conexion = new ConexionBD();

        // Método para leer los viajes
        // Método para leer los viajes con los nombres reales (INNER JOIN)
        public DataTable Mostrar()
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

            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();

            return tabla;
        }

        // Método exclusivo para llenar los ComboBox de Viajes de forma legible
        public DataTable MostrarParaCombo()
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

            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();

            return tabla;
        }

        // Método para guardar un viaje nuevo
        public void Insertar(int idChofer, int idRuta, int idVehiculo, DateTime fecha, string estado)
        {
            SqlCommand comando = new SqlCommand();

            // Abrir conexión y preparar el INSERT
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "INSERT INTO Viaje (ID_Chofer, ID_Ruta, ID_Vehiculo, FechaViaje, Estado) VALUES (@ID_Chofer, @ID_Ruta, @ID_Vehiculo, @Fecha, @Estado)";
            comando.CommandType = CommandType.Text;

            // Asignar los valores a los parámetros
            comando.Parameters.AddWithValue("@ID_Chofer", idChofer);
            comando.Parameters.AddWithValue("@ID_Ruta", idRuta);
            comando.Parameters.AddWithValue("@ID_Vehiculo", idVehiculo);
            comando.Parameters.AddWithValue("@Fecha", fecha);
            comando.Parameters.AddWithValue("@Estado", estado);

            // Ejecutar en SQL y limpiar
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

            // Cerrar conexión
            conexion.CerrarConexion();
        }
    }
}