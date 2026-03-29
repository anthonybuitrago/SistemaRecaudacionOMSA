using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks; // Obligatorio para el asincronismo

namespace CapaDatos
{
    // TODO: Requisito - Implementación de Interfaz ICrud
    public class D_Ruta : ICrud
    {
        // Instancia para establecer la comunicación con el servidor SQL
        private ConexionBD conexion = new ConexionBD();

        // TODO: Requisito - Llamada Asíncrona (Async/Await)
        // Método para extraer y listar todas las rutas de forma asíncrona
        public async Task<DataTable> MostrarAsync()
        {
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();
            SqlDataReader leer;

            // Abrimos el canal y preparamos la orden de consulta
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SELECT * FROM Ruta";
            comando.CommandType = CommandType.Text;

            // Ejecutamos la consulta asíncrona y volcamos los resultados en la tabla
            leer = await comando.ExecuteReaderAsync();
            tabla.Load(leer);

            // Cerramos la comunicación de forma segura
            conexion.CerrarConexion();
            return tabla;
        }

        // TODO: Requisito - Llamada Asíncrona usando el arreglo de parámetros de la Interfaz
        // Método para registrar una nueva ruta en la base de datos
        public async Task InsertarAsync(params object[] parametros)
        {
            // Extraemos los datos del empaque basándonos en tu código original
            string nombreRuta = parametros[0].ToString();
            string tarifaPasaje = parametros[1].ToString();

            SqlCommand comando = new SqlCommand();

            // Abrimos el canal y preparamos la orden de inserción
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "INSERT INTO Ruta (NombreRuta, TarifaPasaje) VALUES (@NombreRuta, @TarifaPasaje)";
            comando.CommandType = CommandType.Text;

            // Empaquetamos los datos de forma segura para evitar hackeos (Inyección SQL)
            comando.Parameters.AddWithValue("@NombreRuta", nombreRuta);
            comando.Parameters.AddWithValue("@TarifaPasaje", tarifaPasaje);

            // Ejecutamos la acción asíncrona en el servidor y limpiamos el empaque
            await comando.ExecuteNonQueryAsync();
            comando.Parameters.Clear();

            conexion.CerrarConexion();
        }

        // Método para modificar los datos de una ruta de forma asíncrona
        public async Task EditarAsync(params object[] parametros)
        {
            // Extraemos los datos del empaque basándonos en tu código original
            int id = Convert.ToInt32(parametros[0]);
            string nombreRuta = parametros[1].ToString();
            decimal tarifaPasaje = Convert.ToDecimal(parametros[2]);

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();

            // Preparamos la orden SQL de actualización
            comando.CommandText = "UPDATE Ruta SET NombreRuta = @nombre, TarifaPasaje = @tarifa WHERE ID_Ruta = @id";
            comando.CommandType = CommandType.Text;

            // Asignamos los nuevos valores de forma segura
            comando.Parameters.AddWithValue("@nombre", nombreRuta);
            comando.Parameters.AddWithValue("@tarifa", tarifaPasaje);
            comando.Parameters.AddWithValue("@id", id);

            // Ejecutamos asíncronamente
            await comando.ExecuteNonQueryAsync();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        // Método para borrar permanentemente el registro de una ruta de forma asíncrona
        public async Task EliminarAsync(int id)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();

            // Preparamos la orden SQL de eliminación
            comando.CommandText = "DELETE FROM Ruta WHERE ID_Ruta = @id";
            comando.CommandType = CommandType.Text;

            comando.Parameters.AddWithValue("@id", id);

            // Ejecutamos asíncronamente
            await comando.ExecuteNonQueryAsync();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
    }
}