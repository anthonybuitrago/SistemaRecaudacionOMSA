using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class D_Ticket
    {
        // Instancia para establecer la comunicación con el servidor SQL
        private ConexionBD conexion = new ConexionBD();

        // Método para extraer y listar todos los tickets vendidos registrados en la tabla
        public DataTable Mostrar()
        {
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();

            // Abrimos el canal y preparamos la orden de consulta
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SELECT * FROM Ticket"; // Pendiente: optimizar con INNER JOIN en el futuro
            comando.CommandType = CommandType.Text;

            // Ejecutamos la consulta y volcamos los resultados en la tabla
            SqlDataReader leer = comando.ExecuteReader();
            tabla.Load(leer);

            // Cerramos la comunicación de forma segura
            conexion.CerrarConexion();
            return tabla;
        }

        // Método para registrar la venta de un nuevo ticket en la base de datos
        public void Insertar(int idViaje, DateTime horaEmision, decimal montoPagado)
        {
            SqlCommand comando = new SqlCommand();

            // Abrimos el canal y preparamos la orden de inserción
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "INSERT INTO Ticket (ID_Viaje, HoraEmision, MontoPagado) VALUES (@ID_Viaje, @HoraEmision, @MontoPagado)";
            comando.CommandType = CommandType.Text;

            // Empaquetamos los datos de forma segura para evitar hackeos (Inyección SQL)
            comando.Parameters.AddWithValue("@ID_Viaje", idViaje);
            comando.Parameters.AddWithValue("@HoraEmision", horaEmision);
            comando.Parameters.AddWithValue("@MontoPagado", montoPagado);

            // Ejecutamos la acción en el servidor y limpiamos el empaque
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

            // Cerramos la comunicación de forma segura
            conexion.CerrarConexion();
        }
    }
}