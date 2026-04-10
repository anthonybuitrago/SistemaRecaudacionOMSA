using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CapaDatos
{
    // TODO: [REQUISITO] - Responsabilidad Única: Clase creada exclusivamente para el manejo de la entidad Ruta.

    // Persistencia de datos para la gestión de rutas (Implementación del contrato ICrud)
    // Clase diseñada bajo el principio de responsabilidad única (SRP)
    public class D_Ruta : ICrud
    {
        private ConexionBD conexion = new ConexionBD();

        // ==========================================================
        // CONSULTAS DE DATOS
        // ==========================================================

        // Recupera el catálogo de rutas que se encuentran en estado operativo
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

        // Verifica si una ruta ya existe en el sistema para prevenir redundancia
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

        // ==========================================================
        // OPERACIONES TRANSACCIONALES
        // ==========================================================

        // Registra una nueva ruta logística en la base de datos
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

        // Actualiza los parámetros operativos de una ruta existente
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

        // Ejecuta la baja lógica de la ruta en la base de datos
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
    }
}