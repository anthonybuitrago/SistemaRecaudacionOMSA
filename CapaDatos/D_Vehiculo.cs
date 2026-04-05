using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks; // Obligatorio para el asincronismo

namespace CapaDatos
{
    // TODO: Requisito - Implementación de Interfaz ICrud
    public class D_Vehiculo : ICrud
    {
        // Instancia para establecer la comunicación con el servidor SQL
        private ConexionBD conexion = new ConexionBD();

        // TODO: Requisito - Llamada Asíncrona (Async/Await)
        // Método para extraer y listar vehículos que NO estén inactivos
        public async Task<DataTable> MostrarAsync()
        {
            // Cambiamos el SELECT * por las columnas específicas incluyendo Modelo y Estado
            string query = "SELECT ID_Vehiculo, Ficha, Placa, Modelo, Capacidad, Estado FROM Vehiculo WHERE Estado != 'Inactivo'";

            SqlCommand comando = new SqlCommand(query, conexion.AbrirConexion());
            DataTable tabla = new DataTable();

            SqlDataReader leer = await comando.ExecuteReaderAsync();
            tabla.Load(leer);

            conexion.CerrarConexion();
            return tabla;
        }

        // TODO: Requisito - Llamada Asíncrona usando el arreglo de parámetros de la Interfaz
        // Registro de un nuevo vehículo incluyendo el campo Modelo
        public async Task InsertarAsync(params object[] parametros)
        {
            // Extraemos 4 datos del empaque (Ficha, Placa, Modelo, Capacidad)
            string ficha = parametros[0].ToString();
            string placa = parametros[1].ToString();
            string modelo = parametros[2].ToString();
            int capacidad = Convert.ToInt32(parametros[3]);

            SqlCommand comando = new SqlCommand(
                "INSERT INTO Vehiculo (Ficha, Placa, Modelo, Capacidad) VALUES (@ficha, @placa, @modelo, @capacidad)",
                conexion.AbrirConexion()
            );

            comando.Parameters.AddWithValue("@ficha", ficha);
            comando.Parameters.AddWithValue("@placa", placa);
            comando.Parameters.AddWithValue("@modelo", modelo);
            comando.Parameters.AddWithValue("@capacidad", capacidad);

            await comando.ExecuteNonQueryAsync();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        // Modificación de datos incluyendo el campo Modelo
        public async Task EditarAsync(params object[] parametros)
        {
            // Extraemos 5 datos del empaque: ID + los 4 campos del formulario
            int id = Convert.ToInt32(parametros[0]);
            string ficha = parametros[1].ToString();
            string placa = parametros[2].ToString();
            string modelo = parametros[3].ToString();
            int capacidad = Convert.ToInt32(parametros[4]);

            SqlCommand comando = new SqlCommand(
                "UPDATE Vehiculo SET Ficha=@ficha, Placa=@placa, Modelo=@modelo, Capacidad=@capacidad WHERE ID_Vehiculo=@id",
                conexion.AbrirConexion()
            );

            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@ficha", ficha);
            comando.Parameters.AddWithValue("@placa", placa);
            comando.Parameters.AddWithValue("@modelo", modelo);
            comando.Parameters.AddWithValue("@capacidad", capacidad);

            await comando.ExecuteNonQueryAsync();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        // TODO: Requisito - Borrado Lógico
        // Cambiamos el estado a Inactivo en lugar de borrar la fila
        public async Task EliminarAsync(int id)
        {
            SqlCommand comando = new SqlCommand(
                "UPDATE Vehiculo SET Estado='Inactivo' WHERE ID_Vehiculo=@id",
                conexion.AbrirConexion()
            );

            comando.Parameters.AddWithValue("@id", id);

            await comando.ExecuteNonQueryAsync();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        // MÉTODO EXTRA: Para validar si la ficha ya existe y evitar duplicados
        public async Task<bool> ExisteFichaAsync(string ficha)
        {
            SqlCommand comando = new SqlCommand(
                "SELECT COUNT(*) FROM Vehiculo WHERE Ficha = @ficha AND Estado != 'Inactivo'",
                conexion.AbrirConexion()
            );
            comando.Parameters.AddWithValue("@ficha", ficha);

            int conteo = Convert.ToInt32(await comando.ExecuteScalarAsync());

            conexion.CerrarConexion();
            return conteo > 0;
        }
    }
}