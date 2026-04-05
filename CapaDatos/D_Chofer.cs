using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class D_Chofer : ICrud
    {
        private ConexionBD conexion = new ConexionBD();

        public async Task<DataTable> MostrarAsync()
        {
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();
            SqlDataReader leer;

            comando.Connection = conexion.AbrirConexion();
            // CAMBIO 1: Traemos el Teléfono y el Estado, y filtramos a los inactivos
            comando.CommandText = "SELECT ID_Chofer, Cedula, NombreCompleto, Telefono, NumeroLicencia, Estado FROM Chofer WHERE Estado != 'Inactivo'";
            comando.CommandType = CommandType.Text;

            leer = await comando.ExecuteReaderAsync();
            tabla.Load(leer);

            conexion.CerrarConexion();
            return tabla;
        }

        public async Task InsertarAsync(params object[] parametros)
        {
            // CAMBIO 2: Agregamos la extracción del Teléfono (posición 3 del arreglo)
            string cedula = parametros[0].ToString();
            string nombreCompleto = parametros[1].ToString();
            string numeroLicencia = parametros[2].ToString();
            string telefono = parametros[3].ToString(); // <-- NUEVO

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();

            // Agregamos el Teléfono al INSERT
            comando.CommandText = "INSERT INTO Chofer (Cedula, NombreCompleto, NumeroLicencia, Telefono) VALUES (@Cedula, @Nombre, @Licencia, @Telefono)";
            comando.CommandType = CommandType.Text;

            comando.Parameters.AddWithValue("@Cedula", cedula);
            comando.Parameters.AddWithValue("@Nombre", nombreCompleto);
            comando.Parameters.AddWithValue("@Licencia", numeroLicencia);
            comando.Parameters.AddWithValue("@Telefono", telefono); // <-- NUEVO

            await comando.ExecuteNonQueryAsync();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public async Task EditarAsync(params object[] parametros)
        {
            // CAMBIO 3: Agregamos la extracción del Teléfono (posición 4 del arreglo)
            int id = Convert.ToInt32(parametros[0]);
            string cedula = parametros[1].ToString();
            string nombre = parametros[2].ToString();
            string licencia = parametros[3].ToString();
            string telefono = parametros[4].ToString(); // <-- NUEVO

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();

            // Agregamos el Teléfono al UPDATE
            comando.CommandText = "UPDATE Chofer SET Cedula = @cedula, NombreCompleto = @nombre, NumeroLicencia = @licencia, Telefono = @telefono WHERE ID_Chofer = @id";
            comando.CommandType = CommandType.Text;

            comando.Parameters.AddWithValue("@cedula", cedula);
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@licencia", licencia);
            comando.Parameters.AddWithValue("@telefono", telefono); // <-- NUEVO
            comando.Parameters.AddWithValue("@id", id);

            await comando.ExecuteNonQueryAsync();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public async Task EliminarAsync(int id)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();

            // CAMBIO 4: El Borrado Lógico. Cambiamos DELETE por UPDATE
            comando.CommandText = "UPDATE Chofer SET Estado = 'Inactivo' WHERE ID_Chofer = @id";
            comando.CommandType = CommandType.Text;

            comando.Parameters.AddWithValue("@id", id);

            await comando.ExecuteNonQueryAsync();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public async Task<bool> ExisteCedulaAsync(string cedula)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion(); // Usamos tu método de siempre
            comando.CommandText = "SELECT COUNT(*) FROM Chofer WHERE Cedula = @cedula AND Estado != 'Inactivo'";
            comando.Parameters.AddWithValue("@cedula", cedula);

            int conteo = Convert.ToInt32(await comando.ExecuteScalarAsync());

            conexion.CerrarConexion(); // Cerramos como lo haces tú
            return conteo > 0;
        }
    }
}