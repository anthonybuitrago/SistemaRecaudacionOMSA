using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks; // Obligatorio para el asincronismo

namespace CapaDatos
{
    // TODO: Requisito - Implementación de Interfaz ICrud
    public class D_Chofer : ICrud
    {
        // Instancia para establecer la comunicación con el servidor SQL
        private ConexionBD conexion = new ConexionBD();

        // TODO: Requisito - Llamada Asíncrona (Async/Await)
        // Método para extraer y listar todos los choferes registrados de forma asíncrona
        public async Task<DataTable> MostrarAsync()
        {
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();
            SqlDataReader leer;

            // Abrimos el canal y preparamos la orden de consulta
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SELECT * FROM Chofer";
            comando.CommandType = CommandType.Text;

            // Ejecutamos la consulta asíncrona y volcamos los resultados en la tabla
            leer = await comando.ExecuteReaderAsync();
            tabla.Load(leer);

            // Cerramos la comunicación de forma segura
            conexion.CerrarConexion();
            return tabla;
        }

        // TODO: Requisito - Llamada Asíncrona usando el arreglo de parámetros de la Interfaz
        // Método para registrar un nuevo chofer en la base de datos
        public async Task InsertarAsync(params object[] parametros)
        {
            // Extraemos los datos del empaque basándonos en tu código original
            string cedula = parametros[0].ToString();
            string nombreCompleto = parametros[1].ToString();
            string numeroLicencia = parametros[2].ToString();

            SqlCommand comando = new SqlCommand();

            // Abrimos el canal y preparamos la orden de inserción
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "INSERT INTO Chofer (Cedula, NombreCompleto, NumeroLicencia) VALUES (@Cedula, @Nombre, @Licencia)";
            comando.CommandType = CommandType.Text;

            // Empaquetamos los datos de forma segura para evitar hackeos (Inyección SQL)
            comando.Parameters.AddWithValue("@Cedula", cedula);
            comando.Parameters.AddWithValue("@Nombre", nombreCompleto);
            comando.Parameters.AddWithValue("@Licencia", numeroLicencia);

            // Ejecutamos la acción en el servidor de forma asíncrona y limpiamos el empaque
            await comando.ExecuteNonQueryAsync();
            comando.Parameters.Clear();

            conexion.CerrarConexion();
        }

        // Método para modificar los datos de un chofer ya existente de forma asíncrona
        public async Task EditarAsync(params object[] parametros)
        {
            // Extraemos los datos del empaque basándonos en tu código original
            int id = Convert.ToInt32(parametros[0]);
            string cedula = parametros[1].ToString();
            string nombre = parametros[2].ToString();
            string licencia = parametros[3].ToString();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();

            // Preparamos la orden SQL de actualización
            comando.CommandText = "UPDATE Chofer SET Cedula = @cedula, NombreCompleto = @nombre, NumeroLicencia = @licencia WHERE ID_Chofer = @id";
            comando.CommandType = CommandType.Text;

            // Asignamos los nuevos valores de forma segura
            comando.Parameters.AddWithValue("@cedula", cedula);
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@licencia", licencia);
            comando.Parameters.AddWithValue("@id", id);

            // Ejecutamos asíncronamente
            await comando.ExecuteNonQueryAsync();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        // Método para borrar permanentemente el registro de un chofer de forma asíncrona
        public async Task EliminarAsync(int id)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();

            // Preparamos la orden SQL de eliminación
            comando.CommandText = "DELETE FROM Chofer WHERE ID_Chofer = @id";
            comando.CommandType = CommandType.Text;

            comando.Parameters.AddWithValue("@id", id);

            // Ejecutamos asíncronamente
            await comando.ExecuteNonQueryAsync();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
    }
}