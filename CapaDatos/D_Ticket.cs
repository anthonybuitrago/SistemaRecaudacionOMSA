using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class D_Ticket
    {
        // Conexión a la base de datos
        private ConexionBD conexion = new ConexionBD();

        // Método para mostrar los tickets vendidos en la tabla
        public DataTable Mostrar()
        {
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SELECT * FROM Ticket"; // Luego lo haremos más profesional
            comando.CommandType = CommandType.Text;
            SqlDataReader leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        // Método para guardar un ticket vendido
        public void Insertar(int idViaje, DateTime horaEmision, decimal montoPagado)
        {
            SqlCommand comando = new SqlCommand();

            // Abrir conexión
            comando.Connection = conexion.AbrirConexion();

            // Configurar el comando SQL
            comando.CommandText = "INSERT INTO Ticket (ID_Viaje, HoraEmision, MontoPagado) VALUES (@ID_Viaje, @HoraEmision, @MontoPagado)";
            comando.CommandType = CommandType.Text;

            // Pasar los datos a los parámetros
            comando.Parameters.AddWithValue("@ID_Viaje", idViaje);
            comando.Parameters.AddWithValue("@HoraEmision", horaEmision);
            comando.Parameters.AddWithValue("@MontoPagado", montoPagado);

            // Ejecutar la orden y limpiar parámetros
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

            // Cerrar conexión
            conexion.CerrarConexion();
        }
    }
}