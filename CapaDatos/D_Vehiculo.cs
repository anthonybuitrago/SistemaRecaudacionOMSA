using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CapaDatos
{
    // Maneja las operaciones de la base de datos relacionadas con los vehículos
    public class D_Vehiculo : ICrud
    {
        private ConexionBD conexion = new ConexionBD();

        // Extrae la lista de vehículos activos
        public async Task<DataTable> MostrarAsync()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexion.AbrirConexion();
                    comando.CommandText = "SELECT ID_Vehiculo, Ficha, Placa, Modelo, Capacidad, Estado FROM Vehiculo WHERE Estado != 'Inactivo'";
                    comando.CommandType = CommandType.Text;

                    using (SqlDataReader leer = await comando.ExecuteReaderAsync())
                    {
                        tabla.Load(leer);
                    }
                }
            }
            finally
            {
                conexion.CerrarConexion();
            }
            return tabla;
        }

        // TODO: [REQUISITO] - Captura de error para evitar cierre forzado del sistema
        // Registra un nuevo vehículo asegurando que el programa no colapse si falla la base de datos
        public async Task InsertarAsync(params object[] parametros)
        {
            string ficha = parametros[0].ToString();
            string placa = parametros[1].ToString();
            string modelo = parametros[2].ToString();
            int capacidad = Convert.ToInt32(parametros[3]);

            try
            {
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexion.AbrirConexion();
                    comando.CommandText = "INSERT INTO Vehiculo (Ficha, Placa, Modelo, Capacidad) VALUES (@ficha, @placa, @modelo, @capacidad)";

                    comando.Parameters.AddWithValue("@ficha", ficha);
                    comando.Parameters.AddWithValue("@placa", placa);
                    comando.Parameters.AddWithValue("@modelo", modelo);
                    comando.Parameters.AddWithValue("@capacidad", capacidad);

                    await comando.ExecuteNonQueryAsync();
                }
            }
            catch (SqlException ex)
            {
                // Capturamos el error para que la capa superior decida cómo mostrarlo al usuario
                throw new Exception("Error en la base de datos al guardar el vehículo: " + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        // Modifica los datos de un vehículo existente
        public async Task EditarAsync(params object[] parametros)
        {
            int id = Convert.ToInt32(parametros[0]);
            string ficha = parametros[1].ToString();
            string placa = parametros[2].ToString();
            string modelo = parametros[3].ToString();
            int capacidad = Convert.ToInt32(parametros[4]);

            try
            {
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexion.AbrirConexion();
                    comando.CommandText = "UPDATE Vehiculo SET Ficha=@ficha, Placa=@placa, Modelo=@modelo, Capacidad=@capacidad WHERE ID_Vehiculo=@id";

                    comando.Parameters.AddWithValue("@id", id);
                    comando.Parameters.AddWithValue("@ficha", ficha);
                    comando.Parameters.AddWithValue("@placa", placa);
                    comando.Parameters.AddWithValue("@modelo", modelo);
                    comando.Parameters.AddWithValue("@capacidad", capacidad);

                    await comando.ExecuteNonQueryAsync();
                }
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        // Realiza un borrado lógico del vehículo (cambia a Inactivo)
        public async Task EliminarAsync(int id)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexion.AbrirConexion();
                    comando.CommandText = "UPDATE Vehiculo SET Estado='Inactivo' WHERE ID_Vehiculo=@id";
                    comando.Parameters.AddWithValue("@id", id);

                    await comando.ExecuteNonQueryAsync();
                }
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        // Verifica si la ficha de un vehículo ya está registrada
        public async Task<bool> ExisteFichaAsync(string ficha)
        {
            int conteo = 0;
            try
            {
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexion.AbrirConexion();
                    comando.CommandText = "SELECT COUNT(*) FROM Vehiculo WHERE Ficha = @ficha AND Estado != 'Inactivo'";
                    comando.Parameters.AddWithValue("@ficha", ficha);

                    conteo = Convert.ToInt32(await comando.ExecuteScalarAsync());
                }
            }
            finally
            {
                conexion.CerrarConexion();
            }
            return conteo > 0;
        }
    }
}