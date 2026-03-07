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
        public DataTable Mostrar()
        {
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();
            SqlDataReader leer;

            // Abrir conexión y configurar el comando
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SELECT * FROM Viaje";
            comando.CommandType = CommandType.Text;

            // Leer datos y cargar la tabla
            leer = comando.ExecuteReader();
            tabla.Load(leer);

            // Cerrar conexión
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