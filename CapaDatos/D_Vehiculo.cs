using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class D_Vehiculo
    {
        // Conexión a la base de datos
        private ConexionBD conexion = new ConexionBD();

        // Método para leer los vehículos
        public DataTable Mostrar()
        {
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();
            SqlDataReader leer;

            // Abrir conexión y configurar el comando
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SELECT * FROM Vehiculo";
            comando.CommandType = CommandType.Text;

            // Ejecutar y cargar los datos
            leer = comando.ExecuteReader();
            tabla.Load(leer);

            // Cerrar conexión
            conexion.CerrarConexion();
            return tabla;
        }

        // Método para guardar un vehículo nuevo
        public void Insertar(string ficha, string placa, int capacidad)
        {
            SqlCommand comando = new SqlCommand();

            // Abrir conexión y preparar el INSERT
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "INSERT INTO Vehiculo (Ficha, Placa, Capacidad) VALUES (@Ficha, @Placa, @Capacidad)";
            comando.CommandType = CommandType.Text;

            // Pasar los valores a los parámetros
            comando.Parameters.AddWithValue("@Ficha", ficha);
            comando.Parameters.AddWithValue("@Placa", placa);
            comando.Parameters.AddWithValue("@Capacidad", capacidad);

            // Ejecutar y limpiar
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

            // Cerrar conexión
            conexion.CerrarConexion();
        }
    }
}