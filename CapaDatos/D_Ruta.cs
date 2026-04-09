using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CapaDatos
{
    // TODO: [REQUISITO] - Clases creadas según su uso sin código ajeno (Separación de responsabilidades)
    // Gestiona exclusivamente las operaciones de base de datos para la entidad Ruta
    public class D_Ruta : ICrud
    {
        private ConexionBD conexion = new ConexionBD();

        // Obtiene la lista de rutas activas
        public async Task<DataTable> MostrarAsync()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexion.AbrirConexion();
                    comando.CommandText = "SELECT ID_Ruta, NombreRuta, Tarifa, TiempoMinutos, DistanciaKM, Estado FROM Ruta WHERE Estado != 'Inactivo'";
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

        // Inserta una nueva ruta en el sistema
        public async Task InsertarAsync(params object[] parametros)
        {
            string nombre = parametros[0].ToString();
            decimal tarifa = Convert.ToDecimal(parametros[1]);
            int tiempo = Convert.ToInt32(parametros[2]);
            decimal distancia = Convert.ToDecimal(parametros[3]);

            try
            {
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexion.AbrirConexion();
                    comando.CommandText = "INSERT INTO Ruta (NombreRuta, Tarifa, TiempoMinutos, DistanciaKM) VALUES (@nombre, @tarifa, @tiempo, @distancia)";

                    comando.Parameters.AddWithValue("@nombre", nombre);
                    comando.Parameters.AddWithValue("@tarifa", tarifa);
                    comando.Parameters.AddWithValue("@tiempo", tiempo);
                    comando.Parameters.AddWithValue("@distancia", distancia);

                    await comando.ExecuteNonQueryAsync();
                }
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        // Modifica los datos de una ruta existente
        public async Task EditarAsync(params object[] parametros)
        {
            int id = Convert.ToInt32(parametros[0]);
            string nombre = parametros[1].ToString();
            decimal tarifa = Convert.ToDecimal(parametros[2]);
            int tiempo = Convert.ToInt32(parametros[3]);
            decimal distancia = Convert.ToDecimal(parametros[4]);

            try
            {
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexion.AbrirConexion();
                    comando.CommandText = "UPDATE Ruta SET NombreRuta = @nombre, Tarifa = @tarifa, TiempoMinutos = @tiempo, DistanciaKM = @distancia WHERE ID_Ruta = @id";

                    comando.Parameters.AddWithValue("@id", id);
                    comando.Parameters.AddWithValue("@nombre", nombre);
                    comando.Parameters.AddWithValue("@tarifa", tarifa);
                    comando.Parameters.AddWithValue("@tiempo", tiempo);
                    comando.Parameters.AddWithValue("@distancia", distancia);

                    await comando.ExecuteNonQueryAsync();
                }
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        // Realiza un borrado lógico de la ruta
        public async Task EliminarAsync(int id)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexion.AbrirConexion();
                    comando.CommandText = "UPDATE Ruta SET Estado = 'Inactivo' WHERE ID_Ruta = @id";
                    comando.Parameters.AddWithValue("@id", id);

                    await comando.ExecuteNonQueryAsync();
                }
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        // Verifica la existencia de una ruta para evitar duplicados
        public async Task<bool> ExisteRutaAsync(string nombreRuta)
        {
            int conteo = 0;
            try
            {
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexion.AbrirConexion();
                    comando.CommandText = "SELECT COUNT(*) FROM Ruta WHERE NombreRuta = @nombre AND Estado != 'Inactivo'";
                    comando.Parameters.AddWithValue("@nombre", nombreRuta);

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