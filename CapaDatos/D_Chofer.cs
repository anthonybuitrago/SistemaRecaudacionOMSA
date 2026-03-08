using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class D_Chofer
    {
        // Conexión a la base de datos
        private ConexionBD conexion = new ConexionBD();

        // Método para listar choferes
        public DataTable Mostrar()
        {
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand();
            SqlDataReader leer;

            // Abrir conexión y preparar comando
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SELECT * FROM Chofer";
            comando.CommandType = CommandType.Text;

            // Ejecutar y cargar datos
            leer = comando.ExecuteReader();
            tabla.Load(leer);

            // Cerrar conexión
            conexion.CerrarConexion();
            return tabla;
        }

        // Método para guardar un chofer
        public void Insertar(string cedula, string nombreCompleto, string numeroLicencia)
        {
            SqlCommand comando = new SqlCommand();

            // Abrir conexión y preparar SQL
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "INSERT INTO Chofer (Cedula, NombreCompleto, NumeroLicencia) VALUES (@Cedula, @Nombre, @Licencia)";
            comando.CommandType = CommandType.Text;

            // Cargar los parámetros
            comando.Parameters.AddWithValue("@Cedula", cedula);
            comando.Parameters.AddWithValue("@Nombre", nombreCompleto);
            comando.Parameters.AddWithValue("@Licencia", numeroLicencia);

            // Ejecutar en el servidor
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

            // Cerrar conexión
            conexion.CerrarConexion();
        }

        // Método para actualizar un chofer existente en la base de datos
        public void Editar(int id, string cedula, string nombre, string licencia)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();

            // El query de actualización (Asegúrate de que los nombres de las columnas coincidan con tu BD)
            comando.CommandText = "UPDATE Chofer SET Cedula = @cedula, NombreCompleto = @nombre, NumeroLicencia = @licencia WHERE ID_Chofer = @id";
            comando.CommandType = CommandType.Text;

            // Pasamos los parámetros de forma segura
            comando.Parameters.AddWithValue("@cedula", cedula);
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@licencia", licencia);
            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        // Método para eliminar un chofer de la base de datos
        public void Eliminar(int id)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();

            // Verifica que "ID_Chofer" sea el nombre correcto en tu SQL Server
            comando.CommandText = "DELETE FROM Chofer WHERE ID_Chofer = @id";
            comando.CommandType = CommandType.Text;

            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }
    }
}