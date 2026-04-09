using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class D_Chofer : ICrud
    {
        private ConexionBD conexion = new ConexionBD();

        // TODO: [REQUISITO] - Opción consulta (vistazo a datos ya guardados)
        // Extrae la lista de choferes activos desde la base de datos
        public async Task<DataTable> MostrarAsync()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexion.AbrirConexion();
                    comando.CommandText = "SELECT ID_Chofer, Cedula, NombreCompleto, Telefono, NumeroLicencia, Estado FROM Chofer WHERE Estado != 'Inactivo'";
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

        // TODO: [REQUISITO] - Opción de entrada (Agregar datos en la base de datos)
        // Registra un nuevo chofer en el sistema
        public async Task InsertarAsync(params object[] parametros)
        {
            string cedula = parametros[0].ToString();
            string nombreCompleto = parametros[1].ToString();
            string numeroLicencia = parametros[2].ToString();
            string telefono = parametros[3].ToString();

            try
            {
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexion.AbrirConexion();
                    comando.CommandText = "INSERT INTO Chofer (Cedula, NombreCompleto, NumeroLicencia, Telefono) VALUES (@Cedula, @Nombre, @Licencia, @Telefono)";
                    comando.CommandType = CommandType.Text;

                    comando.Parameters.AddWithValue("@Cedula", cedula);
                    comando.Parameters.AddWithValue("@Nombre", nombreCompleto);
                    comando.Parameters.AddWithValue("@Licencia", numeroLicencia);
                    comando.Parameters.AddWithValue("@Telefono", telefono);

                    await comando.ExecuteNonQueryAsync();
                }
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        // Modifica los datos de un chofer existente
        public async Task EditarAsync(params object[] parametros)
        {
            int id = Convert.ToInt32(parametros[0]);
            string cedula = parametros[1].ToString();
            string nombre = parametros[2].ToString();
            string licencia = parametros[3].ToString();
            string telefono = parametros[4].ToString();

            try
            {
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexion.AbrirConexion();
                    comando.CommandText = "UPDATE Chofer SET Cedula = @cedula, NombreCompleto = @nombre, NumeroLicencia = @licencia, Telefono = @telefono WHERE ID_Chofer = @id";
                    comando.CommandType = CommandType.Text;

                    comando.Parameters.AddWithValue("@cedula", cedula);
                    comando.Parameters.AddWithValue("@nombre", nombre);
                    comando.Parameters.AddWithValue("@licencia", licencia);
                    comando.Parameters.AddWithValue("@telefono", telefono);
                    comando.Parameters.AddWithValue("@id", id);

                    await comando.ExecuteNonQueryAsync();
                }
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        // Realiza un borrado lógico del chofer (cambio de estado)
        public async Task EliminarAsync(int id)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexion.AbrirConexion();
                    comando.CommandText = "UPDATE Chofer SET Estado = 'Inactivo' WHERE ID_Chofer = @id";
                    comando.CommandType = CommandType.Text;
                    comando.Parameters.AddWithValue("@id", id);

                    await comando.ExecuteNonQueryAsync();
                }
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        // Verifica si una cédula ya está registrada para evitar duplicados
        public async Task<bool> ExisteCedulaAsync(string cedula)
        {
            int conteo = 0;
            try
            {
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexion.AbrirConexion();
                    comando.CommandText = "SELECT COUNT(*) FROM Chofer WHERE Cedula = @cedula AND Estado != 'Inactivo'";
                    comando.Parameters.AddWithValue("@cedula", cedula);

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