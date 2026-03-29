using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks; // Obligatorio para el asincronismo

namespace CapaDatos
{
    // TODO: Requisito - Implementación de Interfaz ICrud
    public class D_Ticket : ICrud
    {
        // Instancia para establecer la comunicación con el servidor SQL
        private ConexionBD conexion = new ConexionBD();

        // TODO: Requisito - Llamada Asíncrona (Async/Await)
        // Método para extraer y listar todos los tickets vendidos
        public async Task<DataTable> MostrarAsync()
        {
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();

            // Abrimos el canal y preparamos la orden de consulta
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SELECT * FROM Ticket"; // Pendiente: optimizar con INNER JOIN en el futuro
            comando.CommandType = CommandType.Text;

            // Ejecutamos la consulta de forma asíncrona y volcamos los resultados en la tabla
            SqlDataReader leer = await comando.ExecuteReaderAsync();
            tabla.Load(leer);

            // Cerramos la comunicación de forma segura
            conexion.CerrarConexion();
            return tabla;
        }

        // TODO: Requisito - Llamada Asíncrona usando el arreglo de parámetros de la Interfaz
        // Método para registrar la venta de un nuevo ticket
        public async Task InsertarAsync(params object[] parametros)
        {
            // Extraemos los datos: ID_Viaje, HoraEmision, MontoPagado
            int idViaje = Convert.ToInt32(parametros[0]);
            DateTime horaEmision = Convert.ToDateTime(parametros[1]);
            decimal montoPagado = Convert.ToDecimal(parametros[2]);

            SqlCommand comando = new SqlCommand();

            // Abrimos el canal y preparamos la orden de inserción
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "INSERT INTO Ticket (ID_Viaje, HoraEmision, MontoPagado) VALUES (@ID_Viaje, @HoraEmision, @MontoPagado)";
            comando.CommandType = CommandType.Text;

            // Empaquetamos los datos de forma segura
            comando.Parameters.AddWithValue("@ID_Viaje", idViaje);
            comando.Parameters.AddWithValue("@HoraEmision", horaEmision);
            comando.Parameters.AddWithValue("@MontoPagado", montoPagado);

            // Ejecutamos la acción asíncrona
            await comando.ExecuteNonQueryAsync();
            comando.Parameters.Clear();

            // Cerramos la comunicación
            conexion.CerrarConexion();
        }

        // Método OBLIGATORIO por la interfaz ICrud (Aunque los tickets rara vez se editen)
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

        // Método OBLIGATORIO por la interfaz ICrud (Aunque los tickets rara vez se eliminen)
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