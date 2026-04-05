using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class D_Ruta : ICrud
    {
        private ConexionBD conexion = new ConexionBD();

        // Extraer rutas activas con los nuevos campos de gestión
        public async Task<DataTable> MostrarAsync()
        {
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion.AbrirConexion();
            // Cambiamos Origen/Destino por TiempoMinutos/DistanciaKM
            comando.CommandText = "SELECT ID_Ruta, NombreRuta, Tarifa, TiempoMinutos, DistanciaKM, Estado FROM Ruta WHERE Estado != 'Inactivo'";
            comando.CommandType = CommandType.Text;

            using (SqlDataReader leer = await comando.ExecuteReaderAsync())
            {
                tabla.Load(leer);
            }

            conexion.CerrarConexion();
            return tabla;
        }

        // Insertar Nombre, Tarifa, Tiempo y Distancia
        public async Task InsertarAsync(params object[] parametros)
        {
            // Extraemos los nuevos datos del empaque
            string nombre = parametros[0].ToString();
            decimal tarifa = Convert.ToDecimal(parametros[1]);
            int tiempo = Convert.ToInt32(parametros[2]); // Tiempo en minutos
            decimal distancia = Convert.ToDecimal(parametros[3]); // Distancia en KM

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "INSERT INTO Ruta (NombreRuta, Tarifa, TiempoMinutos, DistanciaKM) VALUES (@nombre, @tarifa, @tiempo, @distancia)";

            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@tarifa", tarifa);
            comando.Parameters.AddWithValue("@tiempo", tiempo);
            comando.Parameters.AddWithValue("@distancia", distancia);

            await comando.ExecuteNonQueryAsync();
            conexion.CerrarConexion();
        }

        // Editar los 4 campos de gestión
        public async Task EditarAsync(params object[] parametros)
        {
            int id = Convert.ToInt32(parametros[0]);
            string nombre = parametros[1].ToString();
            decimal tarifa = Convert.ToDecimal(parametros[2]);
            int tiempo = Convert.ToInt32(parametros[3]);
            decimal distancia = Convert.ToDecimal(parametros[4]);

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "UPDATE Ruta SET NombreRuta = @nombre, Tarifa = @tarifa, TiempoMinutos = @tiempo, DistanciaKM = @distancia WHERE ID_Ruta = @id";

            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@tarifa", tarifa);
            comando.Parameters.AddWithValue("@tiempo", tiempo);
            comando.Parameters.AddWithValue("@distancia", distancia);

            await comando.ExecuteNonQueryAsync();
            conexion.CerrarConexion();
        }

        // Borrado Lógico
        public async Task EliminarAsync(int id)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "UPDATE Ruta SET Estado = 'Inactivo' WHERE ID_Ruta = @id";
            comando.Parameters.AddWithValue("@id", id);

            await comando.ExecuteNonQueryAsync();
            conexion.CerrarConexion();
        }

        // Evitar duplicados por nombre
        public async Task<bool> ExisteRutaAsync(string nombreRuta)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SELECT COUNT(*) FROM Ruta WHERE NombreRuta = @nombre AND Estado != 'Inactivo'";
            comando.Parameters.AddWithValue("@nombre", nombreRuta);

            int conteo = Convert.ToInt32(await comando.ExecuteScalarAsync());

            conexion.CerrarConexion();
            return conteo > 0;
        }
    }
}